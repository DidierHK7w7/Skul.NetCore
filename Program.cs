using System;
using System.Collections.Generic;
using Skul.Entities;
using Skul.App;
using static System.Console;    //Para evitar escribir Console.WriteLine, y solo WriteLine

namespace Skul
{
    public class Program
    {
        static void Main()
        {
            var engine = new SchoolEngine();
            engine.InitializeValues();
            
            
            WriteLine(engine.School+"\n");
            PrintSchoolCourses(engine.School);
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