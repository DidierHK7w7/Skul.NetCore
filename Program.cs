using System;
using Skul.Entities;

namespace Skul
{
    public class Program{
        static void Main()
        {
            var mySchool = new School();
            mySchool.name = "Bocchi";
            mySchool.address = "Groove Street, Los Santos";
            mySchool.foundationYear = 2012;

            Console.WriteLine("Ringing");
            mySchool.Ring();
            
        }
    }
}