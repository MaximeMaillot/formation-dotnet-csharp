using Menu.Classes;

namespace Hostel.Classes
{
    internal interface IHM
    {
        static void Start()
        {
            // **Possible TODO List**
            // Crud for chamber
            // Crud for client
            // Crud for Reservation
            // Chamber and Reservation Status handling
            // Check if chamber is already reserved
            // Ask for the number of bed and give possible chamber
            // Reservation by date so you can have multiple reservation per chamber but date cannot overlap
            // Add payment
            Console.Write("Quel est le nom de l'Hôtel ? (\"test\" pour les données de test) ");
            Hotel hotel = new Hotel(Console.ReadLine());

            if (hotel.Nom.Trim().ToLower() == "test")
            {
                hotel.AddChambre(new Chambre(ChambreStatut.Libre, 5, 12));
                hotel.AddChambre(new Chambre(ChambreStatut.Libre, 5, 25));
                hotel.AddChambre(new Chambre(ChambreStatut.Libre, 1, 50));
                hotel.AddChambre(new Chambre(ChambreStatut.Libre, 2, 42));
                hotel.AddChambre(new Chambre(ChambreStatut.Libre, 9, 37));
                hotel.AddClient(new Client("testNom", "testPrenom", "0123456789"));
                hotel.AddClient(new Client("testNom2", "testPrenom2", "0002040608"));
            }

            List<(int num, string msg)> mainMenu = new() {
                (1, "Ajouter un client"),
                (2, "Afficher la liste des clients"),
                (3, "Afficher les réservations d'un client"),
                (4, "Ajouter une réservation"),
                (5, "Annuler une réservation"),
                (6, "Afficher la liste des réservations"),
                (7, "Ajouter une chambre"),
                (8, "Afficher les chambres"),
                (9, "Finir sa réservation"),
                (10, "Nettoyer une chambre"),
                (11, "Afficher chambres disponibles par nombre de lits"),
                (0, "Quitter")
            };
            do
            {
                Menu.Classes.Menu.ShowMenu(mainMenu);
                int choix = Menu.Classes.Menu.AskMenuChoice(mainMenu);
                Console.Clear();
                switch (choix)
                {
                    case 1:
                        var clientDetails = AskUserClientsDetails();
                        hotel.AddClient(new Client(clientDetails.nom, clientDetails.prenom, clientDetails.tel));
                        break;

                    case 2:
                        if (!hotel.HasClient())
                        {
                            HotelConsole.WriteInColor("Aucun client", ConsoleColor.Red);
                        }
                        Console.WriteLine("Liste de clients : ");
                        foreach (Client c in hotel.Clients)
                        {
                            Console.WriteLine($"\t{c}");
                        }
                        break;

                    case 3: 
                        if (!hotel.HasClient())
                        {
                            HotelConsole.WriteInColor("Aucun client", ConsoleColor.Red);
                            break;
                        }
                        int numero = AskUserClientNumero(hotel);
                        Client client = hotel.Clients.Find(client => client.Numero == numero);
                        List<Reservation> listReservation = hotel.GetReservationsByClient(client);
                        Console.WriteLine($"Liste des reservations de {client} : ");
                        foreach (Reservation r in listReservation)
                        {
                            Console.WriteLine($"\t{r}");
                        }
                        break;

                    case 4:
                        if (!hotel.HasClient())
                        {
                            HotelConsole.WriteInColor("Aucun client", ConsoleColor.Red);
                            break;
                        }
                        if (!hotel.HasChambre())
                        {
                            HotelConsole.WriteInColor("Aucune chambre", ConsoleColor.Red);
                            break;
                        }
                        int numeroClient = AskUserClientNumero(hotel);
                        List<int> numeroChambres = AskUserMultipleChambreNumero(hotel);
                        List<Chambre> chambres = new List<Chambre>();
                        foreach (int numeroChambre in numeroChambres)
                        {
                            chambres.Add(hotel.GetChambreByNumero(numeroChambre));
                        }
                        try
                        {
                            hotel.AddReservation(new Reservation(chambres, hotel.GetClientByNumero(numeroClient)));
                        } catch (Exception)
                        {
                            HotelConsole.WriteInColor("Chambre non disponible", ConsoleColor.Red);
                        }
                        break;

                    case 5:
                        if (!hotel.HasClient())
                        {
                            HotelConsole.WriteInColor("Aucun client", ConsoleColor.Red);
                            break;
                        }
                        if (!hotel.HasChambre())
                        {
                            HotelConsole.WriteInColor("Aucune chambre", ConsoleColor.Red);
                            break;
                        }
                        if (!hotel.HasReservation())
                        {
                            HotelConsole.WriteInColor("Aucune chambre", ConsoleColor.Red);
                            break;
                        }
                        int numReservation = AskUserReservationNumero(hotel);
                        hotel.CancelReservation(numReservation);
                        break;

                    case 6:
                        if (!hotel.HasReservation())
                        {
                            HotelConsole.WriteInColor("Aucune réservation", ConsoleColor.Red);
                            break;
                        }
                        Console.WriteLine("Liste des réservations : ");
                        foreach (Reservation r in hotel.Reservations)
                        {
                            Console.WriteLine(r + " :");
                            foreach (Chambre c in r.Chambres)
                            {
                                Console.WriteLine("\t" + c);
                            }
                        }
                        break;
                    case 7:

                        var chambreDetails = AskUserChambreDetails();
                        hotel.AddChambre(new Chambre(chambreDetails.statut, chambreDetails.nblit, chambreDetails.tarif));
                        break;
                    case 8:
                        Console.WriteLine("Liste des chambres : ");
                        foreach(Chambre c in hotel.Chambres)
                        {
                            Console.WriteLine("\t" + c);
                        }
                        break;
                    case 9:
                        int numReservationEnd = AskUserReservationNumero(hotel);
                        hotel.EndReservation(numReservationEnd);
                        break;
                    case 10:
                        int numChambreClean = AskUserChambreNumero(hotel);
                        hotel.CleanChambre(numChambreClean);
                        break;
                    case 11:
                        int nbLit = AskUserNbLit();
                        List<Chambre> chambresByLit = hotel.GetChambresAvailableByNbLit(nbLit);
                        Console.WriteLine($"Liste des chambres disponible avec au moins {nbLit} lits");
                        foreach (Chambre c in  chambresByLit)
                        {
                            Console.WriteLine("\t" + c);
                        }
                        break;
                    case 0:
                        return;
                    default:
                        HotelConsole.WriteInColor("Choix incorrect", ConsoleColor.Red);
                        break;
                }
            } while (true);

        }

        private static (string nom, string prenom, string tel) AskUserClientsDetails()
        {
            bool isCorrect;
            Console.Write("Quel est le nom du client ? ");
            string nom = Console.ReadLine();
            Console.Write("Quel est le prénom du client ? ");
            string prenom = Console.ReadLine();
            string tel;
            do
            {
                Console.Write("Quel est le numéro de téléphone du client ? ");
                tel = Console.ReadLine();
                isCorrect = int.TryParse(tel, out _) && tel.Length == 10;
                if (!isCorrect)
                {
                    HotelConsole.WriteInColor("Un numéro de téléphone est composé de 10 chiffres", ConsoleColor.Red);
                }
            } while (!isCorrect);
            return (nom, prenom, tel);
        }
        
        private static int AskUserClientNumero(Hotel hotel)
        {
            int numero;
            bool isCorrect;
            do
            {
                Console.Write("Quel est le numéro du client ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out numero);
                if (isCorrect)
                {
                    if (!hotel.ClientExistsByNumero(numero))
                    {
                        HotelConsole.WriteInColor("Client n'exise pas", ConsoleColor.Red);
                        isCorrect = false;
                    }
                }
            } while (!isCorrect);
            return numero;
        }

        private static int AskUserChambreNumero(Hotel hotel)
        {
            int numeroChambre;
            bool isCorrect;
            do
            {
                Console.Write("Quel est le numéro de la chambre à réserver ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out numeroChambre);
                if (isCorrect && !hotel.ChambreExistsByNumero(numeroChambre))
                {
                    HotelConsole.WriteInColor("Cette chambre n'existe pas", ConsoleColor.Red);
                    isCorrect = false;
                }
            } while (!isCorrect);
            return numeroChambre;
        }

        private static List<int> AskUserMultipleChambreNumero(Hotel hotel)
        {
            List<int> chambreNumbers = new List<int>();
            do
            {
                int chambreNumber = AskUserChambreNumero(hotel);
                if (chambreNumbers.Contains(chambreNumber))
                {
                    HotelConsole.WriteInColor("La chambre est déjà dans la réservation", ConsoleColor.Red);
                } else
                {
                    chambreNumbers.Add(chambreNumber);
                }
                if (chambreNumbers.Count == hotel.GetNbChambreOpen())
                {
                    Console.WriteLine("Toutes les chambres sont réservés");
                    return chambreNumbers;
                }
                Console.Write("Ajouter une autre chambre ? (Y/n)");
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer == "n")
                {
                    return chambreNumbers;
                }
            } while (true);
        }

        private static int AskUserReservationNumero(Hotel hotel)
        {
            bool isCorrect;
            int numReservation;
            do
            {
                Console.Write("Quel est le numéro de la réservation à annuler ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out numReservation);
                if (isCorrect && !hotel.ReservationExistsByNumero(numReservation))
                {
                    HotelConsole.WriteInColor("Cette reservation n'existe pas", ConsoleColor.Red);
                    isCorrect = false;
                }
            } while (!isCorrect);
            return numReservation;
        }

        private static ReservationStatut AskUserReservationStatut()
        {
            List<(int num, string msg)> reservationStatutMenu = new() {
                ((int)ReservationStatut.Prevu, "Prévu"),
                ((int)ReservationStatut.EnCours, "En cours"),
                ((int)ReservationStatut.Fini, "Fini"),
                ((int)ReservationStatut.Annule, "Annulé")
            };
            Menu.Classes.Menu.ShowMenu(reservationStatutMenu, "Quel est le statut de la réservation ? ");
            ReservationStatut statut = (ReservationStatut)Menu.Classes.Menu.AskMenuChoice(reservationStatutMenu);
            return statut;
        }

        private static int AskUserNbLit()
        {
            int nbLit;
            bool isCorrect;
            do
            {
                Console.Write("Nombre de lit dans la chambre ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out nbLit);
                if (isCorrect && nbLit <= 0)
                {
                    HotelConsole.WriteInColor("La chambre doit avoir un ou plusieurs lits", ConsoleColor.Red);
                    isCorrect = false;
                }
            } while (!isCorrect);
            return nbLit;
        }

        private static (ChambreStatut statut, int nblit, decimal tarif) AskUserChambreDetails()
        {
            List<(int num, string msg)> chambreStatutMenu = new() {
                ((int)ChambreStatut.Libre, "Libre"),
                ((int)ChambreStatut.Occupe, "Occupé"),
                ((int)ChambreStatut.EnNottoyage, "En nettoyage")
            };
            bool isCorrect;
            Menu.Classes.Menu.ShowMenu(chambreStatutMenu, "Quel est le statut de la chambre ? ");
            ChambreStatut statut = (ChambreStatut)Menu.Classes.Menu.AskMenuChoice(chambreStatutMenu);
            int nbLit = AskUserNbLit();
            decimal tarif;
            do
            {
                Console.Write("Tarif de la chambre ? ");
                isCorrect = decimal.TryParse(Console.ReadLine(), out tarif);
                if (isCorrect && tarif < 0)
                {
                    HotelConsole.WriteInColor("Le tarif de la chambre doit être supérieur ou égal à 0", ConsoleColor.Red);
                    isCorrect = false;
                }
            } while (!isCorrect);
            return (statut, nbLit, tarif);
        }
    }
}
