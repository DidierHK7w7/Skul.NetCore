using System;
using System.Linq;
using System.Collections.Generic;
using Skul.Entities;
using Skul.Utilities;

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

        public void PrintDictionary(Dictionary<DictionaryKeys, IEnumerable<SchoolBaseObject>> dicc, bool printEval = false)
        {
            foreach (var obj in dicc)
            {
                Printer.WriteTitle(obj.Key.ToString());
                foreach (var key in obj.Value)
                {
                    if (key is Evaluation)
                    {
                        if (printEval)
                        {
                            Console.WriteLine(key);
                        }
                    }
                    else if (key is School)
                    {
                        Console.WriteLine("School: "+key);
                    }
                    else if (key is Student)
                    {
                        Console.WriteLine("Student: "+key.Name);
                    }else
                    {
                        Console.WriteLine(key);
                    }
                }
            }
        }

        public Dictionary<DictionaryKeys, IEnumerable<SchoolBaseObject>> GetObjectDictionary()      //Key string, value IEnumerable, una interfaz generica de lista
        {
            var dictionary = new Dictionary<DictionaryKeys, IEnumerable<SchoolBaseObject>>();
            dictionary.Add(DictionaryKeys.School, new[] {School});   //Agrega un objeto School que contiene un array de Schools
            dictionary.Add(DictionaryKeys.Course, School.Courses.Cast<SchoolBaseObject>());     //Agrega un objeto School que contiene una lista de objetos
            var tempList = new List<Evaluation>();
            var tempSubject = new List<Subject>();
            var tempStudent = new List<Student>();
            foreach (var course in School.Courses)
            {
                tempSubject.AddRange(course.Subjects);
                tempStudent.AddRange(course.Students);
                
                foreach (var student in course.Students)
                {
                    tempList.AddRange(student.EvaluationsList);
                }
            }
            dictionary.Add(DictionaryKeys.Evaluation, tempList.Cast<SchoolBaseObject>());
            dictionary.Add(DictionaryKeys.Subject, tempSubject.Cast<SchoolBaseObject>()); 
            dictionary.Add(DictionaryKeys.Student, tempStudent.Cast<SchoolBaseObject>());
            return dictionary;
        }

        public IReadOnlyList<SchoolBaseObject> GetSchoolObjects(     //Sobrecarga
            bool getEvaluations = true,
            bool getStudents = true,
            bool getSubjects = true,
            bool getCourses = true
            )
        {
            return GetSchoolObjects(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<SchoolBaseObject> GetSchoolObjects(     //Sobrecarga2
            out int evaluationCount,
            bool getEvaluations = true,
            bool getStudents = true,
            bool getSubjects = true,
            bool getCourses = true
            )
        {
            return GetSchoolObjects(out evaluationCount, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<SchoolBaseObject> GetSchoolObjects(     //Sobrecarga3
            out int evaluationCount, out int coursesCount,
            bool getEvaluations = true,
            bool getStudents = true,
            bool getSubjects = true,
            bool getCourses = true
            )
        {
            return GetSchoolObjects(out evaluationCount, out coursesCount, out int dummy, out dummy);
        }

        public IReadOnlyList<SchoolBaseObject> GetSchoolObjects(     //Sobrecarga4
            out int evaluationCount, out int coursesCount, out int subjectCount,
            bool getEvaluations = true,
            bool getStudents = true,
            bool getSubjects = true,
            bool getCourses = true
            )
        {
            return GetSchoolObjects(out evaluationCount, out coursesCount, out subjectCount, out int dummy);
        }

        public IReadOnlyList<SchoolBaseObject> GetSchoolObjects(     //Devuelve lista y conteo de evaluaciones(int), IReadOnlyList lista de solo lectura
            out int evaluationCount,    //Parametros de salida
            out int coursesCount,
            out int subjectCount,
            out int studentCount,
            bool getEvaluations = true,     //Valores opcionales van al final
            bool getStudents = true,
            bool getSubjects = true,
            bool getCourses = true
            )
        {
            evaluationCount = subjectCount = studentCount = 0;  //Asignacion multiple

            var listObj = new List<SchoolBaseObject>();
            listObj.Add(School);

            if (getCourses)
            {
                listObj.AddRange(School.Courses);
            }
            coursesCount = School.Courses.Count;
            foreach (var course in School.Courses)
            {
                subjectCount += course.Subjects.Count;
                studentCount += course.Students.Count;

                if (getSubjects)
                {
                    listObj.AddRange(course.Subjects);
                }

                if (getStudents)
                {
                    listObj.AddRange(course.Students);
                }
                

                if (getEvaluations)
                {
                    foreach (var student in course.Students)
                    {
                        listObj.AddRange(student.EvaluationsList);
                        evaluationCount += student.EvaluationsList.Count();
                    }
                }
            }
            return listObj.AsReadOnly();    //Retorna lista de solo lectura
        }


    #region Data loading methods

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
    #endregion
}