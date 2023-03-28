// fonction qui sert à lancer l'application, elle contiendra les instruction permettant de faire fonctionner
// l'interface utilisateur (menu principal, ...) => IHM == Interface Homme Machine
static void IHM()
{
    List<string> prenoms = new () { "Maxime", "Lazare", "Justine", "Gianni", "Thibault" };
    List<string> prenomsTires = new();
    do
    {
        Console.WriteLine("--- Le grand tirage au sort ---\n");
        Console.WriteLine("1--- Effectuer un tirage");
        Console.WriteLine("2--- Voir la liste des personnes déjà tirées");
        Console.WriteLine("3--- Voir la liste des personnes restantes");
        Console.WriteLine("4--- Ajouter un prenom");
        Console.WriteLine("5--- Modifier un prenom");
        Console.WriteLine("6--- Supprimer un prenom");
        Console.WriteLine("0--- Quitter\n");
        Console.Write("Faites votre choix : ");
        int choice;
        bool isCorrect;
        do
        {
            isCorrect = int.TryParse(Console.ReadLine(), out choice);
        } while (!isCorrect);
        switch (choice)
        {
            case 1:
                EffectuerTirage(prenoms, prenomsTires);
                break;
            case 2:
                AfficherTirees(prenomsTires);
                break;
            case 3:
                AfficherRestantes(prenoms, prenomsTires);
                break;
            case 4:
                AjouterNom(prenoms);
                break;
            case 5:
                UpdateNom(prenoms, prenomsTires, AskExistingPrenom(prenoms, "Prénom à modifier : "));
                break;
            case 6:
                DeleteNom(prenoms, prenomsTires, AskExistingPrenom(prenoms, "Prénom à supprimer : "));
                break;
            case 0:
                return;
            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrez un choix correct");
                Console.ResetColor();
                break;
        }
    } while (true);
}

// partie dédiée au tirage, lorsque tout le monde a été tiré on affiche à l'utilisateur un message pour dire que la liste a été remise à 0
static void EffectuerTirage(List<string> prenoms, List<string> prenomsTires)
{
    Console.Clear();
    Random random = new();
    List<string> prenomsNotTires = prenoms.Where(p => prenomsTires.All(p2 => p2 != p)).ToList();
    int tirage = random.Next(0, prenomsNotTires.Count);
    prenomsTires.Add(prenomsNotTires[tirage]);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"L'heureux gagant est {prenomsNotTires[tirage]}");
    if (prenomsTires.Count == prenoms.Count)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"La liste est remise à 0");
        prenomsTires.Clear();
    }
    Console.ResetColor();
}

// affichage des personne tirées
static void AfficherTirees(List<string> prenomsTires)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Liste des personnes déjà tirés");
    Console.ResetColor();
    string tabulation = "";
    for (int i = 0; i < prenomsTires.Count; i++)
    {
        if (prenomsTires[i] != "")
        {
            Console.WriteLine(tabulation + prenomsTires[i]);
            tabulation += "  ";
        }
    }
}

// affichage des personne restantes
static void AfficherRestantes(List<string> prenoms, List<string> prenomsTires)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Personnes n'ayant pas encore fait de correction : ");
    Console.ResetColor();
    string tabulation = "";
    List<string> prenomsRestant = prenoms.Except(prenomsTires).ToList();
    for (int i = 0; i < prenomsRestant.Count; i++)
    {
        Console.WriteLine(tabulation + prenomsRestant[i]);
        tabulation += "  ";
    }
}

// fonctionnalité supplémentaire du programme pour ajouter une nouvelle personne au tableau initial
static void AjouterNom(List<string> prenoms)
{
    string prenom = AskPrenom(prenoms, "Entrez le prénom à ajouter : ");
    prenoms.Add(prenom);
}

// // Ask for a prenom that should already exist in the list
static string AskExistingPrenom(List<string> prenoms, string askInput)
{
    do
    {
        Console.Write(askInput);
        string prenom = Console.ReadLine();
        if (prenoms.Any(item => item == prenom))
        {
            return prenom;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ce prénom n'existe pas");
        Console.ResetColor();
    } while (true);
}

// Ask for a new prenom that should not exist in the list
static string AskPrenom(List<string> prenoms, string askInput)
{
    string prenom;
    do
    {
        Console.Write(askInput);
        prenom = Console.ReadLine();
        if (prenoms.Any(item => item == prenom))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ce prénom existe déjà dans la liste");
            prenom = "";
        }
        else if (prenom.Length < 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Un prénom fait au minimum 2 caractères");
        }
        Console.ResetColor();
    } while (prenom.Length < 2);
    return prenom;
}

// Delete by name
static void DeleteNom(List<string> prenoms, List<string> prenomsTires, string prenom)
{
    if (prenoms.Any(p => p == prenom))
    {
        prenoms.Remove(prenoms.Single(p => p == prenom));
        prenomsTires.Remove(prenomsTires.Single(p => p == prenom));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{prenom} enlevé de la liste avec succès");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{prenom} n'existe pas dans la liste");
        Console.ResetColor();
    }
}

// Update by name
static void UpdateNom(List<string> prenoms, List<string> prenomsTires, string prenomToModify)
{
    int index = prenoms.FindIndex(p => p == prenomToModify);
    if (index < 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{prenomToModify} n'existe pas dans la liste");

    } else
    {
        string prenom = AskPrenom(prenoms, "Entrez le nouveau prenom : ");
        prenoms[index] = prenom;
        index = prenomsTires.FindIndex(p => p == prenomToModify);
        if (index != -1)
        {
            prenomsTires[index] = prenom;
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{prenomToModify} modifié en {prenom} dans la liste");
    }
    Console.ResetColor();
}

IHM();