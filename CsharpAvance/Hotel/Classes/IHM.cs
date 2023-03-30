namespace Hostel.Classes
{
    internal interface IHM
    {
        static void Start()
        {
            int choice;

            Console.Write("Quel est le nom de l'Hôtel ? ");
            Hotel hotel = new Hotel(Console.ReadLine());

            hotel.AddChambre(new Chambre("Open", 12, 100));
            hotel.AddChambre(new Chambre("Open", 10, 90));
            hotel.AddChambre(new Chambre("Closed", 6, 250));

            do
            {
                Console.WriteLine("=== Menu Principal ===\n");
                Console.WriteLine("1. Ajouter un client");
                Console.WriteLine("2. Afficher la liste des clients");
                Console.WriteLine("3. Afficher les réservations d'un client");
                Console.WriteLine("4. Ajouter une réservation");
                Console.WriteLine("5. Annuler une réservation");
                Console.WriteLine("6. Afficher la liste des réservations");
                Console.WriteLine("0. Quitter");
                int choix;
                bool isCorrect;
                do
                {
                    Console.Write("Votre choix : ");
                    isCorrect = int.TryParse(Console.ReadLine(), out choix);
                } while (!isCorrect);
                Console.Clear();
                switch (choix)
                {
                    case 1: // TODO Check numtel
                        Console.Write("Quel est le prénom du client ? ");
                        string prenom = Console.ReadLine();
                        Console.Write("Quel est le nom du client ? ");
                        string nom = Console.ReadLine();
                        Console.Write("Quel est le numéro de téléphone du client ? ");
                        string tel = Console.ReadLine();
                        hotel.AddClient(new Client(nom, prenom, tel));
                        break;
                    case 2:
                        hotel.ShowClients();
                        break;
                    case 3: 
                        if (!hotel.HasClients())
                        {
                            HotelConsole.WriteInColor("Aucun client", ConsoleColor.Red);
                            break;
                        }
                        int numero;
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
                        hotel.ShowReservationByClientNumero(numero);
                        break;
                    case 4:
                        if (!hotel.HasClients())
                        {
                            HotelConsole.WriteInColor("Aucun client", ConsoleColor.Red);
                            break;
                        }
                        if (!hotel.hasChambres())
                        {
                            HotelConsole.WriteInColor("Aucune chambre", ConsoleColor.Red);
                            break;
                        }
                        int numeroClient;
                        do {
                            Console.Write("Quel est le numéro du client ? ");
                            isCorrect = int.TryParse(Console.ReadLine(), out numeroClient);
                            if (!hotel.ClientExistsByNumero(numeroClient))
                            {
                                HotelConsole.WriteInColor("Ce client n'existe pas", ConsoleColor.Red);
                                isCorrect = false;
                            }
                        } while (!isCorrect);
                        int numeroChambre;
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
                        hotel.AddReservation(new Reservation(hotel.GetChambreByNumero(numeroChambre), hotel.GetClientByNumero(numeroClient)));
                        break;
                    case 5: // TODO Faire des limitations
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
                        hotel.RemoveReservation(hotel.GetReservationByNumero(numReservation));
                        break;
                    case 6:
                        hotel.ShowReservations();
                        break;
                    case 0:
                        return;
                    default:
                        HotelConsole.WriteInColor("Choix incorrect", ConsoleColor.Red);
                        break;
                }
            } while (true);

        }
    }
}
