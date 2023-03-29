using Hostel.Classes;
using System.Drawing;

void WriteInColor(string msg, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(msg);
    Console.ResetColor();
};

int choice;

Console.Write("Quel est le nom de l'Hôtel ? ");
Hotel hotel = new Hotel(Console.ReadLine());

do
{
    Console.WriteLine("=== Menu Principal ===\n");
    Console.WriteLine("1. Ajouter un client");
    Console.WriteLine("2. Afficher la liste des clients");
    Console.WriteLine("3. Afficher les réservations d'un client");
    Console.WriteLine("4. Ajouter une réservation");
    Console.WriteLine("5. Annuler une réservation");
    Console.WriteLine("6. Afficher la liste des réservations");
    Console.WriteLine("0. Quitter");
    int choix;
    bool isCorrect;
    do
    {
        Console.Write("Votre choix : ");
        isCorrect = int.TryParse(Console.ReadLine(), out choix);
    } while (!isCorrect);
    switch (choix)
    {
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break;
        case 6:
            break;
        case 0:
            return;
        default:
            WriteInColor("Choix incorrect", ConsoleColor.Red);
            break;
    }
} while (true);
