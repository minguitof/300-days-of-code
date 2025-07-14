using System;
using ConsoleUnderstandVoid;

namespace ConsoleUnderstandVoid
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hola Mundo a la antigua");

            SaludarPersonalizado saludo = new SaludarPersonalizado("Mario", 24);

            saludo.saludar();

            string a = "false";

            bool b = Convert.ToBoolean(a);

            const string c = "false";


            Console.WriteLine(b);
            Console.WriteLine(c);



            //Console.Beep();

            
        }
    }

}
