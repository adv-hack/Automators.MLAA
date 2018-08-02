using System.Collections.Generic;
namespace Entity
{
    public class TestDataResult
    {
        public TestDataResult()
        {
            SelectedScore = 0.0;
        }

        public string SelectedFunction { get; set; }
        public List<string> SelectedParams { get; set; }
        public List<Function> Functions { get; set; }
        public double SelectedScore { get; set; }
        public int Order { get; set; }
        public string TestData { get; set; }

        public override string ToString()
        {
            return SelectedFunction;
        }
    }
}
