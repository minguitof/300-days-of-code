// Create a list of strings by using a
// collection initializer.
List<string> salmons = ["chinook", "coho", "pink", "sockeye"];

// Iterate through the list.
foreach (var salmon in salmons)
{
    Console.Write($"-> { salmon } \n");
}

salmons.Remove("coho");


Console.WriteLine("Uso de Index - i");
// Iterate using the index:
for (var index = 0; index < salmons.Count; index++)
{
    Console.Write(salmons[index] + " ");
}


// Otro ejemplo usando list para eliminar elementos con base a formula 

List<int> numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];


// Remove odd numbers.
for (var index = numbers.Count - 1; index >= 0; index--)
{
    //Console.WriteLine(numbers.Count);
    if (numbers[index] % 2 == 1)
    {
        //Console.WriteLine(numbers.Count);
        // Remove the element by specifying
        // the zero-based index in the list.
        numbers.RemoveAt(index);
    }
}


numbers.ForEach(
    number => Console.Write(number + " "));