int height;
bool isCorrect;
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
    string line = "";
    int triangleLength = i + (i - 1);
    // Space before the triangle
    for (int j =0; j < ((width / 2f) - (triangleLength / 2f)); j++)
    {
        line += " ";
    }
    // The triangle
    for (int j = 0; j < triangleLength; j++)
    {
        line += "*";
    }
    // Space after the triangle
    for (int j = 0; j < ((width / 2f) - (triangleLength / 2f)); j++)
    {
        line += " ";
    }
    Console.WriteLine(line);
}

