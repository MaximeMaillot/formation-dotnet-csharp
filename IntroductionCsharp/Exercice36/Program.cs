Console.WriteLine("*** Tableau des notes ***");
bool isCorrect;
int notesLength;

Console.Write("Combien de notes comportera le tableau : ");
do
{
    isCorrect = int.TryParse(Console.ReadLine(), out notesLength) && notesLength > 0;
    if (!isCorrect)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\tErreur de saisie, merci de saisir un chiffre/nombre : ");
        Console.ResetColor();
    }
} while (!isCorrect);


int[] notes = new int[notesLength];

Console.WriteLine($"Merci de saisir les {notesLength} notes\n");
for (int i = 0; i < notesLength; i++)
{
    Console.Write($"\t-Note {i + 1} : ");
    do
    {
        int note;
        isCorrect = int.TryParse(Console.ReadLine(), out note) && note >= 0 && note <= 20;
        if (!isCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\tErreur, merci de saisir un chiffre/nombre /20 pour la note {i + 1} : ");
            Console.ResetColor();
        } else
        {
            notes[i] = note;
        }
    } while (!isCorrect);
}

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n--- La liste de notes ---");
Console.ResetColor();

for (int i=0; i<notesLength; i++)
{
    Console.WriteLine($"La note {i + 1} est de : {notes[i]}/20");
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\n--- La note max est : {notes.Max()}/20");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"--- La note max est : {notes.Min()}/20");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"--- La note max est : {Math.Round(notes.Sum() / (float)notesLength, 2)}/20");
Console.ResetColor();
