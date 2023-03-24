int choice, min = 20, max = 0, sum = 0, cpt=0;
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
    do
    {
        isCorrect = int.TryParse(Console.ReadLine(), out choice);
        if (choice < 0 || choice > 4)
        {
            isCorrect = false;
        }
    } while (!isCorrect);
    switch (choice)
    {
        case 1:
            int userInput;
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
            } while (true);
            break;
        case 2:
            if (cpt > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--- La plus grande note ---");
                Console.WriteLine($"La plus grande note est : {max}");
                Console.ResetColor();
            } else
            {
                Console.WriteLine("Entrez d'abord des notes");
            }
            break;
        case 3:
            if (cpt > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- La plus petite note ---");
                Console.WriteLine($"La plus petite note est : {min}");
                Console.ResetColor();
            } else
            {
                Console.WriteLine("Entrez d'abord des notes");
            }
            break;
        case 4:
            if (cpt > 0 )
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- La moyenne des notes ---");
                Console.WriteLine($"La moyenne est : {Math.Round((sum / (float)cpt), 1)}");
                Console.ResetColor();
            } else
            {
                Console.WriteLine("Entrez d'abord des notes");
            }
            break;
    }
} while (choice != 0);
