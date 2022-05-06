using System;
using Skul.Entities;

namespace Skul
{
    public class Program{
        static void Main()
        {
            var school = new School("Platzi Academy", 2012, SchoolTypes.Elementary,
            city:"Bogota", country:"Colombia");

            var course1 = new Course()
            {
                Name = "101"
            };

            var course2 = new Course()
            {
                Name = "201"
            };

            var course3 = new Course()
            {
                Name = "301"
            };

            Console.WriteLine(school);

            Console.WriteLine("-----------------------\n"+course1.Name+","+course1.UniqueId);
            Console.WriteLine(course2.Name+","+course2.UniqueId);  
            //Console.WriteLine($"{course3.Name}, {course3.UniqueId}");  
            Console.WriteLine(course3);  
        }
    }
}