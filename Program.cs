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

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de polimorfismo");

            var studentTest = new Student{Name="Sayo"};
            SchoolBaseObject ob = studentTest;
            //ob.Name = "Sayo";       //ob toma Name de Student por uqe este hereda de SchoolBaseObject
            Printer.WriteTitle("Student");
            WriteLine($"Student:{studentTest.Name}");
            WriteLine($"Student:{studentTest.UniqueId}");
            WriteLine($"Student:{studentTest.GetType()}");      //GetTyoe obtiene el tipo de objeto

            Printer.WriteTitle("SchoolBaseObject");
            WriteLine($"Student:{ob.Name}");
            WriteLine($"Student:{ob.UniqueId}");
            WriteLine($"Student:{ob.GetType()}");

            var objDummy = new SchoolBaseObject(){Name="Ran Mitake"};
            Printer.WriteTitle("objDummy");
            WriteLine($"Student:{objDummy.Name}");
            WriteLine($"Student:{objDummy.UniqueId}");
            WriteLine($"Student:{objDummy.GetType()}");

            var evaluation = new Evaluation(){Name="Math evaluation", Grade=4.5f};
            Printer.WriteTitle("Evaluation");
            WriteLine($"evaluation:{evaluation.Name}");
            WriteLine($"evaluation:{evaluation.Grade}");
            WriteLine($"evaluation:{evaluation.UniqueId}");
            WriteLine($"evaluation:{evaluation.GetType()}");

            ob = evaluation;
            Printer.WriteTitle("Student");
            WriteLine($"Student:{ob.Name}");
            WriteLine($"Student:{ob.UniqueId}");
            WriteLine($"Student:{ob.GetType()}");

            studentTest =(Student) (SchoolBaseObject) evaluation;       //Dara error de casteo xq evaluation no es de tipo Student
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