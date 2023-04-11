using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.Classes
{
    internal static class IHM
    {
        public static void Start ()
        {
            List<(int choice, string text, Action action)> menu = new()
            {
                (1, "Ajouter un étudiant", AskAddEtudiant),
                (2, "Afficher tous les étudiants", ShowAllEtudiants),
                (3, "Afficher les étudiants d'une classe", ShowEtudiantByClass),
                (4, "Supprimer un étudiant", AskRemoveEtudiant),
                (5, "test", Test),
                (0, "Quitter", null)
            };
            Menu.Classes.Menu.HandleIHM(menu, "--- Menu Étudiant ---");
        }

        public static void AskAddEtudiant()
        {
            string nom = AskUserString("Donnez le nom de l'etudiant : ");
            string prenom = AskUserString("Donnez le prénom de l'étudiant : ");
            int numClasse = AskUserInt("Donnez votre numéro de classe : ");
            DateTime? dateDiplome = AskUserDateTime("Quel est la date du diplôme (Ne rien rentrez pour mettre une date nulle) ? ");

            DataBase db = new DataBase(new SqlConnection("Data Source=(localdb)\\cours-dotnet;Integrated Security=True"));

            int res = db.InsertEtudiant(new Etudiant(nom, prenom, numClasse, dateDiplome));
            Console.WriteLine($"Ajout de l'étudiant avec id {res}");
        }

        public static void ShowAllEtudiants()
        {
            DataBase db = new DataBase(new SqlConnection("Data Source=(localdb)\\cours-dotnet;Integrated Security=True"));

            List<Etudiant> etudiants = db.GetEtudiants();

            foreach (Etudiant e in etudiants)
            {
                Console.WriteLine(e);
            }
        }

        public static void ShowEtudiantByClass()
        {
            int numClasse = AskUserInt("Donnez votre numéro de classe : ");

            DataBase db = new DataBase(new SqlConnection("Data Source=(localdb)\\cours-dotnet;Integrated Security=True"));

            List<Etudiant> etudiants = db.GetEtudiantsByClass(numClasse);

            foreach (Etudiant e in etudiants)
            {
                Console.WriteLine(e);
            }
        }

        public static void AskRemoveEtudiant()
        {
            int id = AskUserInt("Donnez l'id de l'étudiant à supprimer : ");

            DataBase db = new DataBase(new SqlConnection("Data Source=(localdb)\\cours-dotnet;Integrated Security=True"));

            if (db.RemoveEtudiant(id))
            {
                Console.WriteLine($"Suppression de l'étudiant avec succès");
            } else
            {
                Console.WriteLine($"Echec de la suppression de l'étudiant");
            }
        }

        public static void Test()
        {
            DataBase db = new DataBase(new SqlConnection("Data Source=(localdb)\\cours-dotnet;Integrated Security=True"));

            EtudiantFilter filter = new EtudiantFilter();
            filter.etudiant_id = 1;
            //filter.nom = "Mondello";
            //filter.prenom = "Gianni";
            filter.num_classe = 1;
            //filter.date_diplome = ;


            List<Etudiant> etudiants = db.GetEtudiantsByFilter(filter);
            foreach (Etudiant e in etudiants )
            {
                Console.WriteLine(e);
            }

        }

        public static int AskUserInt(string msg, string error = "Rentrez un entier valide")
        {
            int result;
            bool isCorrect;
            do
            {
                Console.Write(msg);
                isCorrect = int.TryParse(ReadLine(), out result);
                if (!isCorrect || result < 0)
                {
                    Console.WriteLine(error);
                }
            } while (!isCorrect);
            return result;
        }

        public static bool ParseUserString(string data, out string result)
        {
            if (data == null || data.Length == 0)
            {
                result = "";
                return false;
            }
            result = data;
            return true;
        }

        public static DateTime? AskUserDateTime(string msg, string error = "Rentrez une date correct")
        {
            do
            {
                Console.Write(msg);
                if (!ParseUserString(ReadLine(), out string ask))
                {
                    return null;
                }
                if (DateTime.TryParse(ask, out DateTime date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine(error);
                }
            } while (true);
        }

        public static string AskUserString(string msg, string error = "Rentrez une chaîne de caractères valide")
        {
            string result;
            bool isCorrect;
            do
            {
                Console.Write(msg);
                isCorrect = ParseUserString(ReadLine(), out result) ;
                if (!isCorrect)
                {
                    Console.WriteLine(error);
                }
            } while (!isCorrect);
            return result;
        }

        public static string ReadLine()
        {
            return (Console.ReadLine() ?? "").Trim();
        }
    }
}
