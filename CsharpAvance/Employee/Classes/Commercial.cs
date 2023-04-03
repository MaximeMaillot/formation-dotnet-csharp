using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Classes
{
    internal class Commercial : Salarie
    {
        public int ChiffreAffaires { get; private set; } = 0;
        public int Comission { get; private set; } = 0;

        public Commercial(Salarie salarie, int chiffreAffaires, int comission) : base(salarie.Nom, salarie.Salaire, salarie.Matricule, salarie.Categorie, salarie.Service)
        {
            ChiffreAffaires = chiffreAffaires;
            Comission = comission;
        }

        public override string GetSalaireString()
        {
            return base.GetSalaireString() + "\n" + $"Le salaire avec comission de {Nom} est de {Salaire + (ChiffreAffaires * Comission / 100)} euros"; ;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
