using Employee.Classes;

internal static class MainHelpers
{

    private static int AskMenuChoice(List<(int num, string msg)> menu)
    {
        int choice;
        bool isCorrect;
        do
        {
            Console.Write("Votre choix : ");
            isCorrect = int.TryParse(Console.ReadLine().Trim(), out choice);
            if (!isCorrect)
            {
                Console.WriteLine("Rentrez une valeur numérique");
            }
            if (!menu.Any(item => item.num == choice))
            {
                Console.WriteLine("Rentrez une valeur présent dans le menu");
            }
        } while (!isCorrect);
        return choice;
    }

    private static string AskUserCategorie()
    {
        string categorie;
        do
        {
            Console.Write("Merci de saisir la catégorie : ");
            categorie = Console.ReadLine();
            if (string.IsNullOrEmpty(categorie))
            {
                Console.WriteLine("Entrez un catégorie");
            }
        } while (string.IsNullOrEmpty(categorie));
        return categorie.Trim();
    }

    private static int AskUserChiffreAffaires()
    {
        bool isCorrect;
        int chiffreAffaires;
        do
        {
            Console.Write("Merci de saisir le chiffre d'affaires : ");
            isCorrect = int.TryParse(Console.ReadLine().Trim(), out chiffreAffaires);
            if (isCorrect && chiffreAffaires <= 0)
            {
                isCorrect = false;
                Console.WriteLine("Un chiffre d'affaires ne peut pas être négatif");
            }
        } while (!isCorrect);
        return chiffreAffaires;
    }

    private static int AskUserComission()
    {
        bool isCorrect;
        int comission;
        do
        {
            Console.Write("Merci de saisir la comission : ");
            isCorrect = int.TryParse(Console.ReadLine().Trim(), out comission);
            if (isCorrect && comission <= 0)
            {
                isCorrect = false;
                Console.WriteLine("Une comission ne peut pas être négatif");
            }
        } while (!isCorrect);
        return comission;
    }


    private static Commercial AskUserCommercial()
    {
        return new Commercial(AskUserSalarie(), AskUserChiffreAffaires(), AskUserComission());
    }

    private static string AskUserMatricule()
    {
        string matricule;
        do
        {
            Console.Write("Merci de saisir le matricule : ");
            matricule = Console.ReadLine();
            if (string.IsNullOrEmpty(matricule))
            {
                Console.WriteLine("Entrez un matricule");
            }
        } while (string.IsNullOrEmpty(matricule));
        return matricule.Trim();
    }

    private static string AskUserName()
    {
        string name;
        do
        {
            Console.Write("Merci de saisir le nom : ");
            name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Entrez un nom");
            }
        } while (string.IsNullOrEmpty(name));
        return name.Trim();
    }

    private static int AskUserSalaire()
    {
        bool isCorrect;
        int salaire;
        do
        {
            Console.Write("Merci de saisir le salaire : ");
            isCorrect = int.TryParse(Console.ReadLine().Trim(), out salaire);
            if (isCorrect && salaire <= 0)
            {
                isCorrect = false;
                Console.WriteLine("Un salaire ne peut pas être négatif");
            }
        } while (!isCorrect);
        return salaire;
    }

    private static Salarie AskUserSalarie()
    {
        return new Salarie(AskUserName(), AskUserSalaire(), AskUserMatricule(), AskUserCategorie(), AskUserService());
    }

    private static Salarie askUserSalarieByName(List<Salarie> salaries)
    {
        string name;
        do
        {
            name = AskUserName().ToLower();
            if (!salaries.Any(salarie => salarie.Nom.ToLower().StartsWith(name)))
            {
                Console.WriteLine("Le salarié n'existe pas");
            }
            else
            {
                break;
            }
        } while (true);
        return salaries.Find(salarie => salarie.Nom.ToLower().StartsWith(name));
    }

    private static string AskUserService()
    {
        string service;
        do
        {
            Console.Write("Merci de saisir le service : ");
            service = Console.ReadLine();
            if (string.IsNullOrEmpty(service))
            {
                Console.WriteLine("Entrez un service");
            }
        } while (string.IsNullOrEmpty(service));
        return service.Trim();
    }

    private static bool isSalariesEmpty(List<Salarie> salaries)
    {
        return salaries.Count == 0;
    }

    private static void ShowMenu(List<(int num, string msg)> menu, string menuTitle = "--- Menu ---")
    {
        Console.WriteLine(menuTitle);
        foreach (var item in menu)
        {
            Console.WriteLine($"{item.num}. {item.msg}");
        }
    }
}