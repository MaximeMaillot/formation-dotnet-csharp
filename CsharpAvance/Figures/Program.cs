using Figures.Classes;

List<Figure> figures = new()
{
    new Carre(new Point(-1.5,3.5), 2),
    new Rectangle(new Point(0,11), 10, 2),
    new Triangle(new Point(-6.5,-9), 10, 5),
    new Rectangle(new Point(-11.5,6), 25, 10),
    new Carre(new Point(-11.5, 13.5), 25),
    new Carre(2, 4, 2),
    new Rectangle(2, 4, 3, 5),
    new Triangle(2, 4, 4, 5),
};

foreach(Figure figure in figures)
{
    if (figure is Carre)
    {
        Carre? carre = figure as Carre;
        Console.WriteLine(carre);
        //carre.Dessiner();
    }
    else if (figure is Rectangle)
    {
        Rectangle? rectangle = figure as Rectangle;
        Console.WriteLine(rectangle);
        //rectangle.Dessiner();
    }
    else if (figure is Triangle)
    {
        Triangle? triangle = figure as Triangle;
        Console.WriteLine(triangle);
        //triangle.Dessiner();
    }
    else
    {
        throw new Exception();
    }
}

Console.WriteLine("Deplacement du 1er carré par (1,3) :");
figures[0].Deplacement(1, 3);
Console.WriteLine(figures[0]);