using System;
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

            school.Courses = new Course[]{
                new Course(){Name = "101"},     //Inicializacion
                new Course(){Name = "201"},
                new Course(){Name = "301"}
            };

            WriteLine(school+"\n");

            PrintSchoolCourses(school);
        }

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