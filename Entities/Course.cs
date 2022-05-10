using System;
using Skul.Utilities;

namespace Skul.Entities
{
    public class Course : SchoolBaseObject, IPlace
    {
        public WorkingType Working { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
        public string Address { get; set; }

        public void CleanPlace()
        {
            Printer.DrawLine();
            Console.WriteLine("Cleaning establishment...");
            Console.WriteLine($"Course {Name} clean");
        }
    }
}