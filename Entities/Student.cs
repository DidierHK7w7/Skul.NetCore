using System;
namespace Skul.Entities
{
    public class Student
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }

        public List<Evaluations> EvaluationsList { get; set; }

        public Student()
        {
            UniqueId = Guid.NewGuid().ToString();
            EvaluationsList = new List<Evaluations>(){};
        }
    }
}