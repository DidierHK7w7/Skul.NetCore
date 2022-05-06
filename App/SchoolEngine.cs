using System;
using System.Collections.Generic;
using Skul.Entities;

namespace Skul.App
{
    public class SchoolEngine
    {
        public School School { get; set; }
        public SchoolEngine()
        {
            
        }

        public void InitializeValues()
        {
            School = new School("Platzi Academy", 2012, SchoolTypes.Elementary,
            city:"Bogota", country:"Colombia");

            School.Courses = new List<Course>(){   //Lista generica
                new Course(){Name = "101", Working = WorkingTypes.Morning},     //Inicializacion
                new Course(){Name = "201", Working = WorkingTypes.Morning},
                new Course(){Name = "301", Working = WorkingTypes.Morning},
                new Course(){Name = "401", Working = WorkingTypes.Afternoon},     //Inicializacion
                new Course(){Name = "501", Working = WorkingTypes.Afternoon}
            };
        }
    }
}