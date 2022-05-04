using System;
namespace Skul
{
    public class School
    {
        public string name;
        public string address;
        public int foundationYear;
        string ceo;

        public void Ring()
        {
            Console.Beep(1000, 3000);     //Pitido de 10000 hz a 3000ms
        }
    }

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