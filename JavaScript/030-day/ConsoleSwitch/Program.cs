using System;
public interface IAnimal
{
    void HacerSonido();
}

public class Perro : IAnimal
{
    public void HacerSonido()
    {
        Console.WriteLine("Guau guau!");
    }
}

public class Gato : IAnimal
{
    public void HacerSonido()
    {
        Console.WriteLine("Miau!");
    }
}

class Program
{
    static void Main()
    {
        List<IAnimal> animales = new List<IAnimal> { new Perro(), new Gato() };

        foreach (IAnimal animal in animales)
        {
            animal.HacerSonido(); // Llama al método correcto dependiendo del tipo
        }

    }
}