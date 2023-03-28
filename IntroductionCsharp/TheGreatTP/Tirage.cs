namespace TheGreatTP
{
    internal class Tirage
    {
        private List<string> _listPrenoms;
        private List<string> _listPrenomsTires;
        public Tirage(List<string> listPrenoms)
        {
            _listPrenoms = listPrenoms;
            _listPrenomsTires = new();
        }

        bool CheckListIntegrity()
        {
            if (_listPrenoms.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La liste est vide");
                Console.ResetColor();
                return false;
            }
            return true;
        }

        public bool EffectuerTirage()
        {
            Console.Clear();
            if (!CheckListIntegrity())
            {
                return false;
            }
            Random random = new();
            List<string> prenomsNotTires = _listPrenoms.Where(p => _listPrenomsTires.All(p2 => p2 != p)).ToList();
            int tirage = random.Next(0, prenomsNotTires.Count);
            _listPrenomsTires.Add(prenomsNotTires[tirage]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"L'heureux gagant est {prenomsNotTires[tirage]}");
            if (_listPrenomsTires.Count == _listPrenoms.Count)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"La liste est remise à 0");
                _listPrenomsTires.Clear();
            }
            Console.ResetColor();
            return true;
        }

        public bool AfficherTirees()
        {
            Console.Clear();
            if (!CheckListIntegrity())
            {
                return false;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Liste des personnes déjà tirés");
            Console.ResetColor();
            string tabulation = "";
            for (int i = 0; i < _listPrenomsTires.Count; i++)
            {
                if (_listPrenomsTires[i] != "")
                {
                    Console.WriteLine(tabulation + _listPrenomsTires[i]);
                    tabulation += "  ";
                }
            }
            return true;
        }

        public bool AfficherRestantes()
        {
            Console.Clear();
            if (!CheckListIntegrity())
            {
                return false;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Personnes n'ayant pas encore fait de correction : ");
            Console.ResetColor();
            string tabulation = "";
            List<string> prenomsRestant = _listPrenoms.Except(_listPrenomsTires).ToList();
            for (int i = 0; i < prenomsRestant.Count; i++)
            {
                Console.WriteLine(tabulation + prenomsRestant[i]);
                tabulation += "  ";
            }
            return true;
        }

        public string AskPrenom(string askInput)
        {
            string prenom;
            do
            {
                Console.Write(askInput);
                prenom = Console.ReadLine();
                if (_listPrenoms.Any(item => item == prenom))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ce prénom existe déjà dans la liste");
                    prenom = "";
                }
                else if (prenom.Length < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Un prénom fait au minimum 2 caractères");
                }
                Console.ResetColor();
            } while (prenom.Length < 2);
            return prenom;
        }

        public string AskExistingPrenom(string askInput)
        {
            if (!CheckListIntegrity())
            {
                return "";
            }
            do
            {
                Console.Write(askInput);
                string prenom = Console.ReadLine();
                if (_listPrenoms.Any(item => item == prenom))
                {
                    return prenom;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ce prénom n'existe pas");
                Console.ResetColor();
            } while (true);
        }

        public void AjouterNom()
        {
            string prenom = AskPrenom("Entrez le prénom à ajouter : ");
            _listPrenoms.Add(prenom);
        }

        public bool DeleteNom(string prenomToDelete)
        {
            if (prenomToDelete == "")
            {
                return false;
            }

            _listPrenoms.Remove(_listPrenoms.Single(p => p == prenomToDelete));
            if (_listPrenomsTires.Any(p => p == prenomToDelete))
            {
                _listPrenomsTires.Remove(_listPrenomsTires.Single(p => p == prenomToDelete));
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{prenomToDelete} enlevé de la liste avec succès");
            Console.ResetColor();
            return true;
        }

        public bool UpdateNom(string prenomToModify)
        {
            if (prenomToModify == "")
            {
                return false;
            }
            int index = _listPrenoms.FindIndex(p => p == prenomToModify);
            string prenom = AskPrenom("Entrez le nouveau prenom : ");
            _listPrenoms[index] = prenom;
            index = _listPrenomsTires.FindIndex(p => p == prenomToModify);
            if (index != -1)
            {
                _listPrenomsTires[index] = prenom;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{prenomToModify} modifié en {prenom} dans la liste");
            Console.ResetColor();
            return true;
        }
    }
}
