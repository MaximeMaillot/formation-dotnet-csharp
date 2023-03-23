Console.WriteLine("--- Gestion des notes ---");

Console.WriteLine("Veuillez saisir 5 notes : \n");
float sum = 0F;
int max = 0;
int min = 20;
for (int i = 1; i <= 5; i++)
{
    bool isCorrect;
    int note;
    // Get a correct note
    do
    {
        Console.Write($"\t- Merci de saisir la note {i} (sur /20) : ");
        isCorrect = int.TryParse(Console.ReadLine(), out note);
        if (note < 0 || note > 20)
        {
            isCorrect = false;
        }
    } while (!isCorrect);

    // calcul max
    if (note > max)
    {
        max = note;
    }
    // calcul min
    else if (note < min)
    {
        min = note;
    }
    // calcul sum
    sum += note;
}
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\nLa meilleur note est {max}/20");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"La moins bonne note est {min}/20");
Console.ResetColor();
Console.WriteLine($"La moyenne des notes est {Math.Round(sum / 5F, 1)}/20");
