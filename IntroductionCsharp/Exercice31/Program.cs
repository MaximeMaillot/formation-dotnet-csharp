﻿int choice, min = 20, max = 0, sum = 0, cpt=0;
// Demande à l'utilisateur son choix jusqu'à ce qu'il rentre 0
do
{
    Console.WriteLine("--- Gestion des notes avec menu ---");
    Console.WriteLine("1----Saisir les notes");
    Console.WriteLine("2----La plus grande note");
    Console.WriteLine("3----La plus petite note");
    Console.WriteLine("4----La moyenne des notes");
    Console.WriteLine("0----Quitter");

    Console.Write("Faites votre choix : ");

    bool isCorrect;
    // Demande jusqu'à avoir un choix correct
    do
    {
        isCorrect = int.TryParse(Console.ReadLine(), out choice);
        if (choice < 0 || choice > 4)
        {
            isCorrect = false;
        }
    } while (!isCorrect);

    // Switch qui gère le choix
    switch (choice)
    {
        // Saisie
        case 1:
            int userInput;
            // Boucle tant que l'utilisateur n'entre pas 999
            do
            {
                // Demander jusqu'à ce que la valeur soit gérable
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
                // Quitte le while si on met 999
                if (userInput == 999)
                {
                    break;
                }
                // Gère la note maximale
                if (userInput > max)
                {
                    max = userInput;
                }
                // Gère la note minimale
                if (userInput < min)
                {
                    min = userInput;
                }
                // Somme des notes
                sum += userInput;
                // Nombre de notes
                cpt++;
            } while (true);
            break;
        // Get max note
        case 2:
            if (cpt > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--- La plus grande note ---");
                Console.WriteLine($"La plus grande note est : {max}");
            } else
            {
                Console.WriteLine("Entrez d'abord des notes");
            }
            break;
        // Get min note
        case 3:
            if (cpt > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- La plus petite note ---");
                Console.WriteLine($"La plus petite note est : {min}");
            } else
            {
                Console.WriteLine("Entrez d'abord des notes");
            }
            break;
        // Get moyenne
        case 4:
            if (cpt > 0 )
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- La moyenne des notes ---");
                Console.WriteLine($"La moyenne est : {Math.Round((sum / (float)cpt), 1)}");
            } else
            {
                Console.WriteLine("Entrez d'abord des notes");
            }
            break;
    }
    Console.ResetColor();
} while (choice != 0);
