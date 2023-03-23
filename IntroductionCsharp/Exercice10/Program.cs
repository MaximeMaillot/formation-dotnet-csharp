// See https://aka.ms/new-console-template for more information
Console.WriteLine("--- La lettre est-elle une voyelle ? ---");
string voyelles = "aeyuioéèêàâ";
Console.Write("Entrez une lettre : ");
char letter = Convert.ToChar(Console.ReadLine().ToLower());
if (voyelles.IndexOf(letter) > -1)
{
    Console.WriteLine("Cette lettre est une voyelle !");
}
else
{
    Console.WriteLine("Cette lettre est une consonne !");
}
