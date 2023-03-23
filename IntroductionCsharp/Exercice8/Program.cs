/* Hypothénuse */
Console.Write("Entrez le prix HT de l'objet (en Euros) : ");
decimal prixHT = decimal.Parse(Console.ReadLine());
Console.Write("Entrez le taux de la TVA (en %) : ");
int rate = int.Parse(Console.ReadLine());
decimal tva = prixHT * ((decimal)rate / 100);
Console.WriteLine($"Le montant de la T.V.A est de {tva:0.00} Euros");
Console.WriteLine($"Le prix TTC est de {(prixHT + tva):0.00} Euros");
