using System;
namespace Skul.Entities
{
    public class Student : SchoolBaseObject         //Herencia
    {
        public List<Evaluation> EvaluationsList { get; set; } = new List<Evaluation>(){};
    }
}