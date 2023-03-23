Console.WriteLine("--- Chaines Entier ---");
int userNbr;
bool isCorrect;

// Demande à l'utilisateur de rentrer un nombre jusqu'à ce qu'il rentre un nombre >= 3 
do
{
    Console.Write("Entrez un nombre supérieur ou égal à 3 : ");
    isCorrect = int.TryParse(Console.ReadLine(), out userNbr);
    if (userNbr < 3)
    {
        isCorrect = false;
    }
} while (!isCorrect);

// On commence à diviser par 2 qui est le minimum possible
int divisor = 2;
float quotient;

do
{
    quotient = userNbr / divisor;
    // Si notre diviseur est pair
    if (divisor % 2 == 0)
    {
        // On vérifie si le chiffre après la virgule est égale à .5
        if (quotient % 1 == 0.5)
        {
            string displayString = "";
            // On sait que notre quotient est le chiffre au milieu de la chaîne d'entier
            // On sait qu'on a divisible nombre d'entier dans la chaîne
            // On fait en sorte de commencer au 1er chiffre, donc on commence au milieu - la moitié du divisible - 1 (car pair)
            for (int i = 0; i < divisor; i++)
            {
                displayString += Math.Floor(quotient) - (divisor / 2F - 1) + i + "+";
            }
            // On ajoute notre affichage moins le dernier + à la liste
            Console.WriteLine($"--- {userNbr} : " + displayString.Remove(displayString.Length - 1, 1));
        }
    }
    //Si notre diviseur est impair
    else
    {
        // Si le resultat de notre division est un entier
        if (quotient % 1 == 0)
        {
            string displayString = "";
            // On sait que notre quotient est le chiffre au milieu de la chaîne d'entier et que notre nombre d'entier dans la chaîne est impair
            // On fait en sorte de commencer au 1er chiffre, donc on commence au milieu - la moitié du divisible
            for (int i = 0; i < divisor; i++)
            {
                displayString += quotient - Math.Floor(divisor / 2F) + i + "+";
            }
            // On ajoute notre affichage moins le dernier + à la liste
            Console.WriteLine($"--- {userNbr} : " + displayString.Remove(displayString.Length - 1, 1));
        }
    }
    // On incrémente notre diviseur
    divisor++;
} while (quotient > (divisor / 2));