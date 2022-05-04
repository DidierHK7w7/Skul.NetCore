namespace Skul.Entities
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
}