Console.WriteLine("--- Dans quelle catégorie mon enfant est-il ?");
Console.Write("Entrez l'âge de votre enfant : ");
int age = Convert.ToInt32(Console.ReadLine());

if (age < 3)
{
    Console.WriteLine("Votre enfant est trop jeune");
}
else if (age <= 6)
{
    Console.WriteLine("Votre enfant est un baby");
}
else if (age <= 8)
{
    Console.WriteLine("Votre enfant est un poussin");
}
else if (age <= 10)
{
    Console.WriteLine("Votre enfant est un pupille");
}
else if (age <= 12)
{
    Console.WriteLine("Votre enfant est un minime");
}
else if (age <= 18)
{
    Console.WriteLine("Votre enfant est un cadet");
}
else if (age > 18)
{
    Console.WriteLine("Votre enfant est un adulte");
}
else
{
    Console.WriteLine("Votre enfant est un alien");
}