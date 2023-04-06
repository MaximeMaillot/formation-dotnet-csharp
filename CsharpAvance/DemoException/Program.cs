using DemoException.Classes;
using DemoException.Exceptions;

Personne p;
do
{
    Console.Write("Entrez votre numéro de téléphone : ");
    try
    {
        p = new Personne(Console.ReadLine());
        break;
    }  catch (TelephoneException e)
    {
        Console.WriteLine(e.Message);
    }
} while (true);