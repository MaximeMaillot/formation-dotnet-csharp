using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendus.Classes
{
    internal class Pendu
    {
        public string MotATrouver { get; set; }
        public string Masque { get; set; }
        public int NbEssais { get; set; }

        public Pendu(int nbEssais = 10)
        {
            MotATrouver = Generateur.GenerateMot().ToLower();
            GenererMasque();
            NbEssais = nbEssais;
            Console.WriteLine($"Jeu du pendu généré ! Nombre d'essais : {NbEssais}");
        }
        public bool TestChar(char letter)
        {
            letter = Char.ToLower(letter);
            if (!Masque.Contains(letter) && MotATrouver.Contains(letter))
            {
                for (int i =0; i < Masque.Length; i++)
                {
                    if (MotATrouver[i] == letter)
                    {
                        Masque = Masque.Substring(0, i) + letter + Masque.Substring(i+1);
                    }
                }
                return true;
            }
            NbEssais--;
            return false;
        }

        public bool TestWin()
        {
            if (Masque.Contains('*'))
            {
                return false;
            }
            return true;
        }

        private void GenererMasque()
        {
            for (int i =0; i < MotATrouver.Length; i++)
            {
                Masque += "*";
            };
        }

    }
}
