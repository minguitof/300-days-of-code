using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceList
{
    public class ListExerciceOne()
    {
        private string genreName = "Fantasy";
        private List<string> bookTitles = new List<string>()
        {
            "El Señor de los Anillos",
            "Harry Potter y la Piedra Filosofal",
            "El Hobbit",
            "Crónicas de Narnia"
        };

        public static void RunExample()
        {
            Console.WriteLine("\n Ejercicio de Listas");

            ListExerciceOne instance = new ListExerciceOne(); // iniciamos la instancia

            Console.WriteLine($"Genero: {instance.genreName}");
            Console.WriteLine("Libros en la colección ");

            //uso de foreach para reforzar uso
            foreach (var libro in instance.bookTitles)
            {
                Console.WriteLine($"-> {libro}");
            }
            Console.WriteLine($"\nLa cantidad de libros es: {instance.bookTitles.Count}");
        }

    }
}
