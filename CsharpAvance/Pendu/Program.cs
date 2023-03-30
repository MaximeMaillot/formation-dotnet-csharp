using Pendus.Classes;

void WriteInColor(string msg, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(msg);
    Console.ResetColor();
};


Console.WriteLine("=== Paramètre de partie ===");
Console.Write("Voulez-vous un nombre de chances spécifique (10 par défaut) ? y/n ");
string choice = Console.ReadLine().Trim().ToLower();

int nbEssais = 10;
if (choice == "y")
{
    bool isCorrect;
    do
    {
        Console.Write("Combien voulez-vous de chances ? ");
        isCorrect = int.TryParse(Console.ReadLine(), out nbEssais);
        if (nbEssais < 1)
        {
            Console.WriteLine("Entrez un nombre de chance correct supérieur à 0");
        }
    } while (!isCorrect);
}
Pendu pendu = new Pendu(nbEssais);

bool hasWin;
do
{
    //Console.Clear();
    Console.WriteLine($"Le mot à trouver :  {pendu.Masque}");
    Console.WriteLine($"Il vous reste {pendu.NbEssais} chances");
    bool isCorrect;
    char letter;
    do
    {
        Console.Write("Veuillez saisir une lettre : ");
        isCorrect = char.TryParse(Console.ReadLine(), out letter);
    } while (!isCorrect);
    pendu.TestChar(letter);
    hasWin = pendu.TestWin();
} while (!hasWin && pendu.NbEssais > 0);

if (hasWin)
{
    WriteInColor("Gagné", ConsoleColor.Green);
} else
{
    WriteInColor("Perdu", ConsoleColor.Red);
}