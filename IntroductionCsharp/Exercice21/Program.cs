// See https://aka.ms/new-console-template for more information
Console.WriteLine("--- Menu et sous-menus ---");
Console.WriteLine("Table des matières :\n");
for (int i =1; i <= 3; i++)
{
    Console.WriteLine("\tChapitre " + i);
    for (int j = 1; j <=3; j++)
    {
        Console.WriteLine("\t\t-Partie " + i + "." + j);
    }
}
