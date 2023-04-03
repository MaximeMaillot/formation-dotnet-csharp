namespace Employee.Classes
{
    internal class Salarie
    {
        public static int NbEmployes { get; protected set; }

        public static int SalaireTotal { get; protected set; }

        public string Matricule { get; protected set; }

        public string Service { get; protected set; }

        public string Categorie { get; protected set; }

        public string Nom { get; protected set; }

        public int Salaire { get; protected set; }
        private Salarie()
        {
            NbEmployes++;
        }
        public Salarie(string nom, int salaire, string matricule, string categorie, string service) : this()
        {
            Nom = nom;
            Salaire = salaire;
            SalaireTotal += salaire;
            Matricule = matricule;
            Categorie = categorie;
            Service = service;
        }



        public virtual string GetSalaireString()
        {
            return $"Le salaire de {Nom} est de {Salaire} euros";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
