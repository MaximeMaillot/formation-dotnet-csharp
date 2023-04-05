namespace Figures.Classes
{
    internal class Carre : Figure
    {
        public double Cote { get; set; }
        public Point PointB => new Point(Origine.PosX + Cote, Origine.PosY);
        public Point PointC => new Point(PointB.PosX, PointB.PosY - Cote);
        public Point PointD => new Point(PointC.PosX - Cote, PointC.PosY);

        public Carre(Point point, double cote) : base(point)
        {
            Cote = cote;
        }

        public Carre(double posX, double posY, double cote) : this(new Point(posX, posY), cote) { }


        public override void Deplacement(double posX, double posY)
        {
            base.Deplacement(posX, posY);
        }

        public void Dessiner()
        {
            string horizontal = new string('=', (Convert.ToInt32(Cote)*2));
            string vertical = new string(' ', Convert.ToInt32((Cote)*2));
            string start = "╔" + horizontal.Substring(1, vertical.Length - 1) + "╗";
            string side = "║" + vertical.Substring(1, vertical.Length - 1) + "║";
            string end = "╚" + horizontal.Substring(1, vertical.Length - 1) + "╝";
            for (int i = 0; i < Cote; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(start);
                } else if (i == Cote - 1)
                {
                    Console.WriteLine(end);
                } else
                {
                    Console.WriteLine(side);
                }
            }
        }

        public override string ToString()
        {
            return $"Coordonnées du carré ABCD (cote : {Cote}) : \nA = {Origine}\nB = {PointB}\nC = {PointC}\nD = {PointD}";
        }
    }
}
