using System;
using Skul.Entities;

namespace Skul
{
    public class Program{
        static void Main()
        {
            var school = new School("Platzi Academy", 2012, SchoolTypes.Elementary,
            city:"Bogota", country:"Colombia");

            Console.WriteLine(school);
            
        }
    }
}