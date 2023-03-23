/* Hypothénuse */
Console.WriteLine("--- Calcul la longueur de l'hypothénuse ---");
Console.Write("Entrez la longueur du premier côté (en cm) : ");
float premierCote = float.Parse(Console.ReadLine());
Console.Write("Entrez la longueur du deuxième côté (en cm) : ");
float deuxiemeCote = float.Parse(Console.ReadLine());
Console.WriteLine($"Le longueur de l'hypothénuse est : {Math.Sqrt(premierCote * premierCote + deuxiemeCote * deuxiemeCote):0.00} cm");
