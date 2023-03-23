using System.Reflection.Metadata;

Console.WriteLine("--- Quel est le montant de mes impôts ? ---");
Console.Write("Entrez le montant net imposable du foyer (en Euros) : ");
int montantNetImposable = Convert.ToInt32(Console.ReadLine());
Console.Write("Entrez le nombre d'adultes au foyer : ");
int nbAdultes = Convert.ToInt32(Console.ReadLine());
Console.Write("Entrez le nombre d'enfants au foyer : ");
int nbEnfants = Convert.ToInt32(Console.ReadLine());

double part = nbEnfants > 2? nbAdultes + nbEnfants : nbAdultes + nbEnfants * 0.5;
double montantRevenus = montantNetImposable / part;

(double montant, int rate)[] impots = new (double, int)[5];
impots[0] = (10777, 0);
impots[1] = (27478, 11);
impots[2] = (78570, 30);
impots[3] = (168994, 41);
impots[4] = (double.MaxValue, 45);

double payer = 0;

for (int i = 1; i < impots.Length; i++)
{
    if (montantRevenus >= impots[i].montant)
    {
        payer += (impots[i].montant - impots[i - 1].montant) * (Convert.ToDouble(impots[i].rate) / 100);
    }
    else
    {
        payer += (montantRevenus - impots[i - 1].montant) * (Convert.ToDouble(impots[i].rate) / 100);
        break;
    }
}

Console.WriteLine("impots à payer : " + Math.Round(payer));
