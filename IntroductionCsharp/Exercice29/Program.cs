﻿Console.WriteLine("-- Gestion des notes --");
int userInput, cpt = 0, max = 0, sum = 0, min = 20;
bool isCorrect;

Console.WriteLine("Veuillez saisir les notes :\n(999 pour calculer)\n");
do
{
    do
    {
        Console.Write($"\t- Merci de saisir la note {cpt + 1} (sur /20) : ");
        isCorrect = int.TryParse(Console.ReadLine(), out userInput);
        if (userInput != 999 && (userInput < 0 || userInput > 20))
        {
            isCorrect = false;
        }
        if (!isCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tErreur de saisie, la note est sur 20 !");
            Console.ResetColor();
        }
    } while (!isCorrect);
    if (userInput == 999)
    {
        break;
    }
    if (userInput > max)
    {
        max = userInput;
    }
    if (userInput < min)
    {
        min = userInput;
    }
    sum += userInput;
    cpt++;
} while (userInput != 999);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"La meilleur note est {max}/20");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"La moins bonne note est {min}/20");
Console.ResetColor();
Console.WriteLine($"La moyenne est de {Math.Round((sum / (float)cpt), 1)}/20");
