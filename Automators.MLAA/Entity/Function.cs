using System.Collections.Generic;

namespace Entity
{
    public class Function
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Parameters { get; set; }
        public double Score { get; set; }

        public Function(string name, string description, List<string> parameters, double score)
        {
            Name = name;
            Description = description;
            Parameters = parameters;
            Score = score;
        }

        public Function()
        {
            
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}