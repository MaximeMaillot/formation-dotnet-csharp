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
