Random random = new ();
int height;
bool isCorrect;

Dictionary<int, char> characters = new()
{
    [0] = '*',
    [1] = 'o',
    [2] = '-',
    [3] = '_',
    [4] = 'p',
    [5] = 's'
};

do
{
    Console.Write("Saisir la hauteur du triangle : ");
    isCorrect = int.TryParse(Console.ReadLine(), out height);
    if (height < 0)
    {
        isCorrect = false;
    }
} while (!isCorrect);

int width = height + (height - 1);

for (int i = 1; i <= height; i++)
{

    int triangleLength = i + (i - 1);
    for (int j = 0; j < ((width - triangleLength) / 2f + triangleLength); j++)
    {
        Console.ForegroundColor = (ConsoleColor)random.Next(0,16);
        if (j < ((width / 2f) - (triangleLength / 2f)))
        {
            Console.Write(" ");
        }
        else
        {
            Console.Write(characters[random.Next(0, characters.Count)]);
        }
    }
    Console.WriteLine();
}
Console.ResetColor();

