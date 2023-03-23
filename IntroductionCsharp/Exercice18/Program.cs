Console.WriteLine("--- Dans quelle catégorie mon enfant est-il ?");
int age;
bool error;
do
{
    Console.Write("Entrez l'âge de votre enfant : ");
    error = int.TryParse(Console.ReadLine(), out age);
} while (!error);

switch (age)
{
    case < 3:
        Console.WriteLine("Votre enfant est trop jeune");
        break;
    case <= 6:
        Console.WriteLine("Votre enfant est un baby");
        break;
    case <= 8:
        Console.WriteLine("Votre enfant est un poussin");
        break;
    case <= 10:
        Console.WriteLine("Votre enfant est un pupille");
        break;
    case <= 12:
        Console.WriteLine("Votre enfant est un minime");
        break;
    case <= 18:
        Console.WriteLine("Votre enfant est un cadet");
        break;
    case > 18:
        Console.WriteLine("Votre enfant est un adulte");
        break;
    default:
        Console.WriteLine("throw an error");
        break;
}