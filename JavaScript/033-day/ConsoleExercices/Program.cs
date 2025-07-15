class Program
{ 
    static void Main()
    {
        Random random = new Random();

        int num1 = random.Next(1, 10);
        double num2 = random.Next(1, 10);


        Console.WriteLine(num1);
        Console.WriteLine(num2);


        Console.WriteLine("Hola bro, nuevamente al ruedo");
    }
}