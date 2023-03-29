using Pendus.Classes;

Console.WriteLine("=== Paramètre de partie ===");
Console.Write("Voulez-vous un nombre d'essais spécifique (10 par défaut) ? ");
string choice = Console.ReadLine().Trim().ToLower();

if (choice == "y")
{
    bool isCorrect;
    int nbEssais;
    do
    {
        Console.Write("Combien voulez-vous d'essais ? ");
        isCorrect = int.TryParse(Console.ReadLine(), out nbEssais);
        if (nbEssais < 1)
        {
            Console.WriteLine("Entrez un nombre d'essai correct supérieur à 0");
        }
    } while (!isCorrect);
}
Pendu pendu = new Pendu();

bool hasWin = false;
do
{
    Console.WriteLine($"Le mot à trouver :  {pendu.Masque}");
    Console.WriteLine($"Il vous reste {pendu.NbEssais}");
    bool isCorrect;
    char letter;
    do
    {
        Console.Write("Veuillez saisir une lettre : ");
        isCorrect = char.TryParse(Console.ReadLine(), out letter);
    } while (!isCorrect);
    pendu.TestChar(letter);
    hasWin = pendu.TestWin();
    Console.WriteLine("hasWin : " + hasWin + " | " + pendu.NbEssais);
} while (!hasWin && pendu.NbEssais > 0);

if (hasWin)
{
    Console.WriteLine("Gagné");
} else
{
    Console.WriteLine("Perdu");
}