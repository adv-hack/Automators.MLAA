using System;
using System.Collections.Generic;
using System.Data;
using Automator.DataAccess;
using Entity;
using System.Linq;
using Utility;

namespace Engine
{
    public class Categoriser : ICategoriser
    {
        private readonly DBHelper _dbHelper;
        private List<FunctionData> _functionData;
        private readonly TextUtil _textUtil = new TextUtil();
        private readonly List<TestDataResult> _results = new List<TestDataResult>();
        private readonly HashSet<string> _uniqueWords = new HashSet<string>();

        public Categoriser()
        {
            _dbHelper = new DBHelper();
        }

        public List<TestDataResult> Categorise(List<string> testData)
        {
            var trainingData = GetTrainingData();

            PrepareData(trainingData);

            foreach (var data in testData)
            {
                _results.Add(Calculate(data));
            }

            return _results;
        }

        public void PrepareData(DataTable trainindData)
        {
            _functionData = trainindData.AsEnumerable()
                .Select(row => row.Field<string>("Function"))
                .Distinct()
                .Select(function => new FunctionData { Function = function }).ToList();
            
            foreach (var data in _functionData)
            {
                data.TrainingData = trainindData.AsEnumerable()
                    .Where(c => c.Field<string>("Function") == data.Function)
                    .Select(row => row.Field<string>("Data"))
                    .ToList();

                foreach (var trainingData in data.TrainingData)
                {
                    var filteredWords = _textUtil.FilterWords(trainingData);
                    data.WordList.AddRange(filteredWords);
                    _uniqueWords.UnionWith(filteredWords);
                }
            }

            var totalTrainingData = _functionData.Sum(c => c.TrainingData.Count);

            foreach (var data in _functionData)
            {
                data.Probability = Convert.ToDouble(data.TrainingData.Count) / totalTrainingData;
            }
        }

        private TestDataResult Calculate(string testData)
        {
            var resultdata = new TestDataResult
            {
                TestData = testData,
                Order = _results.Count + 1
            };

            var param = _textUtil.GetDoubleQuotedWords(testData);

            testData = _textUtil.RemoveDoubleQuotedOWrds(testData);

            foreach (var data in _functionData)
            {
                var words = _textUtil.FilterWords(testData);
                
                var score = 1.0;

                foreach (var word in words)
                {
                    var wordCount = data.WordList.Count(w => w.Equals(word));

                    score *= (wordCount + 1.0) / (data.WordList.Count + _uniqueWords.Count);
                }

                data.Score = score * data.Probability;

                resultdata.Functions.Add(new Function
                {
                    Name = data.Function,
                    Score = score
                });
            }

            var selectFunction = resultdata.Functions.OrderByDescending(s => s.Score).Take(1).FirstOrDefault();

            if (selectFunction == null)
            {
                return resultdata;
            }

            resultdata.SelectedFunction = selectFunction.Name;
            resultdata.SelectedScore = selectFunction.Score;
            resultdata.SelectedParams = param;

            return resultdata;
        }

        private DataTable GetTrainingData()
        {
            return _dbHelper.ExecuteQuery("select * from TrainingData");
        }
    }
}