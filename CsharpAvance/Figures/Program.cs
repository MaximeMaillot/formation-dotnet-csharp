using Figures.Classes;

List<Figure> figures = new()
{
    new Carre(new Point(-1.5,3.5), 2),
    new Rectangle(new Point(0,11), 10, 2),
    new Triangle(new Point(-6.5,-9), 10, 5),
    new Rectangle(new Point(-11.5,6), 25, 10),
    new Carre(new Point(-11.5, 13.5), 25)
};

foreach(Figure figure in figures)
{
    if (figure is Carre)
    {
        Console.WriteLine("Coordonnées du carré ABCD : ");
        Carre carre = figure as Carre;
        Console.WriteLine(carre);
    }
    else if (figure is Rectangle)
    {
        Console.WriteLine("Coordonnées du rectangle ABCD : ");
        Rectangle rectangle = figure as Rectangle;
        Console.WriteLine(rectangle);
    }
    else if (figure is Triangle)
    {
        Console.WriteLine("Coordonnées du triangle ABC : ");
        Triangle triangle = figure as Triangle;
        Console.WriteLine(triangle);
    }
    else
    {
        throw new Exception();
    }
}

Console.WriteLine("Deplacement du 1er carré par (1,3) :");
figures[0].Deplacement(1, 3);
Console.WriteLine(figures[0]);