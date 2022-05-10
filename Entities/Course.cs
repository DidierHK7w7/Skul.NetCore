using System;

namespace Skul.Entities
{
    public class Course : SchoolBaseObject
    {
        public WorkingType Working { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
    }
}