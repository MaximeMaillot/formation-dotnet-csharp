// See https://aka.ms/new-console-template for more information
Console.WriteLine("-- Question à choix multiple --");
Console.WriteLine("Quelle est l'instruction qui permet de sortir d'une boucle en C# ?" +
    "\n\ta) quit" +
    "\n\tb) continue" +
    "\n\tc) break" +
    "\n\td) exit");

bool isCorrect;

do
{
    Console.Write("Entrez votre réponse : ");
    string userInput = Console.ReadLine().ToLower();
    if (userInput != "c")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Incorrect !");
        Console.ResetColor();
        isCorrect = false;
        do
        {
            Console.Write("Un nouvel essai ? Oui/Non : ");
            userInput = Console.ReadLine().ToLower();
        } while (userInput != "oui" && userInput != "non");
        if (userInput == "non")
        {
            break;
        }
    } else
    {
        isCorrect = true;
    }
} while (!isCorrect);

if (isCorrect)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Bravo ! C'est la bonne réponse");
    Console.ResetColor();
}
else
{
    Console.WriteLine("Abandon");
}