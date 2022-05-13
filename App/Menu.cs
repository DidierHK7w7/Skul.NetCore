using System;
using System.Collections.Generic;
using Skul.Entities;
using Skul.App;
using Skul.Utilities;
using static System.Console;
namespace Skul.App
{
    public class Menu
    {
        public SchoolEngine Engine { get; set; }
        public Reporter Reporter { get; set; }

        public void ReporterMenu()
        {
            Engine = new SchoolEngine();
            Engine.InitializeValues();
            Reporter = new Reporter(Engine.GetObjectDictionary());

            WriteLine("Ingrese una opcion\n1) Lista de evaluaciones\n2) Lista de asignaturas\n3) Evaluaciones por asignatura\n4) Top mejores promedios\n5) Salir");
            int option = Convert.ToInt16(ReadLine());
            switch (option)
            {
                case 1:
                    MenuGetEvaluationsList();
                    break;
                case 2:
                    MenuGetSubjectsList();
                    break;
                case 3:
                    MenuGetAssessmentDicBySubject();
                    break;
                case 4:
                    MenuGetAverageStudentBySubject();
                    break;
                case 5:
                    AppDomain.CurrentDomain.ProcessExit += EventAction;     //Activa evento cuando termine la ejecucion
                    break;
                default:
                    AppDomain.CurrentDomain.ProcessExit += EventAction;
                    break;
            }
            //MenuGetEvaluationsList();
            //MenuGetSubjectsList();
            //MenuGetAssessmentDicBySubject();
            //MenuTopAveragesSubject();
            //MenuGetAverageStudentBySubject();
        }

        private void MenuGetEvaluationsList(){  //Lista evaluaciones
            var evaluationsList = Reporter.GetEvaluationsList();
            foreach (var item in evaluationsList)
            {
                WriteLine($"Evaluation name: {item.Name},  Student: {item.Student.Name},  Subject: {item.Subject.Name},  Grade: {item.Grade}");
            }
        }

        private void MenuGetSubjectsList(){  //lista asignatura
            var subjectList = Reporter.GetSubjectsList();
            foreach (var item in subjectList)
            {
                WriteLine($"Subjects: ",item);
            }
        }

        private void MenuGetAssessmentDicBySubject(){  // lista evaluaciones por asignaturas
            var evaluationsListBySubject = Reporter.GetAssessmentDicBySubject();
            foreach (var evaBySub in evaluationsListBySubject)
            {
                foreach (var item in evaBySub.Value)
                {
                    WriteLine($"Evaluation name: {item.Name},  Student: {item.Student.Name},  Subject: {item.Subject.Name},  Grade: {item.Grade}");
                }
            }
        }

        private void MenuGetAverageStudentBySubject(){  //lista notas promedio por asignatura
            var averagesBySubject = Reporter.GetAverageStudentBySubject();
            foreach (var evaBySub in averagesBySubject)
            {
                foreach (var item in evaBySub.Value)
                {
                    WriteLine(item);
                }
            }
        }

        private void MenuTopAveragesSubject(){  //lista top mejores notas
            var topAveragesSubject = Reporter.TopAveragesSubject(5);

            foreach (var TopGradesBySub in topAveragesSubject)
            {
                foreach (var item in TopGradesBySub.Value)
                {
                    WriteLine($"Student: {item.studentName},  Average grade: {item.averageStudent}");
                }
            }
        }

        private static void EventAction(object? sender, EventArgs e)
        {
            Printer.WriteTitle("Coming out");
            //Printer.Ring(500, 1000, 3);
            Printer.WriteTitle("Finished");
        }
    }
}