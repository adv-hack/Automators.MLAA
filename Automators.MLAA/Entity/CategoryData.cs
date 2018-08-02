using System.Collections.Generic;

namespace Entity
{
    public class CategoryData
    {
        public CategoryData()
        {
            WordList = new List<string>();
            Score = 0.0;
        }

        public string Category { get; set; }
        public List<string> TrainingData { get; set; }
        public List<string> WordList { get; set; }
        public double Probability { get; set; }
        public double Score { get; set; }
    }
}