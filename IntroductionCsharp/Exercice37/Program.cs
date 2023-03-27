string[] mois = { "janvier", "février", "mars", "avril", "mai", "juin", "juillet", "aout", "septembre", "octobre", "novembre", "décembre" };

string tabulation = "";
for (int i =0; i < mois.Length; i++)
{
    Console.WriteLine(tabulation + mois[i]);
    tabulation += "\t";
}