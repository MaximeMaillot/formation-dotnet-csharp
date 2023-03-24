Console.WriteLine("--- Est pair ? Est impair ?");
bool isCorrect;
int nbNbr;
do
{
    Console.Write("Combien de nombres contiendra le tableau ? :");
    isCorrect = (int.TryParse(Console.ReadLine(), out nbNbr) && nbNbr > 0);
} while (!isCorrect);

Console.WriteLine("Affectation automatique des valeurs...\n");
int[] nombres = new int[nbNbr];
Random random = new();
for (int i = 0; i < nbNbr; i++)
{
    nombres[i] = random.Next(1,51);
}
Console.WriteLine("Verification des valeurs du tableau :");
for (int i = 0; i < nbNbr; i++)
{
    if (nombres[i] % 2 == 0)
    {
        Console.WriteLine($"\tLe nombre {nombres[i]} est pair");
    } else
    {
        Console.WriteLine($"\tLe nombre {nombres[i]} est impair");
    }
}
