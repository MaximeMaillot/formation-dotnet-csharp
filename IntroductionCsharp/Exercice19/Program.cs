Console.WriteLine("--- Quel est le montant de mes impôts ? ---");
Console.Write("Entrez le montant net imposable du foyer (en Euros) : ");
int montantNetImposable = Convert.ToInt32(Console.ReadLine());
Console.Write("Entrez le nombre d'adultes au foyer : ");
int nbAdultes = Convert.ToInt32(Console.ReadLine());
Console.Write("Entrez le nombre d'enfants au foyer : ");
int nbEnfants = Convert.ToInt32(Console.ReadLine());

double part = nbEnfants > 2 ? nbAdultes + nbEnfants : nbAdultes + nbEnfants * 0.5;
double montantRevenus = montantNetImposable / part;
Console.WriteLine(montantRevenus);

double payer = 0;

switch (montantRevenus)
{
    case < 10777:
        break;
    case <= 27478:
        payer = (montantRevenus - 10777) * 0.11;
        break;
    case <= 78570:
        payer = (27478 - 10777) * 0.11;
        payer += (montantRevenus - 27478) * 0.3;
        break;
    case <= 168994:
        payer = (27478 - 10777) * 0.11;
        payer += (78570 - 27478 - 10777) * 0.3;
        payer += (montantRevenus - 78570) * 0.41;
        break;
    case > 168994:
        payer = (27478 - 10777) * 0.11;
        payer += (78570 - 27478 - 10777) * 0.3;
        payer += (168994 - 78570 - 27478 - 10777) * 0.41;
        payer += (montantRevenus - 168994) * 0.45;
        break;
}

Console.WriteLine("impots à payer : " + Math.Round(payer));
