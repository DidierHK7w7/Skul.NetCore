using System;

namespace Skul.Entities
{
    public class Course
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }
        public WorkingTypes Working { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }

        public Course() => UniqueId = Guid.NewGuid().ToString();    //Genera id aleatorio
    }
}