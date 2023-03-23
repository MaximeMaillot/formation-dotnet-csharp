/* Nombre entier */
Console.Write("Veuillez saisir un nombre entier : ");
int premierNombre = int.Parse(Console.ReadLine());
Console.Write("Veuillez saisir un nombre entier : ");
int deuxiemeNombre = int.Parse(Console.ReadLine());
int somme = premierNombre + deuxiemeNombre;
Console.WriteLine($"La somme de ces deux nombres est : {somme}");


/* Nombre reel */
Console.Write("Veuillez saisir un nombre reel : ");
// Use System.Globalization.CultureInfo.InvariantCulture to avoid an exception when using dot instead of comma
float premierNombreF = float.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
Console.Write("Veuillez saisir un nombre reel : ");
float deuxiemeNombreF = float.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
float sommeF = premierNombreF + deuxiemeNombreF;
Console.WriteLine($"La somme de ces deux nombres est : {sommeF}");
