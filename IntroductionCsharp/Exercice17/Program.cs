Console.Write("--- Quelle boisson souhaitez vous ? ---\n" +
    "Liste de boissons disponibles\n" +
    "\t1) Eau Plate\n" +
    "\t2) Eau Gazeuse\n" +
    "\t3) Coca-Cola\n" + 
    "\t4) Fanta\n" +
    "\t5) Sprite\n" +
    "\t6) Orangina\n" +
    "\t7) 7up\n" +
    "Faites votre choix (1 à 7) : ");
int choix;
int.TryParse(Console.ReadLine(), out choix);
string boisson;
switch (choix)
{
    case 1:
        boisson = "Eau Plate";
        break;
    case 2:
        boisson = "Eau Gazeuse";
        break;
    case 3:
        boisson = "Coca-Cola";
        break;
    case 4:
        boisson = "Fanta";
        break;
    case 5:
        boisson = "Sprite";
        break;
    case 6:
        boisson = "Orangina";
        break;
    case 7:
        boisson = "7up";
        break;
    default:
        boisson = "";
        break;
}

if (boisson == "")
{
    Console.WriteLine("\nMauvais choix");
} else
{
    Console.WriteLine($"\nVotre {boisson} est servi...");
}