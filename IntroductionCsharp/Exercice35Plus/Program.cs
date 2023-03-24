static void showContacts(List<string> contacts)
{
    if (contacts.Count == 0)
    {
        Console.WriteLine("Pas de contacts");
        return;
    }
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--- Affichage des contacts ---");
    Console.ResetColor();
    for (int i = 0; i < contacts.Count; i++)
    {
        Console.WriteLine($"\t-Contact N°{i + 1} : {contacts[i]}");
    }
}

static void modifyContact(List<string> contacts)
{
    bool isCorrect;
    if (contacts.Count == 0)
    {
        Console.WriteLine("Pas de contacts");
        return;
    }
    showContacts(contacts);
    Console.Write("Entrez le numéro du contact que vous voulez modifier :");
    int indexModify;
    do
    {
        isCorrect = int.TryParse(Console.ReadLine(), out indexModify) && indexModify > 0 && indexModify <= contacts.Count;
        if (!isCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Entrez un numéro correct : ");
            Console.ResetColor();
        }
    } while (!isCorrect);
    Console.Write("Entrez la nouvelle valeur de contact : ");
    contacts[indexModify - 1] = Console.ReadLine();
}

static void deleteContact(List<string> contacts)
{
    bool isCorrect;
    if (contacts.Count == 0)
    {
        Console.WriteLine("Pas de contacts");
        return;
    }
    showContacts(contacts);
    Console.Write("Entrez le numéro du contact que vous voulez modifier :");
    int indexDelete;
    do
    {
        isCorrect = int.TryParse(Console.ReadLine(), out indexDelete) && indexDelete > 0 && indexDelete <= contacts.Count;
        if (!isCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Entrez un numéro correct : ");
            Console.ResetColor();
        }
    } while (!isCorrect);
    contacts.RemoveAt(indexDelete - 1);
}

Console.WriteLine("Gestion des contacts");
bool isCorrect;

int choice;
List<string> contacts = new();

do
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("----- Ma liste de contacts -----\n");
    Console.WriteLine("1---- Saisir des contacts");
    Console.WriteLine("2---- afficher mes contacts");
    Console.WriteLine("3---- Modifier un contact");
    Console.WriteLine("4---- Supprimer un contact");
    Console.WriteLine("0---- Quitter");
    Console.ResetColor();
    do
    {
        Console.Write("Faites votre choix : ");
        isCorrect = int.TryParse(Console.ReadLine(), out choice);
    } while (!isCorrect);

    switch (choice)
    {
        case 1:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Saisir les contacts ---");
            Console.ResetColor();
            do
            {
                Console.Write($"Nom et prénom du contact N°{contacts.Count + 1} : ");
                string contact = Console.ReadLine();
                if (contact == "999")
                    break;
                contacts.Add(contact);
            } while (true);
            break;

        case 2:
            showContacts(contacts);
            break;
        case 3:
            modifyContact(contacts);
            break;
        case 4:
            deleteContact(contacts);
            break;

        case 0:
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Veuillez entrer un numéro présent dans le menu");
            Console.ResetColor();
            break;
    }
} while (choice != 0);