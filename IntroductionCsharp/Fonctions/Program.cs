
static string ConcatenateWithEmptySpace(string str1, string str2) 
{
    return $"{str1} {str2}";
}
Console.WriteLine("ConcatenateWithEmptySpace(John, Doe)");
Console.WriteLine(ConcatenateWithEmptySpace("John", "Doe"));
Console.WriteLine();

static int Substract(int a, int b)
{
    Console.WriteLine($"Je soustrait {a} et {b}");
    return a - b;
}

Console.WriteLine("Substract(2,1)");
int a = Substract(2, 1);
Console.WriteLine("Result : " + a);
Console.WriteLine();


static void ShowTime(string time = "12h00") 
{
    Console.WriteLine($"Il est {time}");
}

Console.WriteLine("ShowTime()");
ShowTime();
Console.WriteLine("ShowTime(14h00)");
ShowTime("14h00");
Console.WriteLine();

static int CountA(string str)
{
    return str.Count(charOfStr => charOfStr == 'a');
}

Console.WriteLine("CountA(aaaaa)");
Console.WriteLine(CountA("aaaaa"));
Console.WriteLine("CountA(afzbefkzj");
Console.WriteLine(CountA("afzbefkzj"));
Console.WriteLine("CountA(girgnk)");
Console.WriteLine(CountA("girgnk"));
Console.WriteLine();

static (int, int, float, int) operation(int nb1, int nb2)
{
    return (nb1 + nb2, nb1 - nb2, nb1 / (float)nb2, nb1 * nb2);
}

Console.WriteLine("operation(10, 5)");
(int somme, int difference, float quotient, int produit) result = operation(10, 5);
Console.WriteLine(result);
Console.WriteLine();