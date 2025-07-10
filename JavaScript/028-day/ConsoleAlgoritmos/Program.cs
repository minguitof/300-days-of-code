var num1 = 2;
var num2 = 3;

var res = num1 + num2;

Console.WriteLine("#1 Ejercicio");
Console.WriteLine("================================================================================\n");
Console.WriteLine($"La suma da: {res}\n");

Console.WriteLine("#2 Ejercicio");
Console.WriteLine("================================================================================\n");

int nnum1 = 2;
double nnum2 = 3.5;

double resultado =  nnum1 + nnum2;

Console.WriteLine($"Su valor de la suma con double y entero es: {resultado}\n");


Console.WriteLine("#3 Ejercicio");
Console.WriteLine("================================================================================\n");


int x = 5;
double y = 2.5;
double resultado3 = x + y; // C# convierte int a double automáticamente (implícito)

int entero = (int)y; // conversión explícita (pierdes decimales)

Console.WriteLine($"Valor de la variable resultado3: {resultado3}\n");
Console.WriteLine($"Valor de Y es: {y} y con int(y) se pierde decimales de la variable entero: {entero}\n");


Console.WriteLine("#4 Ejercicio");
Console.WriteLine("================================================================================\n");

int a = 10;
int b = 3;


Console.WriteLine($"Los valores de `a` es: {a} y los de `b` es: {b}\n");
Console.WriteLine($"Resta: {a - b}");  // resta
Console.WriteLine($"Multiplicación: {a * b}");  // multiplicación
Console.WriteLine($"División: {a / b}");  // división entera
Console.WriteLine($"Modulo (resto) {a % b}\n");  // módulo (resto)

Console.WriteLine("#5 Ejercicio");
Console.WriteLine("================================================================================\n");


bool mayor = a > b;
bool igual = a == b;
bool diferente = a != b;


Console.WriteLine($"Los valores de `a` es: {a} y los de `b` es: {b}\n");
Console.WriteLine($"Aca es falso ya que {a} es mayor que {b} y no son iguales AND por lo cual seria: {mayor && igual}"); // AND
Console.WriteLine($"Aca es verdadero ya que {a} es mayor que {b} lo cual al usar OR si se cumple alguna de las dos condiciones: {mayor || igual}"); // OR
Console.WriteLine($"Aca es falso ya que {a} es mayor que {b} por lo cual al usar ! estoy pidiendo la negación entonces seria: {!mayor}");         // NOT


Console.WriteLine("#6 Ejercicio");
Console.WriteLine("================================================================================\n");

Console.Write("Ingresa el primer número: ");
//int exercisenum1 = int.Parse(Console.ReadLine());
int exercisenum1 = 6;

Console.Write("Ingresa el segundo número: ");
//int exercisenum2 = int.Parse(Console.ReadLine());
int exercisenum2 = 5;

int exercisesuma = exercisenum1 + exercisenum2;

Console.WriteLine($"La suma es: {exercisesuma}");
Console.WriteLine($"La resta es: {exercisenum1 - exercisenum2}");
Console.WriteLine($"La división es: {exercisenum1 / exercisenum2}");
Console.WriteLine($"La multiplicación es: {exercisenum1 * exercisenum2}");
Console.WriteLine($"El residuo es: {exercisenum1 % exercisenum2}\n");


Console.WriteLine("#7 Ejercicio");
Console.WriteLine("================================================================================\n");

bool hambre = true;

if (hambre == true)
{
    Console.WriteLine("Voy a comer\n");
}
else
{
    Console.WriteLine("No tengo hambre\n");
}


Console.WriteLine("#8 Ejercicio");
Console.WriteLine("================================================================================\n");

Console.Write("Usuario ingrese su edad: ");
//int exercice8num1 = int.Parse(Console.ReadLine());
int exercice8num1 = 30;


if (exercice8num1 >= 18 && exercice8num1 <= 99)
{
    Console.WriteLine($"Eres mayor de edad tienes {exercice8num1}\n");
}
else if (exercice8num1 <= 0 )
{
    Console.WriteLine("No se permite numeros negativos\n");
}
else if (exercice8num1 >= 100)
{
    Console.WriteLine("¿Aun estas con vida?\n");
}
else
{
    Console.WriteLine($"Aun no eres mayor de edad ya que tienes {exercice8num1}\n");
}


Console.WriteLine("#9 Ejercicio");
Console.WriteLine("================================================================================\n");


Console.WriteLine("Ingrese la nota de 1 a 100");
//int exercice9num = int.Parse(Console.ReadLine());
int exercice9num = 90;


if (exercice9num >= 90 && exercice9num <= 100)
{
    Console.WriteLine("Excelente\n");
}
else if (exercice9num >= 80 && exercice9num < 90)
{
    Console.WriteLine("Muy bien\n");
}
else if (exercice9num >= 70 && exercice9num < 80)
{
    Console.WriteLine("Bien\n");
}
else if (exercice9num >= 60 && exercice9num < 70)
{
    Console.WriteLine("Pasaste raspando\n");
}
else if (exercice9num >= 0 && exercice9num < 60)
{
    Console.WriteLine("Reprobado\n");
}
else
{
    Console.WriteLine("Nota inválida\n");
}


Console.WriteLine("#10 Ejercicio");
Console.WriteLine("================================================================================\n");

int intentos = 0;
string exercice10contrasena = "";

while (exercice10contrasena != "12345" && intentos < 3)
{
    Console.Write("Escribe la contraseña: ");
    //exercice10contrasena = Console.ReadLine();
    exercice10contrasena = "12345";
    intentos++;

    if (exercice10contrasena != "12345")
        Console.WriteLine("Incorrecto. Intenta de nuevo.\n");
}

if (exercice10contrasena == "12345")
{
    Console.WriteLine("¡Acceso Concedido!\n");
}
else
{
    Console.WriteLine("Demasiados intentos. Acceso denegado.\n");
}


Console.WriteLine("#11 Ejercicio");
Console.WriteLine("================================================================================\n");


int exercice11opcion = 6;
int exercice11num1 = 0;
int exercice11num2 = 0;


while (exercice11opcion != 6)
{
    Console.WriteLine("\n===MENU===");
    Console.WriteLine("1. - Suma");
    Console.WriteLine("2. - Resta");
    Console.WriteLine("3. - Multiplicar");
    Console.WriteLine("4. - Dividir");
    Console.WriteLine("5. - Residuo");
    Console.WriteLine("6. - Salir\n");

    Console.WriteLine("Seleccione la opción a consultar");
    exercice11opcion = int.Parse(Console.ReadLine());

    if (exercice11opcion == 1)
    {
        Console.WriteLine("Elegistes una Suma\n");
        Console.WriteLine("Ingresa el primer número a sumar");
        exercice11num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("\nIngresa el primer número a sumar");
        exercice11num2 = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nEl resultado de la suma es: {exercice11num1 + exercice11num2}");
    }
    else if (exercice11opcion == 2)
    {
        Console.WriteLine("Elegistes una Resta\n");
        Console.WriteLine("Ingresa el primer número a restar");
        exercice11num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("\nIngresa el segundo número a restar");
        exercice11num2 = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nEl resultado de la resta es: {exercice11num1 - exercice11num2}");
    }
    else if (exercice11opcion == 3)
    {
        Console.WriteLine("Elegistes una Multiplicación\n");
        Console.WriteLine("Ingresa el primer número a multiplicar");
        exercice11num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("\nIngresa el segundo número a multiplicar");
        exercice11num2 = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nEl resultado de la multiplicación es: {exercice11num1 * exercice11num2}");
    }
    else if (exercice11opcion == 4)
    {
        Console.WriteLine("Elegistes una División\n");
        Console.WriteLine("Ingresa el primer número a Dividir");
        exercice11num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("\nIngresa el segundo número a Dividir");
        exercice11num2 = int.Parse(Console.ReadLine());
        if (exercice11num2 == 0)
        {
            Console.WriteLine("No se puede dividir entre 0.");
        }
        else
        {
            Console.WriteLine($"\nEl resultado de la División es: {exercice11num1 / exercice11num2}");
        }
    }
    else if (exercice11opcion == 5)
    {
        Console.WriteLine("Elegistes un Residuo de la división\n");
        Console.WriteLine("Ingresa el primer número a Dividir");
        exercice11num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("\nIngresa el segundo número a Dividir");
        exercice11num2 = int.Parse(Console.ReadLine());

        if (exercice11num2 == 0)
        {
            Console.WriteLine("No se puede dividir entre 0.");
        }
        else
        {
            Console.WriteLine($"\nEl resultado de la División es: {exercice11num1 % exercice11num2}");
        }
    }
    else
        Console.WriteLine("Opción no valida.\n");
}


Console.WriteLine("\n#12 Ejercicio - Integrando funciones basicas");
Console.WriteLine("================================================================================\n");



int exercice12opcion = 0;
int exercice12num1 = 0;
int exercice12num2 = 0;


int PedirNumero(string mensaje)
{
    Console.Write(mensaje);
    return int.Parse(Console.ReadLine());
}


while (exercice12opcion != 6)
{
    Console.WriteLine("\n===MENU===");
    Console.WriteLine("1. - Suma");
    Console.WriteLine("2. - Resta");
    Console.WriteLine("3. - Multiplicar");
    Console.WriteLine("4. - Dividir");
    Console.WriteLine("5. - Residuo");
    Console.WriteLine("6. - Salir\n");

    Console.WriteLine("Seleccione la opción a consultar");
    exercice12opcion = int.Parse(Console.ReadLine());

    if (exercice12opcion == 1)
    {
        Console.WriteLine("Seleccionastes una suma\n");
        exercice11num1 = PedirNumero("\nIngresa el primer número a sumar ");
        exercice11num2 = PedirNumero("\nIngresa el primer número a sumar ");

        Console.WriteLine($"\nEl resultado de la suma es: {exercice11num1 + exercice11num2}");
    }
    else if (exercice12opcion == 2)
    {
        Console.WriteLine("Elegistes una Resta\n");

        exercice11num1 = PedirNumero("\nIngresa el primer número a restar ");
        exercice11num2 = PedirNumero("\nIngresa el segundo número a restar ");

        Console.WriteLine($"\nEl resultado de la resta es: {exercice11num1 - exercice11num2}");
    }
    else if (exercice12opcion == 3)
    {
        Console.WriteLine("Elegistes una Multiplicación\n");

        exercice11num1 = PedirNumero("\nIngresa el primer número a multiplicar ");
        exercice11num2 = PedirNumero("\nIngresa el segundo número a multiplicar ");

        Console.WriteLine($"\nEl resultado de la multiplicación es: {exercice11num1 * exercice11num2}");
    }
    else if (exercice12opcion == 4)
    {
        Console.WriteLine("Elegistes una División\n");

        exercice11num1 = PedirNumero("\nIngresa el primer número a Dividir ");
        exercice11num2 = PedirNumero("\nIngresa el segundo número a Dividir ");

        if (exercice11num2 == 0)
        {
            Console.WriteLine("No se puede dividir entre 0.");
        }
        else
        {
            Console.WriteLine($"\nEl resultado de la División es: {exercice11num1 / exercice11num2}");
        }
    }
    else if (exercice12opcion == 5)
    {
        Console.WriteLine("Elegistes un Residuo de la división\n");

        exercice11num1 = PedirNumero("\nIngresa el primer número a Dividir ");
        exercice11num2 = PedirNumero("\nIngresa el segundo número a Dividir ");

        if (exercice11num2 == 0)
        {
            Console.WriteLine("No se puede dividir entre 0.");
        }
        else
        {
            Console.WriteLine($"\nEl resultado de la División es: {exercice11num1 % exercice11num2}");
        }
    }
    else
        Console.WriteLine("Opción no valida.\n");
}