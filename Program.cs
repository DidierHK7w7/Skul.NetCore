using System;
using System.Collections.Generic;
using Skul.Entities;
using static System.Console;    //Para evitar escribir Console.WriteLine, y solo WriteLine

namespace Skul
{
    public class Program
    {
        static void Main()
        {
            var school = new School("Platzi Academy", 2012, SchoolTypes.Elementary,
            city:"Bogota", country:"Colombia");

            school.Courses = new List<Course>(){   //Lista generica
                new Course(){Name = "101", Working = WorkingTypes.Morning},     //Inicializacion
                new Course(){Name = "201", Working = WorkingTypes.Morning},
                new Course(){Name = "301", Working = WorkingTypes.Morning}
            };
            school.Courses.Add(new Course{Name="102", Working = WorkingTypes.Afternoon});
            school.Courses.Add(new Course{Name="202", Working = WorkingTypes.Afternoon});


            var otherCollection = new List<Course>(){   //Lista generica
                new Course(){Name = "401", Working = WorkingTypes.Morning},     //Inicializacion
                new Course(){Name = "501", Working = WorkingTypes.Morning},
                new Course(){Name = "502", Working = WorkingTypes.Afternoon}
            };
            
            //Course temp = new Course{Name = "101-vacacional", Working = WorkingTypes.Morning};
            school.Courses.AddRange(otherCollection);
            //school.Courses.Add(temp);

            Predicate<Course> myAlgorithm = PredicateCourse;  //delegado, solo se le asignan metodos que devuelven bool y q reciben el tipo de dato especificado, en este caso Course
            school.Courses.RemoveAll(myAlgorithm);    //Remueve todo lo que suceda con respecto a lo que devuelva el predicado
            


            WriteLine(school+"\n");
            PrintSchoolCourses(school);
            //WriteLine("Course.Hash" + temp.GetHashCode());
        }

        private static bool PredicateCourse(Course courObj) => courObj.Name == "301";     //Borra el courso 301

        private static void PrintSchoolCourses(School school)
        {
            WriteLine("--------------------\nSchool Courses\n--------------------");

            if (school?.Courses != null)    //? verifica si la escuela es diferente de null, si es pasa a la segunda condicion de lo contrario no
            {
                foreach (var item in school.Courses)
                {
                    WriteLine($"Nombre: {item.Name},    id: {item.UniqueId}");
                }
            }
        }
    }
}