int[] values = new int[10];
for (int i = 0; i < 10; i++)
{
    bool isCorrect;
    do
    {
        Console.Write($"Entrez la valeur {i + 1} : ");
        isCorrect = int.TryParse(Console.ReadLine(), out values[i]);
    } while (!isCorrect);
}
string tabulation = "";
for (int i = 0; i < 10; i++)
{
    Console.Write(tabulation + values[i] + "\n");
    tabulation += "\t";
}
