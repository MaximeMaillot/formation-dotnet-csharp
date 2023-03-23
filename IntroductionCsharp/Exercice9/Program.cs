/* Hypothénuse */
Console.WriteLine("--- Calcul des intérêts ---");
Console.Write("Entrez le capital de départ (en Euros) : ");
decimal capital = Convert.ToDecimal(Console.ReadLine());
Console.Write("Entrez le taux d'intérêt (en %) : ");
decimal interestRate = Convert.ToDecimal(Console.ReadLine());
Console.Write("Entrez la durée de l'épargne (en années) : ");
int years = Convert.ToInt32(Console.ReadLine());
decimal interest = 0;
// Calcul des intérêts en fonction du nombre d'années
for (int i = 0; i < years; i++)
{
    interest += (capital + interest) * (interestRate / 100);
}
Console.WriteLine($"Le montant des intérêts sera de {interest:0.00} Euros après {years} ans");
Console.WriteLine($"Le capital final sera de {(interest + capital):0.00} Euros");

