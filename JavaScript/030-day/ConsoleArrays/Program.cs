using System;

class ExercicesArrays
{
    private double[] numeros = { 1, 2, 3, 4, 5 };

    private double[] segundoArray = new double[10];

    public void MostrarArreglos(double[] numeros)
    {
        foreach (var numero in numeros)
        {
            Console.WriteLine(numero);
        }
    }

    public void Ejecutar()
    {
        MostrarArreglos(numeros);
    }

    public void MostrarArregloDos()
    {
        foreach (var numero in segundoArray)
        {
            Console.WriteLine(numero);
        }
    }

    public void LlenarSegundoArray()
    {
        for (int i = 0; i < segundoArray.Length; i++)
        {
            segundoArray[i] = i + 1;
        }
    }

    public void SetValorEnSegundoArray(int indice, double valor)
    {
        if (indice >= 0 && indice < segundoArray.Length)
            segundoArray[indice] = valor;
    }

}


class Program
{
    static void Main()
    { 
        ExercicesArrays ea = new ExercicesArrays();

        //ea.Ejecutar();

        ea.LlenarSegundoArray();

        ea.MostrarArregloDos();

    }
}