using System;
using Skul.Entities;

namespace Skul
{
    public class Program
    {
        static void Main()
        {
            var school = new School("Platzi Academy", 2012, SchoolTypes.Elementary,
            city:"Bogota", country:"Colombia");

            var courseArray = new Course[3];
            courseArray[0] = new Course(){Name = "101"};
            courseArray[1] = new Course(){Name = "201"};
            courseArray[2] = new Course(){Name = "301"};


            Console.WriteLine(school);
            Console.WriteLine("---------------------");

            PrintCourses(courseArray);
        }
        
        private static void PrintCourses(Course[] courseArray)
        {
            //Formas de imprimir un array

            foreach (var item in courseArray)
            {
                    Console.WriteLine($"Nombre: {item.Name},    id: {item.UniqueId}");
            }


            /*int count = 0;
            while (count < courseArray.Length)
            {
                Console.WriteLine($"Nombre: {courseArray[count].Name}, id: {courseArray[count].UniqueId}");
                count++;
            }*/


            /*int count = 0;
            do
            {
                Console.WriteLine($"Nombre: {courseArray[count].Name}, id: {courseArray[count].UniqueId}");
                count++;
            } while (count++ < courseArray.Length);*/


            /*for (int i = 0; i < courseArray.Length; i++)
            {
                Console.WriteLine($"Nombre: {courseArray[i].Name}, id: {courseArray[i].UniqueId}");
            }*/
        }
    }
}