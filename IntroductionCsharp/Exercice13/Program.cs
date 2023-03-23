Console.WriteLine("--- Quelle est la nature du triangle ABC ? ---");
Console.Write("Entrez la longueur du segment AB : ");
double longueurAB = Convert.ToDouble(Console.ReadLine());
Console.Write("Entrez la longueur du segment BC : ");
double longueurBC = Convert.ToDouble(Console.ReadLine());
Console.Write("Entrez la longueur du segment CA : ");
double longueurCA = Convert.ToDouble(Console.ReadLine());

if (longueurAB == longueurBC && longueurAB == longueurCA)
{
    Console.WriteLine("Equilatéral");
}
else if (longueurAB == longueurBC)
{
    Console.WriteLine("isocèle en B");
}
else if (longueurBC == longueurCA)
{
    Console.WriteLine("isocèle en C");
}
else if (longueurAB == longueurCA)
{
    Console.WriteLine("isocèle en A");
}
else
{
    Console.WriteLine("isocèle ni en A, ni en B, ni en C");
}