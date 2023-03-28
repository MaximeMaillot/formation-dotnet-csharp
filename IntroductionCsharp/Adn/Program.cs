static string formatAdn(string adn)
{
    return adn.Trim().ToLower();
}

static bool CheckAdn(string adn)
{
    foreach (char c in adn)
    {
        if (c != 'a' && c != 't' && c != 'c' && c != 'g')
        {
            return false;
        }
    }
    return true;
}
static string InputAdn(string inputMsg)
{
    bool isCorrect;
    string askUser;
    do
    {
        Console.Write(inputMsg);
        askUser = formatAdn(Console.ReadLine());
        isCorrect = CheckAdn(askUser);
        if (!isCorrect)
        {
            Console.WriteLine("Erreur de saisie");
        }
    } while (!isCorrect);
    return askUser;
}

static double CompareAdn(string adn, string sequence)
{
    int nbSequence = adn.Split(sequence).Length - 1;
    return Math.Round((sequence.Length * nbSequence) * 100 / (float)adn.Length, 2);
}


string adn = InputAdn("Veuillez saisir une chaîne d'ADN : ");
string sequence = InputAdn("Veuillez saisir une sequence d'ADN : ");

Console.WriteLine($"adn : {adn}");
Console.WriteLine($"sequence : {sequence}");

Console.WriteLine($"Il y a {CompareAdn(adn, sequence)}% de \"{sequence}\" dans la chaine \"{adn}\"");