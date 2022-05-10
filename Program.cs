using System;
using System.Collections.Generic;
using Skul.Entities;
using Skul.App;
using Skul.Utilities;
using static System.Console;    //Para evitar escribir Console.WriteLine, y solo WriteLine

namespace Skul
{
    public class Program
    {
        static void Main()
        {
            var engine = new SchoolEngine();
            engine.InitializeValues();
            Printer.WriteTitle("Welcome to School");
            Printer.Ring();
            PrintSchoolCourses(engine.School);

            var objectList = engine.GetSchoolObjects();

            var ListIplace = from obj in objectList
                            where obj is IPlace     //devuelve solo los objetos IPlace
                            select (IPlace) obj;
            //engine.School.CleanPlace();
        }

        private static void PrintSchoolCourses(School school)
        {
            Printer.WriteTitle("School Courses");

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