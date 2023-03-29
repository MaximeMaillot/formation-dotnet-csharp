using Demo.Classes;

List<Chaise> chaises = new()
{
    new Chaise(),
    new Chaise(2, "Noir", "Métal"),
    new Chaise(6, "Bleue", "Plastique")
};
foreach (Chaise chaise in chaises)
{
    Console.WriteLine(chaise.ToString());
}
