using Hostel.Classes.Helper;
using Menu.Classes;

namespace Hostel.Classes
{
    internal interface IHM
    {
        static void Start()
        {
            string nomHotel = AskUserHelper.LoopUntilCorrect(() =>
            {
                Console.Write("Quel est le nom de l'Hôtel ? (\"test\" pour les données de test) ");
                string nom = ConsoleHelper.ReadLine();
                if (nom.Length == 0) {
                    throw new Exceptions.UserInputException("Le nom de l'hôtel ne peut pas être vide");
                }
                return nom;
            });
            Hotel hotel = new(nomHotel);

            if (hotel.NomHotel.ToLower() == "test")
            {
                hotel.AddChambre(new Chambre(5, 12));
                hotel.AddChambre(new Chambre(5, 25));
                hotel.AddChambre(new Chambre(1, 50));
                hotel.AddChambre(new Chambre(2, 42));
                hotel.AddChambre(new Chambre(9, 37));
                hotel.AddClient(new Client("testNom", "testPrenom", "0123456789"));
                hotel.AddClient(new Client("testNom2", "testPrenom2", "0002040608"));
            }

            IHMHelper hotelHelper = new(hotel);

            List<(int num, string msg, Action action)> mainMenu = new() {
                (1, "Ajouter un client", hotelHelper.AddClient),
                (2, "Afficher la liste des clients", hotelHelper.ShowListClient),
                (3, "Afficher les réservations d'un client", hotelHelper.ShowReservationClient),
                (4, "Ajouter une réservation", hotelHelper.AddReservation),
                (5, "Annuler une réservation", hotelHelper.CancelReservation),
                (6, "Finir sa réservation", hotelHelper.EndReservation),
                (7, "Afficher la liste des réservations", hotelHelper.ShowListReservations),
                (8, "Ajouter une chambre", hotelHelper.AddChambre),
                (9, "Afficher les chambres", hotelHelper.ShowListChambres),
                (10, "Nettoyer une chambre", hotelHelper.CleanChambre),
                (11, "Afficher chambres disponibles par nombre de lits", hotelHelper.ShowChamberListByNbLit),
                (0, "Quitter", null)
            };
            try
            {
                Menu.Classes.Menu.HandleIHM(mainMenu, "--- Menu de l'hôtel ---");
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteInColor(ex.Message, ConsoleColor.DarkMagenta);
            }
        }
    }
}
