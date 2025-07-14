using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUnderstandVoid
{
    public class SaludarPersonalizado
    {

        public string Name { get; set; }
        public int Edad {  get; set; }

        public SaludarPersonalizado(string name, int edad) 
        {
            Name = name;
            Edad = edad;
        }


        public void saludar()
        {
            Console.WriteLine($"Hola {Name} bienvenido al curso de desarrollo, tienes {Edad}");
        }
    }
}
