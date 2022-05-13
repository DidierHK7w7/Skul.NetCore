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