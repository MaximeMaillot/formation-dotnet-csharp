namespace Figures.Classes
{
    internal class Rectangle : Figure
    {
        public double Longueur { get; set; }
        public double Largeur { get; set; }

        public Rectangle(Point origine, double longueur, double largeur) : base(origine)
        {
            Longueur = longueur;
            Largeur = largeur;
        }

        public override void Deplacement(double posX, double posY)
        {
            base.Deplacement(posX, posY);
        }
    }
}
