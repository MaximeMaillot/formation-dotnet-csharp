using DemoAdo.Classes.Filter;
using Helper.Classes;

namespace DemoAdo.Classes
{
    internal static class IHM
    {
        /// <summary>
        /// Start the IHM and show the menu
        /// </summary>
        public static void Start ()
        {
            List<(int choice, string text, Action action)> menu = new()
            {
                (1, "Ajouter un contact", AskAddContact),
                (2, "Rechercher un contact", AskSearchContact),
                (3, "Supprimer un contact", AskRemoveContact),
                (4, "Modifier un contact", AskUpdateContact),
                (5, "Afficher tous les contacts", AskAllContacts),
                (0, "Quitter", null)
            };
            Menu.Classes.Menu.HandleIHM(menu, "--- Menu Étudiant ---");
        }

        /// <summary>
        /// Add a user to the database with user inputs
        /// </summary>
        public static void AskAddContact()
        {
            string nom = AskUserHelper.AskUserString("Donnez le nom de l'etudiant : ");
            string prenom = AskUserHelper.AskUserString("Donnez le prénom de l'étudiant : ");
            string telephone = AskUserHelper.AskUserString("Donnez votre numéro de téléphone : ");
            Contact contact = new Contact(nom, prenom, telephone);
            int id = Contact.InsertContact(contact);

            Console.WriteLine($"Ajout de l'étudiant avec id {id}");
        }

        /// <summary>
        /// Remove a user in the database with filters given by the user
        /// </summary>
        public static void AskRemoveContact()
        {
            List<(int choice, string text)> menu = new()
            {
                (1, "ID"),
                (2, "Nom"),
                (3, "Prénom"),
                (4, "Téléphone"),
                (0, "Annuler")
            };
            Menu.Classes.Menu.ShowMenu(menu, "--- Choix du filtre ---");
            int choice = Menu.Classes.Menu.AskMenuChoice(menu);
            ContactFilter filter = new ContactFilter();
            switch (choice)
            {
                case 1:
                    filter.contact_id = AskUserHelper.AskUserInt("Entrez l'ID du contact à supprimer : ");
                    break;
                case 2:
                    filter.nom = AskUserHelper.AskUserString("Entrez le nom du contact à supprimer : ");
                    break;
                case 3:
                    filter.prenom = AskUserHelper.AskUserString("Entrez le prénom du contact à supprimer : ");
                    break;
                case 4:
                    filter.telephone = AskUserHelper.AskUserString("Entrez le téléphone du contact à supprimer : ");
                    break;
                default:
                    break;
            }
            if (Contact.RemoveContactByFilter(filter))
            {
                ConsoleHelper.WriteLineInColor("Contact retiré avec succès", ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteLineInColor("Impossible de retiré le contact", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Search a user in the database with filters given by the user
        /// </summary>
        public static void AskSearchContact()
        {
            List<(int choice, string text)> menu = new()
            {
                (1, "ID"),
                (2, "Nom"),
                (3, "Prénom"),
                (4, "Téléphone"),
                (0, "Annuler")
            };
            Menu.Classes.Menu.ShowMenu(menu, "--- Choix du filtre ---");
            int choice = Menu.Classes.Menu.AskMenuChoice(menu);
            ContactFilter filter = new ContactFilter();
            switch (choice)
            {
                case 1:
                    filter.contact_id = AskUserHelper.AskUserInt("Entrez l'ID du contact à rechercher : ");
                    break;
                case 2:
                    filter.nom = AskUserHelper.AskUserString("Entrez le nom du contact à rechercher : ");
                    break;
                case 3:
                    filter.prenom = AskUserHelper.AskUserString("Entrez le prénom du contact à rechercher : ");
                    break;
                case 4:
                    filter.telephone = AskUserHelper.AskUserString("Entrez le téléphone du contact à rechercher : ");
                    break;
                default:
                    break;
            }
            List<Contact> contacts = Contact.GetContactsByFilter(filter);
            Console.WriteLine("Liste de contacts : ");
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("\t" + contact);
            }
        }

        /// <summary>
        /// Update a field in the contact database with the filter given by the user
        /// </summary>
        public static void AskUpdateContact()
        {
            List<(int choice, string text)> menu = new()
            {
                (1, "ID"),
                (2, "Nom"),
                (3, "Prénom"),
                (4, "Téléphone"),
                (0, "Annuler")
            };
            Menu.Classes.Menu.ShowMenu(menu, "--- Choix de la donnée à modifier ---");
            int choiceFilter = Menu.Classes.Menu.AskMenuChoice(menu);
            ContactFilter filterWhere = new ContactFilter();
            switch (choiceFilter)
            {
                case 1:
                    filterWhere.contact_id = AskUserHelper.AskUserInt("Entrez l'ID du contact à modifier : ");
                    break;
                case 2:
                    filterWhere.nom = AskUserHelper.AskUserString("Entrez le nom du contact à modifier : ");
                    break;
                case 3:
                    filterWhere.prenom = AskUserHelper.AskUserString("Entrez le prénom du contact à modifier : ");
                    break;
                case 4:
                    filterWhere.telephone = AskUserHelper.AskUserString("Entrez le téléphone du contact à rechercher : ");
                    break;
                default:
                    break;
            }
            Menu.Classes.Menu.ShowMenu(menu, "--- Choix de la donnée à modifier ---");
            int choiceUpdate = Menu.Classes.Menu.AskMenuChoice(menu);
            ContactFilter filterUpdate = new ContactFilter();
            switch (choiceFilter)
            {
                case 1:
                    filterUpdate.nom = AskUserHelper.AskUserString("Entrez le nouveau nom du contact : ");
                    break;
                case 2:
                    filterUpdate.prenom = AskUserHelper.AskUserString("Entrez le nouveau prénom du contactr : ");
                    break;
                case 3:
                    filterUpdate.telephone = AskUserHelper.AskUserString("Entrez le nouveau téléphone du contact : ");
                    break;
                default:
                    break;
            }
            if (Contact.UpdateContactByFilter(filterUpdate, filterWhere))
            {
                ConsoleHelper.WriteLineInColor("Contact modifié avec succès", ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteLineInColor("Impossible de modifié le contact", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Show all the contacts in the database
        /// </summary>
        public static void AskAllContacts()
        {
            List<Contact> contacts = Contact.GetAllContacts();
            Console.WriteLine("Liste de contacts : ");
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("\t" + contact);
            }
        }
    }
}
