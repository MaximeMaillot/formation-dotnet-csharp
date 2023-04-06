using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Classes.Helper
{
    internal static class AskUserHelper
    {
        public static (string nom, string prenom, string tel) AskUserClientsDetails()
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
                    HotelConsoleHelper.WriteInColor("Un numéro de téléphone est composé de 10 chiffres", ConsoleColor.Red);
                }
            } while (!isCorrect);
            return (nom, prenom, tel);
        }

        public static int AskUserClientNumero(Hotel hotel)
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
                        HotelConsoleHelper.WriteInColor("Client n'exise pas", ConsoleColor.Red);
                        isCorrect = false;
                    }
                }
            } while (!isCorrect);
            return numero;
        }

        public static int AskUserChambreNumero(Hotel hotel)
        {
            int numeroChambre;
            bool isCorrect;
            do
            {
                Console.Write("Quel est le numéro de la chambre ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out numeroChambre);
                if (isCorrect && !hotel.ChambreExistsByNumero(numeroChambre))
                {
                    HotelConsoleHelper.WriteInColor("Cette chambre n'existe pas", ConsoleColor.Red);
                    isCorrect = false;
                }
            } while (!isCorrect);
            return numeroChambre;
        }

        public static List<int> AskUserMultipleChambreNumero(Hotel hotel)
        {
            List<int> chambreNumbers = new List<int>();
            do
            {
                int chambreNumber = AskUserChambreNumero(hotel);
                if (chambreNumbers.Contains(chambreNumber))
                {
                    HotelConsoleHelper.WriteInColor("La chambre est déjà dans la réservation", ConsoleColor.Red);
                }
                else
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

        public static int AskUserReservationNumero(Hotel hotel)
        {
            bool isCorrect;
            int numReservation;
            do
            {
                Console.Write("Quel est le numéro de la réservation ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out numReservation);
                if (isCorrect && !hotel.ReservationExistsByNumero(numReservation))
                {
                    HotelConsoleHelper.WriteInColor("Cette reservation n'existe pas", ConsoleColor.Red);
                    isCorrect = false;
                }
            } while (!isCorrect);
            return numReservation;
        }

        public static ReservationStatut AskUserReservationStatut()
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

        public static int AskUserNbLit()
        {
            int nbLit;
            bool isCorrect;
            do
            {
                Console.Write("Nombre de lit dans la chambre ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out nbLit);
                if (isCorrect && nbLit <= 0)
                {
                    HotelConsoleHelper.WriteInColor("La chambre doit avoir un ou plusieurs lits", ConsoleColor.Red);
                    isCorrect = false;
                }
            } while (!isCorrect);
            return nbLit;
        }

        public static (int nblit, decimal tarif) AskUserChambreDetails()
        {
            int nbLit = AskUserNbLit();
            decimal tarif;
            bool isCorrect;
            do
            {
                Console.Write("Tarif de la chambre ? ");
                isCorrect = decimal.TryParse(Console.ReadLine(), out tarif);
                if (isCorrect && tarif < 0)
                {
                    HotelConsoleHelper.WriteInColor("Le tarif de la chambre doit être supérieur ou égal à 0", ConsoleColor.Red);
                    isCorrect = false;
                }
            } while (!isCorrect);
            return (nbLit, tarif);
        }
    }
}
