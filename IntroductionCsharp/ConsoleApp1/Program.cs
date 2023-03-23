Console.WriteLine("--- Les tables de multiplication ---");
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"\nTable de {i} : ");
    for (int j = 1; j <= 10; j++)
    {
        Console.WriteLine($"\t - {i} * {j} = {i*j}");
    }
}
