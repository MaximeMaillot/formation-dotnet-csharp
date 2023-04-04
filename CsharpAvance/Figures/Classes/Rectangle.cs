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

        public override void Deplacement(double posX, double posY)
        {
            base.Deplacement(posX, posY);
        }

        public override string ToString()
        {
            return $"A = {Origine}\nB = {PointB}\nC = {PointC}\nD = {PointD}";
        }
    }
}
