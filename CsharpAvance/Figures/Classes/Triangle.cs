namespace Figures.Classes
{
    internal class Triangle : Figure
    {
        public double Hauteur { get; set; }
        public double Tbase { get; set; }
        public Point PointB => new Point(Origine.PosX + Tbase, Origine.PosY);
        public Point PointC => new Point(PointB.PosX - Tbase/2, PointB.PosY + Hauteur);

        public Triangle(Point origine, double hauteur, double tbase) : base(origine)
        {
            Hauteur = hauteur;
            Tbase = tbase;
        }

        public Triangle(double posX, double posY, double hauteur, double tbase) : this(new Point(posX, posY), hauteur, tbase){}

        public override void Deplacement(double posX, double posY)
        {
            base.Deplacement(posX, posY);
        }

        [Obsolete("Dessiner ne marche pas pour les triangles")]
        public void Dessiner() // Don't work
        {
            int middle = (int)Math.Floor(Tbase / 2);
            int separation = 1;
            for (int i = 0; i < Hauteur + 1; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(new string(' ', middle) + '^');
                    middle--;
                } else if (i == Hauteur)
                {
                    Console.WriteLine('/' + new string('_', (int)Math.Round(Tbase - 1)) + '\\');
                } else
                {
                    Console.WriteLine(new string(' ', middle) + '/' + new string (' ', separation) + '\\');
                    middle--;
                    separation +=2;
                }
            }
        }

        public override string ToString()
        {
            return $"Coordonnées du triangle ABC (hauteur : {Hauteur}, base : {Tbase}) : \nA = {Origine}\nB = {PointB}\nC = {PointC}";
        }
    }
}
