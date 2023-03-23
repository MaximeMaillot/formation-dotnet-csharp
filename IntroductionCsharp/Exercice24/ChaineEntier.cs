using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice24
{
    internal class ChaineEntier
    {
        private readonly int nbr;
        private List<string> displays;
        public ChaineEntier(int nbr)
        {
            this.nbr = nbr;
            this.displays = this.GetChaineEntierList();
        }

        public int Nbr { get { return nbr; } }

        public List<string> Displays { get {  return displays; } }

        public List<string> GetChaineEntierList()
        {
            // On commence à diviser par 2 qui est le minimum possible
            double divisor = 2;
            double quotient;

            // On initialise un tableau pour l'affichage (pas obligatoire, mais permet de les afficher dans le bon ordre)
            List<string> displays = new List<string>();

            do
            {
                quotient = this.Nbr / divisor;
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
                            displayString += Math.Floor(quotient) - (divisor / 2 - 1) + i + "+";
                        }
                        // On ajoute notre affichage moins le dernier + à la liste
                        displays.Add(displayString.Remove(displayString.Length - 1, 1));
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
                            displayString += quotient - Math.Floor(divisor / 2) + i + "+";
                        }
                        // On ajoute notre affichage moins le dernier + à la liste

                        displays.Add(displayString.Remove(displayString.Length - 1, 1));
                    }
                }
                // On incrémente notre diviseur
                divisor++;
            } while (quotient > (divisor / 2));

            // On inverse la liste pour l'avoir du plus petit diviseur au plus grand
            displays.Reverse();
            return displays;
        }

        public void DisplayChaineEntierString()
        {
            int divisor = 2;
            double quotient;

            do
            {
                quotient = this.Nbr / divisor;
                if (divisor % 2 == 0)
                {
                    if (quotient % 1 == 0.5)
                    {
                        string displayString = "";
                        for (int i = 0; i < divisor; i++)
                        {
                            displayString += Math.Floor(quotient) - (divisor / 2F - 1) + i + "+";
                        }
                        Console.WriteLine($"--- {this.Nbr} : " + displayString.Remove(displayString.Length - 1, 1));
                    }
                }
                else
                {
                    if (quotient % 1 == 0)
                    {
                        string displayString = "";
                        for (int i = 0; i < divisor; i++)
                        {
                            displayString += quotient - Math.Floor(divisor / 2F) + i + "+";
                        }

                        Console.WriteLine($"--- {this.Nbr} : " + displayString.Remove(displayString.Length - 1, 1));

                    }
                }
                divisor++;
            } while (quotient > (divisor / 2));
        }
    }
}
