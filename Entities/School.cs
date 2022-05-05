namespace Skul.Entities
{
    public class School
    {
        string name;
        //propiedad Name encapsula a la variable name
        public string Name
        {   
            //get retorna nombre, set asigna nombre
            get => "Copy: "+name;
            set => name = value.ToUpper();
        }
        public int CreationYear{get; set;}
        public string Country { get; set; }
        public string City { get; set; }

        public SchoolTypes SchoolType { get; set; }


        public School(string name, int year) =>(Name, CreationYear) = (name, year);     //Metodo constructor con lambda, ()=() asignacion de tuplas

        public School(string name, int year, SchoolTypes type, string country="", string city = "")     //Segundo constructor
        {
            (Name, CreationYear) = (name, year);
            Country = country;
            City = city;
        }
        
        public override string ToString() => $"Name: \"{Name}\", Tipe: {SchoolType}\nCountry: {Country}, City: {City}";     //{System.Environment.NewLine} equivale a \n
        
    }
}