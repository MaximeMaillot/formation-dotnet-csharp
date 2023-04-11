using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.Classes
{
    internal class Etudiant
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private int _numClasse;
        private DateTime? _dateDiplome;

        public Etudiant(string nom, string prenom, int numClasse, DateTime? dateDiplome = null)
        {
            Nom = nom;
            Prenom = prenom;
            NumClasse = numClasse;
            DateDiplome = dateDiplome;
        }

        public Etudiant(int id, string nom, string prenom, int numClasse, DateTime? dateDiplome = null) : this(nom, prenom, numClasse, dateDiplome)
        {
            _id = id;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public int NumClasse { get => _numClasse; set => _numClasse = value; }
        public DateTime? DateDiplome { get => _dateDiplome; set => _dateDiplome = value; }

        public override string ToString()
        {
            string result = $"{_id} : {Nom} {Prenom} dans la classe {NumClasse} {DateDiplome}";
            if (DateDiplome != null)
            {
                result += $" ayant obtenu son diplôme en {DateDiplome}";
            }
            return result;
        }
    }
}
