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
            AppDomain.CurrentDomain.ProcessExit += EventAction;     //Activa evento cuando termine la ejecucion

            var engine = new SchoolEngine();
            engine.InitializeValues();
            Printer.WriteTitle("Welcome to School");
            //Printer.Ring();

            var reporter = new Reporter(engine.GetObjectDictionary());
            var evaluationsList = reporter.GetEvaluationsList();
            var subjectList = reporter.GetSubjectsList();

            var evaluationsListBySubject = reporter.GetAssessmentDicBySubject();
            var averagesBySubject = reporter.GetAverageStudentBySubject();

            var topAveragesSubject = reporter.TopAveragesSubject(5);

            //Interfaz
            Printer.WriteTitle("Capture of an evaluation by console");
            var newEval = new Evaluation();
            string name, gradeStr;
            float grade;
            WriteLine("Enter the name of the evaluation");
            Printer.PressEnter();
            name = ReadLine();

            if (string.IsNullOrWhiteSpace(name))    //si la cadena es nulla o un espacio en blanco dispara una excepcion
            {
                Printer.WriteTitle("Enter a valid value");
                WriteLine("Coming out");
            }else
            {
                newEval.Name = name.ToLower();
                WriteLine("Name entered correctly");
            }

            WriteLine("Enter the grade of the evaluation");
            Printer.PressEnter();
            gradeStr = ReadLine();
            if (string.IsNullOrWhiteSpace(gradeStr))    //si la cadena es nulla o un espacio en blanco dispara una excepcion
            {
                Printer.WriteTitle("Enter a valid value");
                WriteLine("Coming out");
            }else
            {
                try
                {
                    newEval.Grade = float.Parse(gradeStr);
                    if (newEval.Grade < 0 || newEval.Grade >5)
                    {
                        throw new ArgumentOutOfRangeException("The grade must be between 0 and 5");
                    }
                    WriteLine("Grade entered correctly");
                }
                catch (ArgumentOutOfRangeException arge)
                {
                    Printer.WriteTitle(arge.Message);
                    WriteLine("Coming out");
                }

                catch (System.Exception)
                {
                    Printer.WriteTitle("Enter a valid number");
                    WriteLine("Coming out");
                }
            }
        }

        private static void EventAction(object? sender, EventArgs e)
        {
            Printer.WriteTitle("Coming out");
            //Printer.Ring(500, 1000, 3);
            Printer.WriteTitle("Finished");
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