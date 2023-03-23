Console.WriteLine("--- Calcul de population ---");
int targetPopulation = 120000;
double rate = 0.89;
double population = 96809;
int year = 2015;

while (population < targetPopulation)
{
    population += population * (rate / 100);
    year++;
}

Console.WriteLine($"Il faudra {year - 2015} ans, nous serons en {year}");
Console.WriteLine($"Il y aura {Math.Floor(population)} habitants en {year}");