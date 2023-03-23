Console.WriteLine("-- Trouver le nombre mystère ---\n");
Random random = new Random();
int nbMystere = random.Next(1,50);
int userInput = 0;
int cpt = 0;

while (nbMystere != userInput)
{
    Console.ResetColor();
    do
    {
        Console.Write("Veuillez saisir un nombre entre 1 et 50 : ");
        int.TryParse(Console.ReadLine(), out userInput);
    } while (userInput < 1 || userInput > 50);
    Console.ForegroundColor = ConsoleColor.Red;
    if (userInput > nbMystere)
    {
        Console.WriteLine("Le nombre mystère est plus petit");
    } else if (userInput < nbMystere)
    {
        Console.WriteLine("Le nombre mystère est plus grand");
    }
    cpt++;
}
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Bravo ! Vous avez trouvé le nombre mystère !");
Console.WriteLine($"Vous avez trouvé en {cpt} coups.");
