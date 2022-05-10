using System;
using System.Linq;
using System.Collections.Generic;
using Skul.Entities;

namespace Skul.App
{
    public class SchoolEngine           //sealed, modificador de acceso, se puede crear u=instancias pero no heredar, abstract hereda pero no crea instancia
    {
        public School School { get; set; }
        public SchoolEngine()
        {
            
        }

        public void InitializeValues()
        {
            School = new School("Platzi Academy", 2012, SchoolType.Elementary,
            city:"Bogota", country:"Colombia");

            LoadCourses();
            LoadSubjects();
            LoadEvaluations();
        }

        private void LoadCourses()      //Cargar cursos
        {
            School.Courses = new List<Course>(){   //Lista generica
                new Course(){Name = "101", Working = WorkingType.Morning},     //Inicializacion
                new Course(){Name = "201", Working = WorkingType.Morning},
                new Course(){Name = "301", Working = WorkingType.Morning},
                new Course(){Name = "401", Working = WorkingType.Afternoon},     //Inicializacion
                new Course(){Name = "501", Working = WorkingType.Afternoon}
            };

            Random rnd = new Random();
            foreach (var curso in School.Courses)
            {
                int randomAmount = rnd.Next(5,20);      //Numeros random entre 5 y 20
                curso.Students = RandomStudentGenerator(randomAmount);
            }
        }

        private void LoadSubjects()     //Cargar Asignaturas
        {
            foreach (var course in School.Courses)
            {
                var listSubjects = new List<Subject>(){
                    new Subject{Name = "Math"},
                    new Subject{Name = "English"},
                    new Subject{Name = "Videogames"},
                    new Subject{Name = "Music"},
                    new Subject{Name = "Web applications development"}
                };

                course.Subjects = listSubjects;
            }
        }

        private List<Student> RandomStudentGenerator(int amount)
        {
            string[] firstName = {"Harry", "Ross", "Bruce", "Cook", "Carolyn", "Morgan", "Ran"};
            string[] middleName = {"Albert", "Walker", "Randy", "Reed", "Larry","Barnes", "Bocchi"};
            string[] lastName = {"Lois", "Wilson", "Jesse", "Campbell", "Ernest", "Rogers", "Mitake", "Hikawa"};

            //Producto cartesiano con LinQ
            var studentList = from n1 in firstName
                              from n2 in middleName
                              from a1 in lastName
                              select new Student{Name=$"{n1} {n2} {a1}"};
            return studentList.OrderBy((stn)=> stn.UniqueId).Take(amount).ToList();     //El delegado Obrder By ordena por el ide unico y Take trunca la lista de n alumnos a un numero especifico
        }

        private void LoadEvaluations()
        {
            foreach(var course in School.Courses)
            {
                foreach(var subject in course.Subjects)
                {
                    foreach(var student in course.Students)
                    {
                        Random rnd = new Random();      //Semilla System.Environment.TickCount, es el numero en milisegundos que ha pasado al arrancar el OS
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluation(){
                                Subject = subject,
                                Name = $"{subject.Name} Ev#{i+1}",
                                Grade = (float)(5 * rnd.NextDouble()),  //Cast float
                                Student = student
                            };
                            student.EvaluationsList.Add(ev);
                        }
                    }
                }
            }
        }
    }
}