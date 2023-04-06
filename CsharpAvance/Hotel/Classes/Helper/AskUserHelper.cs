using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hostel.Exceptions;

namespace Hostel.Classes.Helper
{
    internal static class AskUserHelper
    {

        public static T LoopUntilCorrect<T>(Func<T> action)
        {
            T item;
            do
            {
                try
                {
                    item = action();
                    break;
                }
                catch (UserInputException ex)
                {
                    ConsoleHelper.WriteInColor(ex.Message, ConsoleColor.Red);
                }
                catch (FormatException)
                {
                    ConsoleHelper.WriteInColor("Entrez une valeur correcte", ConsoleColor.Red);
                }
                catch (OverflowException)
                {
                    ConsoleHelper.WriteInColor("Entrez un nombre correct", ConsoleColor.Red);
                }
            } while (true);
            return item;
        }

        public static T LoopUntilCorrect<T>(Func<Hotel, T> action, Hotel hotel)
        {
            T item;
            do
            {
                try
                {
                    item = action(hotel);
                    break;
                }
                catch (UserInputException ex)
                {
                    ConsoleHelper.WriteInColor(ex.Message, ConsoleColor.Red);
                }
                catch (FormatException)
                {
                    ConsoleHelper.WriteInColor("Entrez une valeur correcte", ConsoleColor.Red);
                }
                catch (OverflowException)
                {
                    ConsoleHelper.WriteInColor("Entrez un nombre correct", ConsoleColor.Red);
                }
            } while (true);
            return item;
        }

        /// <exception cref="UserInputException">This exception is thrown if the input of the user is incorrect</exception>
        public static int AskUser(out int userInput, string question, string error, int min = int.MaxValue, int max = int.MaxValue)
        {
            Console.Write(question);
            userInput = Convert.ToInt32(ConsoleHelper.ReadLine());
            if (userInput >= max || userInput < min)
            {
                throw new UserInputException(error);
            }
            return userInput;
        }

        /// <exception cref="UserInputException">This exception is thrown if the input of the user is incorrect</exception>
        public static string AskUser(out string userInput, string question, string error, int minLength = 1, int maxLength = 200)
        {
            Console.Write(question);
            userInput = ConsoleHelper.ReadLine();
            if (userInput.Length < minLength || userInput.Length >= maxLength)
            {
                throw new UserInputException(error);
            }
            return userInput;
        }

        public static (string nom, string prenom, string tel) AskUserClientsDetails()
        {
            string nom = LoopUntilCorrect(AskUserFirstName);
            string prenom = LoopUntilCorrect(AskUserLastName);
            string tel = LoopUntilCorrect(AskUserPhone);
            return (nom, prenom, tel);
        }

        /// <exception cref="UserInputException">This exception is thrown if the input of the user is incorrect</exception>
        public static string AskUserFirstName()
        {
            Console.Write("Quel est le nom du client ? ");
            string nom = ConsoleHelper.ReadLine();
            if (nom.Length == 0)
            {
                throw new UserInputException("Le nom a un format incorrect");
            }
            return nom;
        }
        /// <exception cref="UserInputException">This exception is thrown if the input of the user is incorrect</exception>
        public static string AskUserLastName()
        {
            Console.Write("Quel est le prénom du client ? ");
            string prenom = ConsoleHelper.ReadLine();
            if (prenom.Length == 0)
            {
                throw new UserInputException("Le prénom a un format incorrect");
            }
            return prenom;
        }
        /// <exception cref="PhoneException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public static string AskUserPhone()
        {
            Console.Write("Quel est le numéro de téléphone du client ? ");
            string tel = ConsoleHelper.ReadLine();
            if (tel.Length != 10 || !tel.StartsWith("0"))
            {
                throw new PhoneException("Un numéro de téléphone commence par 0 et est composé de 10 chiffres");
            }
            return tel;
        }
        /// <exception cref="HotelException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public static int AskUserClientNumero(Hotel hotel)
        {
            Console.Write("Quel est le numéro du client ? ");
            int numeroClient = Convert.ToInt32(ConsoleHelper.ReadLine());
            if (!hotel.ClientExistsByNumero(numeroClient))
            {
                throw new HotelException("Le client n'exise pas");
            }
            return numeroClient;
        }
        /// <exception cref="HotelException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public static int AskUserChambreNumero(Hotel hotel)
        {
            Console.Write("Quel est le numéro de la chambre ? ");
            int numeroChambre = Convert.ToInt32(ConsoleHelper.ReadLine());
            if (!hotel.ChambreExistsByNumero(numeroChambre))
            {
                throw new HotelException("Cette chambre n'exise pas");
            }
            return numeroChambre;
        }

        public static List<int> AskUserMultipleChambreNumero(Hotel hotel)
        {
            List<int> chambreNumbers = new();
            do
            {
                int chambreNumber = LoopUntilCorrect(AskUserChambreNumero, hotel);
                if (chambreNumbers.Contains(chambreNumber))
                {
                    ConsoleHelper.WriteInColor("La chambre est déjà dans la réservation", ConsoleColor.Red);
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
                string answer = ConsoleHelper.ReadLine().ToLower();
                if (answer == "n")
                {
                    return chambreNumbers;
                }
            } while (true);
        }
        /// <exception cref="HotelException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public static int AskUserReservationNumero(Hotel hotel)
        {
            Console.Write("Quel est le numéro de la réservation ? ");
            int numReservation = Convert.ToInt32(ConsoleHelper.ReadLine());

            if (!hotel.ReservationExistsByNumero(numReservation))
            {
                throw new HotelException("Cette reservation n'existe pas");
            }
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
        /// <exception cref="UserInputException">This exception is thrown if the input of the user is incorrect</exception>
        public static int AskUserNbLit()
        {
            Console.Write("Combien la chambre possède t-elle de lit ? ");
            int nbLit = Convert.ToInt32(ConsoleHelper.ReadLine());
            if (nbLit <= 0)
            {
                throw new UserInputException("Entrer un nombre de lit correct");
            }
            return nbLit;
        }
        /// <exception cref="UserInputException">This exception is thrown if the input of the user is incorrect</exception>
        public static (int nblit, decimal tarif) AskUserChambreDetails()
        {
            int nbLit = AskUserNbLit();
            decimal tarif = AskUserTarif();
            return (nbLit, tarif);
        }
        /// <exception cref="UserInputException">This exception is thrown if the input of the user is incorrect</exception>
        public static decimal AskUserTarif()
        {
            Console.Write("Combien la chambre possède t-elle de lit ? ");
            decimal tarif = Convert.ToDecimal(ConsoleHelper.ReadLine());
            if (tarif <= 0)
            {
                throw new UserInputException("Entrer un prix correct");
            }
            return tarif;
        }
    }
}
