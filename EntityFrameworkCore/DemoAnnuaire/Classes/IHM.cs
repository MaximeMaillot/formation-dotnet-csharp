using DemoAnnuaire.Data;
using DemoAnnuaire.Models;
using Helper.Classes;

namespace DemoAnnuaire.Classes
{
    internal class IHM
    {
        private ApplicationDbContext _context;

        public IHM(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Start()
        {
            List<(int, string, Action)> menu = new()
            {
                (1, "Voir les adresses", ShowAdresses),
                (2, "Ajouter une adresse", AddAdress),
                (3, "Editer une adresse", UpdateAdress),
                (4, "Supprimer une adresse", RemoveAdress),
                (0, "Quitter le programme", null),
            };
            Menu.HandleIHM(menu, "--- Gestion des adresses ---");
        }

        private void ShowAdresses()
        {
            Console.WriteLine("Liste des adresses : ");
            List<Adresse> adresses = _context.Adresses.ToList();
            foreach (Adresse ad in adresses)
            {
                Console.WriteLine(ad);
            }
        }

        private static Adresse AskUserAdress()
        {
            Adresse adresse = new Adresse()
            {
                NumeroVoie = AskUser.AskUserString("Entrez le numéro de la voie : "),
                IntituleVoie = AskUser.AskUserString("Entrez l'intitulé de la voie : "),
                ComplementAdresse = AskUser.AskUserString("Entrez le complément d'adresse (s'il y en a un) : "),
                Commune = AskUser.AskUserString("Entrez le nom de la commune : "),
                CodePostal = AskUser.AskUserString("Entrez le code postale : ")
            };
            return adresse;
        }

        private void AddAdress()
        {
            Adresse newAdress = AskUserAdress();
            _context.Adresses.Add(newAdress);
            _context.SaveChanges();
        }

        private void UpdateAdress()
        {
            int id = AskUser.AskUserInt("Entrez l'id de l'adresse à modifier : ");
            Adresse? adress = _context.Adresses.Find(id);
            if (adress == null)
            {
                Console.WriteLine("Cette adresse n'existe pas");
                return;
            }
            List<(int, string)> menu = new()
            {
                (1, "Numéro de voie"),
                (2, "Intitule de voie"),
                (3, "Complément d'adresse"),
                (4, "Commune"),
                (5, "Code postale"),
                (0, "Quitter")
            };
            Menu.ShowMenu(menu, "Propriétés à modifier ?");
            int choice = Menu.AskMenuChoice(menu);
            switch (choice)
            {
                case 1:
                    adress.NumeroVoie = AskUser.AskUserString("Entrez le numéro de la voie : ");
                    break;
                case 2:
                    adress.IntituleVoie = AskUser.AskUserString("Entrez l'intitulé de la voie : ");
                    break;
                case 3:
                    adress.ComplementAdresse = AskUser.AskUserString("Entrez le complément d'adresse (s'il y en a un) : ");
                    break;
                case 4:
                    adress.Commune = AskUser.AskUserString("Entrez le nom de la commune : ");
                    break;
                case 5:
                    adress.CodePostal = AskUser.AskUserString("Entrez le code postale : ");
                    break;
                case 0:
                    return;
                default:
                    throw new Exception();
            }
            //_context.Adresses.Update(adress);
            _context.SaveChanges();
            Console.WriteLine("L'adresse à été mis à jour");
        }

        private void RemoveAdress()
        {
            int id = AskUser.AskUserInt("Entrez l'id de l'adresse à modifier : ");
            Adresse? adress = _context.Adresses.Find(id);
            if (adress == null)
            {
                Console.WriteLine("Cette adresse n'existe pas");
                return;
            }
            _context.Adresses.Remove(adress);
            _context.SaveChanges();
            Console.WriteLine("L'adresse à été supprimé");
        }
    }
}
