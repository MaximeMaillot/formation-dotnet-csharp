using Demo.Classes;

List<Chaise> chaises = new();
chaises.Add(new Chaise());
chaises.Add(new Chaise(2, "Noir", "Métal"));
chaises.Add(new Chaise(6, "Bleue", "Plastique"));
foreach (Chaise chaise in chaises)
{
    Console.WriteLine(chaise.ToString());
}
