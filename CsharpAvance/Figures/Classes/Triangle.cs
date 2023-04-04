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

        public override void Deplacement(double posX, double posY)
        {
            base.Deplacement(posX, posY);
        }

        public override string ToString()
        {
            return $"A = {Origine}\nB = {PointB}\nC = {PointC}";
        }
    }
}
