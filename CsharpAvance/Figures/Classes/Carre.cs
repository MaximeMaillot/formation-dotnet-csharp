namespace Figures.Classes
{
    internal class Carre : Figure
    {
        public double Cote { get; set; }

        public Carre(Point point, double cote) : base(point)
        {
            Cote = cote;
        }

        public override void Deplacement(double posX, double posY)
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
