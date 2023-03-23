Console.WriteLine("--- Le nombre est-il divisible par ? ---");

Console.Write("Entrez un chiffre/nombre entier : ");
int dividend = Convert.ToInt32(Console.ReadLine());
Console.Write("Entrez le chiffre/nombre diviseur : ");
int divisor = Convert.ToInt32(Console.ReadLine());

string type = dividend > 9 ? "nombre" : "chiffre";

if ((dividend % divisor) == 0)
{
    Console.WriteLine("le " + (dividend > 9 ? "nombre" : "chiffre") + $" est divisible par {divisor}");
}
else
{
    Console.WriteLine($"le {type} n'est pas divisible par {divisor}");
}

