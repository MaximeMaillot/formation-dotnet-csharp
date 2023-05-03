using DemoHotel.Data;
using DemoHotel.Models;
using Helper.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHotel.Classes
{
    internal class IHM
    {
        private HotelDbContext _context;

        public IHM(HotelDbContext context)
        {
            _context = context;
        }

        public void Start()
        {
            List<(int, string, Action)> menu = new()
            {
                (1, "Ajouter un client", AddClient),
                (2, "Afficher la liste des clients", ShowClients),
                (3, "Afficher les réservations d'un client", ShowClientReservation),
                (4, "Ajouter une réservation", AddReservation),
                (5, "Annuler une réservation", RemoveReservation),
                (6, "Afficher la liste des réservations", ShowReservationsList),
                (0, "Quitter", null),
            };
            Menu.HandleIHM(menu, "--- Gestion de l'Hotel ---");
        }

        public void AddClient()
        {
            Client client = new Client()
            {
                Nom = AskUser.AskUserString("Donnez le nom du client : "),
                Prenom = AskUser.AskUserString("Donnez le prénom du client : "),
                Telephone = AskUser.AskUserString("Donnez le numéro de téléphone du client : ")
            };
            _context.Clients.Add(client);
            _context.SaveChanges();
            ConsoleHelper.WriteLineInColor("Client ajouté avec succès", ConsoleColor.Green);
        }

        public void ShowClients()
        {
            ConsoleHelper.WriteLineInColor("Liste des clients : ", ConsoleColor.Yellow);
            foreach (var client in _context.Clients.OrderBy(c => c.Nom))
            {
                Console.WriteLine(client);
            }
        }

        public void ShowClientReservation()
        {
            int id = AskUser.AskUserInt("Donnez l'ID du client : ");
            List<Reservation> reservations = _context.Reservations.Where(reservation => reservation.ClientId == id).ToList();
            if (reservations.Count == 0)
            {
                ConsoleHelper.WriteLineInColor("Client n'a pas de réservation", ConsoleColor.Red);
                return;
            }
            ConsoleHelper.WriteLineInColor("Liste des réservations du client : ", ConsoleColor.Yellow);
            foreach (Reservation reservation in reservations)
            {
                Console.WriteLine(reservation);
            }
        }

        public void AddReservation()
        {
            int client_id = AskUser.AskUserInt("Donnez l'ID du client : ");
            Client client = _context.Clients.Find(client_id);
            if (client == null)
            {
                ConsoleHelper.WriteLineInColor("Client non trouvé", ConsoleColor.Red);
                return;
            }
            int chambre_id = AskUser.AskUserInt("Donnez l'ID de la chambre : ");
            Chambre chambre = _context.Chambres.Find(chambre_id);
            if (chambre == null)
            {
                ConsoleHelper.WriteLineInColor("Chambre non trouvé", ConsoleColor.Red);
                return;
            }
            Reservation reservation = new Reservation()
            {
                ClientId = client_id,
            };
            reservation.Chambres.Add(chambre);
            var newReservation = _context.Reservations.Add(reservation);
            chambre.ReservationId = newReservation.Entity.Id;
            _context.SaveChanges();
            ConsoleHelper.WriteLineInColor("Reservation ajouté avec succès", ConsoleColor.Green);
        }

        public void RemoveReservation()
        {
            int id = AskUser.AskUserInt("Donnez l'ID de la réservation : ");
            Reservation reservation = _context.Reservations.Find(id);
            if (reservation == null)
            {
                ConsoleHelper.WriteLineInColor("La réservation n'existe pas", ConsoleColor.Red);
                return;
            }
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            ConsoleHelper.WriteLineInColor("Réservation supprimé avec succès", ConsoleColor.Green);
        }

        public void ShowReservationsList()
        {
            List<Reservation> reservations = _context.Reservations.Include(b => b.Client).Include(b => b.Chambres).ToList();
            ConsoleHelper.WriteLineInColor("Liste des reservations : ", ConsoleColor.Yellow);
            foreach(Reservation reservation in reservations)
            {
                Console.WriteLine("\t" + reservation);
            }
        }
    }
}
