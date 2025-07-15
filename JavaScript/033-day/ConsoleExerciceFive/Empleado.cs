using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleExerciceFive;

namespace ConsoleExerciceFive
{
    class Empleado
    {
        // propiedades
        public string NombreCompleto {  get; set; }
        public int IdEmpleado { get; set; }
        public decimal Salario { get; set; }
        public string Cargo { get; set; }

        //id para aumento
        private static int _siguienteId = 1;

        // inicio del constructor
        public Empleado(string nombreCompleto, decimal salario, string cargo)
        { 
            NombreCompleto = nombreCompleto;

            IdEmpleado = _siguienteId;
            _siguienteId++;

            Salario = salario;
            Cargo = cargo;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Your Name is: {NombreCompleto}");
            Console.WriteLine($"Your IDEmpleado is: {IdEmpleado}");
            Console.WriteLine($"Your Salary is: {Salario:C}");
            Console.WriteLine($"Your Cargo is: {Cargo}");
            Console.WriteLine("-------------------------------------");
        }


    }
}
