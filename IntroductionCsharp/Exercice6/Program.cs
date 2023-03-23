static float parseWithCulture(string line)
{
    if (line == null)
    {
        return 0;
    }
    return float.Parse(line, System.Globalization.CultureInfo.InvariantCulture);
}

/* Carré */
Console.WriteLine("--- Calcul du périmètre et de l'aire d'un carré ---");
Console.Write("Entrez la longueur d'un côté d'un carré (en cm) : ");
float cote = parseWithCulture(Console.ReadLine());
Console.WriteLine("Le périmètre du carré est : " + (cote * 4) + " cm");
Console.WriteLine("L'aire du carré est : " + (cote * cote) + " cm²");

/* Rectangle */
Console.WriteLine("--- Calcul du périmètre et de l'aire d'un rectangle ---");
Console.Write("Entrez la longueur du rectangle (en cm) : ");
float longueur = parseWithCulture(Console.ReadLine());
Console.Write("Entrez la largeur du rectangle (en cm) : ");
float largeur = parseWithCulture(Console.ReadLine());
Console.WriteLine("Le périmètre du rectangle est : " + ((largeur + longueur) * 2) + " cm");
Console.WriteLine("L'aire du carré est : " + (largeur * longueur) + " cm²");
