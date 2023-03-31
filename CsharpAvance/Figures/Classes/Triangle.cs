namespace Figures.Classes
{
    internal class Triangle : Figure
    {
        public double Hauteur { get; set; }
        public double Tbase { get; set; }

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
            return base.ToString();
        }
    }
}
