namespace Skul.Entities
{
    /*
    Las estructuras son un tipo de clase que pueden ser usadas para almacenar objetos que directamente contienen datos,
    uno de sus usos es pequeñas estructuras de datos y para los diccionarios como es el caso de la clase.
    Estas son algunas de las características de las estructuras:

    • No pueden tener un constructor sin parámetros.
    • Guardan los valores y no la referencia a la memoria como es el caso de las clases.
    • Pueden ser instanciadas sin usar new.
    • No pueden heredar de otras estructuras o clases pero si implementar interfaces.
    • Los modificadores abstract y sealed no pueden usarse en ellas.
    • Se les puede asignar null como valor.
    */

    // public struct DictionaryKeys
    // {
    //     public const string SCHOOL = "School";
    //     public const string COURSES = "Courses";
    //     public const string SUBJECTS = "Subjects";
    //     public const string STUDENTS = "Students";
    //     public const string EVALUATIONS = "Evaluations";
    // }

    public enum DictionaryKeys      //Enumeracion
    {
        
        School,
        Course,
        Subject,
        Student,
        Evaluation
    }
}