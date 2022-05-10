using System.Collections.Generic;
using Skul.Utilities;

namespace Skul.Entities
{
    public class School : SchoolBaseObject, IPlace
    {
        public int CreationYear{get; set;}
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public SchoolType SchoolType { get; set; }

        public List<Course> Courses { get; set; }   //Lista generica


        public School(string name, int year) =>(Name, CreationYear) = (name, year);     //Metodo constructor con lambda, ()=() asignacion de tuplas

        public School(string name, int year, SchoolType type, string country="", string city = "")     //Segundo constructor
        {
            (Name, CreationYear) = (name, year);
            Country = country;
            City = city;
        }
        
        public override string ToString() => $"Name: \"{Name}\", Tipe: {SchoolType}\nCountry: {Country}, City: {City}";     //{System.Environment.NewLine} equivale a \n

        public void CleanPlace()
        {
            Printer.DrawLine();
            Console.WriteLine("Cleaning school...");
            
            foreach (var course in Courses)
            {
                course.CleanPlace();
            }
            Printer.WriteTitle($"School {Name} clean");
            Printer.Ring(500, amount:3);
        }
    }
}