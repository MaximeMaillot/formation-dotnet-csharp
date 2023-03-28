// fonction qui sert à lancer l'application, elle contiendra les instruction permettant de faire fonctionner
// l'interface utilisateur (menu principal, ...) => IHM == Interface Homme Machine
using TheGreatTP;

static void IHM()
{
    // J'initialise ma liste de prenoms avec des prenoms en dur
    List<string> prenoms = new() { "Maxime", "Lazare", "Justine", "Gianni", "Thibault" };
    // J'initialise aussi la liste des prenoms tirés pour l'instant vide
    List<string> prenomsTires = new List<string>();
    do // Boucle qui gère le menu
    {
        Console.WriteLine("--- Le grand tirage au sort ---\n");
        Console.WriteLine("1--- Effectuer un tirage");
        Console.WriteLine("2--- Voir la liste des personnes déjà tirées");
        Console.WriteLine("3--- Voir la liste des personnes restantes");
        Console.WriteLine("4--- Ajouter un prenom");
        Console.WriteLine("5--- Modifier un prenom");
        Console.WriteLine("6--- Supprimer un prenom");
        Console.WriteLine("0--- Quitter\n");

        int choice;
        bool isCorrect;
        do // Demande à l'utilisateur son choix jusqu'à ce qu'il soit un entier
        {
            Console.Write("Faites votre choix : ");
            // isCorrect sera true si le choix de l'utilisateur est un entier, sinon false
            // choice récupère le choix de notre utilisateur
            isCorrect = int.TryParse(Console.ReadLine(), out choice);
            // Si l'utilisateur à rentrer autre chose qu'un entier
            if (!isCorrect)
            {
                WriteInColor("Entrez un choix correct", ConsoleColor.Red);
            }
        } while (!isCorrect);
        // Condition qui ne s'applique que si on ne veut pas faire un ajout ou quitter le menu
        if (choice != 4 && choice != 0)
        {
            // Si la liste est vide on affiche un message d'erreur
            if (!CheckListIntegrity(prenoms))
            {
                WriteInColor("La liste est vide, pensez à la remplir", ConsoleColor.Red);
                continue;
            }
        }
        // On rentre dans la bonne condition en fonction du choix de l'utilisateur
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
                // Si l'utilisateur à rentrer un entier qui n'est pas dans le menu
                Console.Clear();
                WriteInColor("Entrez un choix correct", ConsoleColor.Red);
                break;
        }
    } while (true);
}

// Fonction qui permet d'ecrire un message "text" dans une couleur "color".
static void WriteInColor(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

// Vérifie qu'il y a au moins un prénom dans la liste
static bool CheckListIntegrity(List<string> prenoms)
{
    if (prenoms.Count == 0)
    {
        return false;
    }
    return true;
}

// partie dédiée au tirage, lorsque tout le monde a été tiré on affiche à l'utilisateur un message pour dire que la liste a été remise à 0
static void EffectuerTirage(List<string> prenoms, List<string> prenomsTires)
{
    Console.Clear();
    Random random = new();

    // prenoms.Where => Filtre prenoms en fonction de la fonction à l'intérieur
    // prenomsTires.All => Verifie tous les prenoms tires et ne retourner que ceux pas présent dans prenoms
    // ** Pour chaque prenom, verifie qu'il n'est pas present dans prenomTires, si c'est le cas, ajoute le à ma liste **
    List<string> prenomsNotTires = prenoms.Where(prenom => prenomsTires.All(prenomTire => prenomTire != prenom)).ToList();
    int tirage = random.Next(0, prenomsNotTires.Count);
    prenomsTires.Add(prenomsNotTires[tirage]);

    WriteInColor($"L'heureux gagant est {prenomsNotTires[tirage]}", ConsoleColor.Green);

    // Reset la liste si on a tiré tout le monde
    if (prenomsTires.Count == prenoms.Count)
    {
        WriteInColor("La liste est remise à 0", ConsoleColor.Green);
        prenomsTires.Clear();
    }
}

// affichage des personne tirées
static void AfficherTirees(List<string> prenomsTires)
{
    Console.Clear();
    WriteInColor("Liste des personnes déjà tirés", ConsoleColor.Red);
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
    WriteInColor("Personnes n'ayant pas encore fait de correction", ConsoleColor.Cyan);
    string tabulation = "";
    // prenoms.Except => tous les prenoms moins les prenomTires
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
        // Vérifie si le prenom existe
        if (prenoms.Any(p => p == prenom))
        {
            return prenom;
        }
        WriteInColor("Ce prénom n'existe pas dans la liste", ConsoleColor.Red);
    } while (true);
}

// Ask for a new prenom that should not exist in the list
static string AskPrenom(List<string> prenoms, string askInput)
{
    do
    {
        Console.Write(askInput);
        string prenom = Console.ReadLine();
        if (prenoms.Any(item => item == prenom))
        {
            WriteInColor("Ce prénom existe déjà dans la liste", ConsoleColor.Red);
        }
        else if (prenom.Length < 2)
        {
            WriteInColor("Un prénom fait au minimum 2 caractères", ConsoleColor.Red);
        } else
        {
            return prenom;
        }
    } while (true);
}

// Delete by name
static void DeleteNom(List<string> prenoms, List<string> prenomsTires, string prenomoDelete)
{
    prenoms.Remove(prenoms.Single(prenom => prenom == prenomoDelete));
    // Verifie s'il existe dans la liste des prenoms Tires et le supprime si c'est le cas
    if (prenomsTires.Any(prenomTire => prenomTire == prenomoDelete))
    {
        prenomsTires.Remove(prenomsTires.Single(prenomTire => prenomTire == prenomoDelete));
    }
    WriteInColor($"{prenomoDelete} enlevé de la liste avec succès", ConsoleColor.Green);
}

// Update by name
static void UpdateNom(List<string> prenoms, List<string> prenomsTires, string prenomToModify)
{
    // Trouve l'index du prenom à modifier
    int index = prenoms.FindIndex(prenom => prenom == prenomToModify);
    // Si le mot n'existe pas dans la liste
    string prenom = AskPrenom(prenoms, "Entrez le nouveau prenom : ");
    prenoms[index] = prenom;
    index = prenomsTires.FindIndex(prenomTire => prenomTire == prenomToModify);
    if (index != -1)
    {
        prenomsTires[index] = prenom;
    }
    WriteInColor($"{prenomToModify} modifié en {prenom} dans la liste", ConsoleColor.Green);
}

IHM();

/*
// Use Class instead of function for the Great TP
static void IHMClass()
{
    Tirage tirage = new Tirage(new List<string> { "Maxime" });
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
        int choice;
        bool isCorrect;
        do
        {
            Console.Write("Faites votre choix : ");
            isCorrect = int.TryParse(Console.ReadLine(), out choice);
            if (!isCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrez un choix correct");
                Console.ResetColor();
            }
        } while (!isCorrect);
        switch ((Choice)choice)
        {
            case Choice.Draw:
                tirage.EffectuerTirage();
                break;
            case Choice.ListDrawn:
                tirage.AfficherTirees();
                break;
            case Choice.ListLeft:
                tirage.AfficherRestantes();
                break;
            case Choice.Add:
                tirage.AjouterNom();
                break;
            case Choice.Update:
                tirage.UpdateNom(tirage.AskExistingPrenom("Prénom à modifier : "));
                break;
            case Choice.Delete:
                tirage.DeleteNom(tirage.AskExistingPrenom("Prénom à supprimer : "));
                break;
            case Choice.Exit:
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

IHMClass();
*/