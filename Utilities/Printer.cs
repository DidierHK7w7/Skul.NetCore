using System;
using static System.Console;
namespace Skul.Utilities
{
    public static class Printer
    {
        public static void DrawLine(int tam = 20)
        {   
            //PadLeft Rellena la cadena con un caracter el numero de veces que se pase como parametro
            WriteLine("".PadLeft(tam,'-'));
        }

        public static void WriteTitle(string title)
        {   
            var LineLen = title.Length + 4;
            DrawLine(LineLen);
            WriteLine($"| {title} |");
            DrawLine(LineLen);
        }

        public static void Ring(int hz = 1000, int time = 500, int amount = 1)
        {
            while (amount-- > 0)
            {
                Beep(hz, time);
            }
        }
    }
}