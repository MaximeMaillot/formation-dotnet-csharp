
static string ConcatenateWithEmptySpace(string str1, string str2) 
{
    return str1 + " " + str2;
}
Console.WriteLine("ConcatenateWithEmptySpace(John, Doe)");
Console.WriteLine(ConcatenateWithEmptySpace("John", "Doe"));
Console.WriteLine();

static int Substract(int a, int b)
{
    Console.WriteLine($"Je soustrait {a} et {b}");
    return a - b;
}

Console.WriteLine("Substract(2,1)");
int a = Substract(2, 1);
Console.WriteLine("Result : " + a);
Console.WriteLine();


static void ShowTime(string time = "12h00") 
{
    Console.WriteLine($"Il est {time}");
}

Console.WriteLine("ShowTime()");
ShowTime();
Console.WriteLine("ShowTime(14h00)");
ShowTime("14h00");
Console.WriteLine();

static int CountA(string str)
{
    return str.Count(charOfStr => charOfStr == 'a');
}

Console.WriteLine("CountA(aaaaa)");
Console.WriteLine(CountA("aaaaa"));
Console.WriteLine("CountA(afzbefkzj");
Console.WriteLine(CountA("afzbefkzj"));
Console.WriteLine("CountA(girgnk)");
Console.WriteLine(CountA("girgnk"));
Console.WriteLine();

static bool CheckAdn (string adn)
{
    for (int i =0; i < adn.Length; i++)
    {
        if (adn[i] != 'a' && adn[i] != 't' && adn[i] != 'c' && adn[i] != 'g')
        {
            return false;
        }
    }
    return true;
}

Console.WriteLine("CheckAdn(abdfergrfvdf)");
Console.WriteLine(CheckAdn("abdfergrfvdf"));
Console.WriteLine("CheckAdn(atcgatcg)");
Console.WriteLine(CheckAdn("atcgatcg"));
Console.WriteLine();

static string InputAdn ()
{
    Console.Write("Entrez une séquence ADN (atcg) : ");
    string adn = Console.ReadLine();
    if (!CheckAdn(adn))
    {
        string newAdn = "";
        for (int i = 0; i < adn.Length; i++)
        {

            if (adn[i] == 'a' || adn[i] == 't' || adn[i] == 'c' || adn[i] == 'g')
            {
                newAdn += adn[i];
            }
        }
        Console.WriteLine("Fixed ADN : " + newAdn);
        return newAdn;
    }
    Console.WriteLine("ADN : " + adn);
    return adn;
}

Console.WriteLine("CheckAdn()");
//InputAdn();
Console.WriteLine();


static double CompareAdn (string adn, string sequence)
{
    int nbSequence = adn.Split(sequence).Length - 1;
    return Math.Round((sequence.Length * nbSequence) / (float)adn.Length, 2);
}

Console.WriteLine("CompareAdn(atcgatcgatcgatcg, atcg)");
Console.WriteLine(CompareAdn("atcgatcgatcgatcg", "atcg"));
Console.WriteLine("CompareAdn(atcgatcgatcgatcg, atcga)");
Console.WriteLine(CompareAdn("atcgatcgatcgatcg", "atcga"));
Console.WriteLine("CompareAdn(atcgatcgatcgatcg, at)");
Console.WriteLine(CompareAdn("atcgatcgatcgatcg", "at"));
Console.WriteLine();

static (int, int, float, int) operation(int nb1, int nb2)
{
    return (nb1 + nb2, nb1 - nb2, nb1 / (float)nb2, nb1 * nb2);
}

Console.WriteLine("operation(10, 5)");
(int somme, int difference, float quotient, int produit) result = operation(10, 5);
Console.WriteLine(result);
Console.WriteLine();
