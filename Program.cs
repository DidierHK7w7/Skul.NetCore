using System;
using Skul.Entities;

namespace Skul
{
    public class Program{
        static void Main()
        {
            var school = new School("Platzi Academy", 2012);

            school.Country = "Colombia";
            school.City = "Bogota";
            Console.WriteLine(school.Name);
            
        }
    }
}