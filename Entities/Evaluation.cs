using System;
namespace Skul.Entities
{
    public class Evaluation : SchoolBaseObject
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public float Grade { get; set; }

        public override string ToString() => $"{Grade},{Student.Name},{Subject.Name}";
    }
}