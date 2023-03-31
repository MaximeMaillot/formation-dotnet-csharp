namespace Employee.Classes
{
    internal class Salarie
    {
        public Salarie()
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

        public static int NbEmployes { get; set; }

        public static int SalaireTotal { get; set; }

        public string Matricule { get; set; }

        public string Service { get; set; }

        public string Categorie { get; set; }

        public string Nom { get; set; }

        public int Salaire { get; set; }

        public virtual string GetSalaireString()
        {
            return $"Le salaire de {Nom} est de {Salaire} euros";
        }

        public static string GetNbEmployesString()
        {
            return $"Il y a {NbEmployes} salariés";
        }

        public static string GetTotalSalariesString()
        {
            NbEmployes = 0;
            return $"Le montant total des salaires des {NbEmployes} employés est de {SalaireTotal} euros";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
