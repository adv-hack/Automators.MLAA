using System.Collections.Generic;

namespace Entity
{
    public class FunctionData
    {
        public FunctionData()
        {
            WordList = new List<string>();
            Score = 0.0;
        }

        public string Function { get; set; }
        public List<string> Params { get; set; }
        public List<string> TrainingData { get; set; }
        public List<string> WordList { get; set; }
        public double Probability { get; set; }
        public double Score { get; set; }
    }
}