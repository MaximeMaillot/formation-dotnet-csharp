namespace Figures.Classes
{
    internal class Rectangle : Figure
    {
        public double Longueur { get; set; }
        public double Largeur { get; set; }

        public Point PointB => new Point(Origine.PosX + Longueur, Origine.PosY);
        public Point PointC => new Point(PointB.PosX, PointB.PosY - Largeur);
        public Point PointD => new Point(PointC.PosX - Longueur, PointC.PosY);

        public Rectangle(Point origine, double longueur, double largeur) : base(origine)
        {
            Longueur = longueur;
            Largeur = largeur;
        }

        public Rectangle(double posX, double posY, double longueur, double largeur) : this(new Point(posX, posY), longueur, largeur) { }

        public override void Deplacement(double posX, double posY)
        {
            base.Deplacement(posX, posY);
        }

        public void Dessiner()
        {
            string horizontal = new string('=', (Convert.ToInt32(Longueur) * 2));
            string vertical = new string(' ', Convert.ToInt32((Longueur) * 2));
            string start = "╔" + horizontal.Substring(1, vertical.Length - 1) + "╗";
            string side = "║" + vertical.Substring(1, vertical.Length - 1) + "║";
            string end = "╚" + horizontal.Substring(1, vertical.Length - 1) + "╝";
            for (int i = 0; i < Largeur; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(start);
                }
                else if (i == Largeur - 1)
                {
                    Console.WriteLine(end);
                }
                else
                {
                    Console.WriteLine(side);
                }
            }
        }

        public override string ToString()
        {
            return $"Coordonnées du rectangle ABCD (longueur : {Longueur}, largeur : {Largeur}) : \nA = {Origine}\nB = {PointB}\nC = {PointC}\nD = {PointD}";
        }
    }
}
