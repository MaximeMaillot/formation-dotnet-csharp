using Hostel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Classes.Helper
{
    internal class IHMHelper
    {
        private readonly Hotel _hotel;
        public IHMHelper(Hotel hotel)
        {
            _hotel = hotel;
        }
        // case 1
        public void AddClient()
        {
            
            var (nom, prenom, tel) = AskUserHelper.AskUserClientsDetails();
            try
            {
                _hotel.AddClient(new Client(nom, prenom, tel));
            } catch(PhoneException ex)
            {
                ConsoleHelper.WriteInColor(ex.Message, ConsoleColor.Red);
            }
            catch (UserInputException ex)
            {
                ConsoleHelper.WriteInColor(ex.Message, ConsoleColor.Red);
            }
        }
        // case 2
        public void ShowListClient()
        {
            if (!_hotel.HasClient())
            {
                ConsoleHelper.WriteInColor("Aucun client", ConsoleColor.Red);
                return;
            }
            Console.WriteLine("Liste de clients : ");
            foreach (Client c in _hotel.ClientsHotel)
            {
                Console.WriteLine($"\t{c}");
            }
        }
        // case 3
        public void ShowReservationClient()
        {
            if (!_hotel.HasClient())
            {
                ConsoleHelper.WriteInColor("Aucun client", ConsoleColor.Red);
                return;
            }
            if (!_hotel.HasChambre())
            {
                ConsoleHelper.WriteInColor("Aucune chambre", ConsoleColor.Red);
                return;
            }
            int numeroClient = AskUserHelper.AskUserClientNumero(_hotel);
            List<int> numeroChambres = AskUserHelper.AskUserMultipleChambreNumero(_hotel);
            List<Chambre> chambres = new();
            foreach (int numeroChambre in numeroChambres)
            {
                chambres.Add(_hotel.GetChambreByNumero(numeroChambre));
            }
            try
            {
                _hotel.AddReservation(new Reservation(chambres, _hotel.GetClientByNumero(numeroClient)));
            }
            catch (Exception)
            {
                ConsoleHelper.WriteInColor("Chambre non disponible", ConsoleColor.Red);
            }
        }
        // case 4
        public void AddReservation()
        {
            if (!_hotel.HasClient())
            {
                ConsoleHelper.WriteInColor("Aucun client", ConsoleColor.Red);
                return;
            }
            if (!_hotel.HasChambre())
            {
                ConsoleHelper.WriteInColor("Aucune chambre", ConsoleColor.Red);
                return;
            }
            int numeroClient = AskUserHelper.AskUserClientNumero(_hotel);
            List<int> numeroChambres = AskUserHelper.AskUserMultipleChambreNumero(_hotel);
            List<Chambre> chambres = new();
            foreach (int numeroChambre in numeroChambres)
            {
                chambres.Add(_hotel.GetChambreByNumero(numeroChambre));
            }
            try
            {
                _hotel.AddReservation(new Reservation(chambres, _hotel.GetClientByNumero(numeroClient)));
            }
            catch (Exception)
            {
                ConsoleHelper.WriteInColor("Chambre non disponible", ConsoleColor.Red);
            }
        }
        //case 5
        public void CancelReservation()
        {
            if (!_hotel.HasClient())
            {
                ConsoleHelper.WriteInColor("Aucun client", ConsoleColor.Red);
                return;
            }
            if (!_hotel.HasChambre())
            {
                ConsoleHelper.WriteInColor("Aucune chambre", ConsoleColor.Red);
                return;
            }
            if (!_hotel.HasReservation())
            {
                ConsoleHelper.WriteInColor("Aucune réservation", ConsoleColor.Red);
                return;
            }
            int numReservation = AskUserHelper.AskUserReservationNumero(_hotel);
            _hotel.CancelReservation(numReservation);
        }
        //case 6
        public void ShowListReservations()
        {
            if (!_hotel.HasReservation())
            {
                ConsoleHelper.WriteInColor("Aucune réservation", ConsoleColor.Red);
                return;
            }
            Console.WriteLine("Liste des réservations : ");
            foreach (Reservation r in _hotel.ReservationsHotel)
            {
                Console.WriteLine(r + " :");
                foreach (Chambre c in r.ChambresReservations)
                {
                    Console.WriteLine("\t" + c);
                }
            }
        }
        //case 7
        public void AddChambre()
        {
            var (nblit, tarif) = AskUserHelper.AskUserChambreDetails();
            _hotel.AddChambre(new Chambre(nblit, tarif));
        }
        //case 8
        public void ShowListChambres()
        {
            if (!_hotel.HasChambre())
            {
                ConsoleHelper.WriteInColor("Aucune chambre", ConsoleColor.Red);
                return;
            }
            Console.WriteLine("Liste des chambres : ");
            foreach (Chambre c in _hotel.ChambresHotel)
            {
                Console.WriteLine("\t" + c);
            }
        }
        //case 9
        public void EndReservation()
        {
            if (!_hotel.HasReservation())
            {
                ConsoleHelper.WriteInColor("Aucune réservation", ConsoleColor.Red);
                return;
            }
            int numReservationEnd = AskUserHelper.AskUserReservationNumero(_hotel);
            _hotel.EndReservation(numReservationEnd);
        }
        //case 10
        public void CleanChambre()
        {
            if (!_hotel.HasChambre())
            {
                ConsoleHelper.WriteInColor("Aucune réservation", ConsoleColor.Red);
                return;
            }
            int numChambreClean = AskUserHelper.AskUserChambreNumero(_hotel);
            try
            {
                _hotel.CleanChambre(numChambreClean);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteInColor(ex.Message, ConsoleColor.Red);
            }
        }
        //case 11
        public void ShowChamberListByNbLit()
        {
            int nbLit = AskUserHelper.AskUserNbLit();
            List<Chambre> chambresByLit = _hotel.GetChambresAvailableByNbLit(nbLit);
            Console.WriteLine($"Liste des chambres disponible avec au moins {nbLit} lits");
            foreach (Chambre c in chambresByLit)
            {
                Console.WriteLine("\t" + c);
            }
        }
    }
}
