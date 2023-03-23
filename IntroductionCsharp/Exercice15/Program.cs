Console.WriteLine("--- Quelle sera le montant du licenciement ? ---");
Console.Write("Merci de saisir le dernier salaire (en Euros) : ");
int salaire = Convert.ToInt32(Console.ReadLine());
Console.Write("Merci de saisir votre âge : ");
int age = Convert.ToInt32(Console.ReadLine());
Console.Write("Merci de saisir le nombre d'années d'anciennetés : ");
int annees = Convert.ToInt32(Console.ReadLine());

int indemnite = 0;
indemnite += annees <= 10 ? annees * salaire / 2 : annees * salaire;
Console.WriteLine(indemnite);
indemnite += age > 45 && age <= 50 ? 2 * salaire : age > 50 ? 5 * salaire : 0;

Console.WriteLine($"Votre indemnité est de : {indemnite}");
