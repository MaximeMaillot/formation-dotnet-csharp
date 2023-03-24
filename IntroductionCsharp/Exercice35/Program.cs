Console.WriteLine("Gestion des contacts");
bool isCorrect;
int contactLength;
do
{
    Console.Write("Merci de saisir le nombre de contact : ");
    isCorrect = int.TryParse(Console.ReadLine(), out contactLength) && contactLength > 0;
} while (!isCorrect);

Console.Clear();

int choice;
string[] contacts = new string[contactLength];

do
{
    Console.WriteLine("----- Ma liste de contacts -----");
    Console.WriteLine("1---- Saisir des contacts");
    Console.WriteLine("2---- afficher mes contacts");
    Console.WriteLine("0---- Quitter");
    do
    {
        Console.Write("Faites votre choix : ");
        isCorrect = int.TryParse(Console.ReadLine(), out choice);
    } while (!isCorrect);

    switch (choice)
    {
        case 1:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Saisir les contacts ---");
            Console.ResetColor();
            for (int i = 0; i < contactLength; i++)
            {
                Console.Write($"Nom et prénom du contact N°{i + 1} : ");
                contacts[i] = Console.ReadLine();
            }
            break;
        case 2:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Affichage des contacts ---");
            Console.ResetColor();
            for (int i = 0; i < contactLength; i++)
            {
                Console.WriteLine($"\t-Contact N°{i + 1} : {contacts[i]}");
            }
            break;
        case 0:
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong input");
            Console.ResetColor();
            break;
    }
} while (choice != 0);