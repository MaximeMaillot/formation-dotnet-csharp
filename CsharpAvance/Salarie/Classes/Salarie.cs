namespace Demo.Classes
{
    internal class Salarie
    {
        public Salarie()
        {
            NbEmployes++;
        }
        public Salarie(string nom, int salaire) : this()
        {
            Nom = nom;
            Salaire = salaire;
            SalaireTotal += salaire;
        }

        public static int NbEmployes { get; set; }

        public static int SalaireTotal { get; set; }

        public string Matricule { get; set; }

        public string Service { get; set; }

        public string Categorie { get; set; }

        public string Nom { get; set; }

        public int Salaire { get; set; }

        public void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire de {Nom} est de {Salaire} euros");
        }

        public static void AfficherNbEmployes()
        {
            Console.WriteLine($"Il y a {NbEmployes} salariés");
        }

        public static void ShowTotalSalaries()
        {
            Console.WriteLine($"Le montant total des salaires des {NbEmployes} employés est de {SalaireTotal} euros");
            NbEmployes = 0;
        }
    }
}
