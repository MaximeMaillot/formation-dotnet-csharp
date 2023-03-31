namespace Citerne.Classes
{
    internal static class Main
    {
        public static void Start()
        {
            List<WaterTank> waterTanks = new List<WaterTank>();
            List<(int num, string msg)> menu = new() {
                (1, "Afficher les citernes"),
                (2, "Créer une citerne"),
                (3, "Ajouter de l'eau à une citerne"),
                (4, "Retirer de l'eau à une citerne"),
                (5, "Afficher le poids total d'une citerne"),
                (6, "Afficher l'eau total dans les citernes"),
                (7, "Cas non implémenté"),
                (999, "Quitter")
            };
            (int num, string msg) exit = menu[menu.Count - 1];
            do
            {
                ShowMenu(menu, "--- Gestion de citernes ---");
                int choice = AskMenuChoice(menu);
                Console.Clear();
                if (!menu.Any((item) => item.num == choice) && choice != exit.num)
                {
                    Console.WriteLine("Sélectionnez un nombre dans le menu.");
                    continue;
                }
                int id, quantity, waterGet;
                WaterTank waterTank;
                if (choice == 1)
                {
                    if (IsWaterTanksEmpty(waterTanks))
                    {
                        continue;
                    }
                    Console.WriteLine("La liste des citernes :");
                    foreach (var item in waterTanks)
                    {
                        Console.WriteLine("\t" + item.ToString());
                    }
                }
                else if (choice == 2)
                {
                    waterTanks.Add(AskUserWaterTank());
                }
                else if (choice == 3)
                {
                    if (IsWaterTanksEmpty(waterTanks))
                    {
                        continue;
                    }
                    id = AskUserWaterTankId(waterTanks);
                    quantity = AskUserWaterQuantity("Quel quantité d'eau voulez-vous ajouter ? ");
                    waterTank = GetWaterTankById(waterTanks, id);
                    waterGet = waterTank.Fill(quantity);
                    if (waterTank.IsFull())
                    {
                        Console.WriteLine($"La citerne {waterTank.Id} est déjà pleine : {waterTank.WaterLevel}/{waterTank.WaterCapacity}");
                        Console.WriteLine($"Excès d'eau récupéré : {quantity}");
                    }
                    else
                    {
                        if (waterGet > 0)
                        {
                            Console.WriteLine($"Excès d'eau récupéré : {waterGet}");
                        }
                        Console.WriteLine($"Quantité d'eau dans la citerne {waterTank.Id} après ajout de {quantity} litres: {waterTank.WaterLevel}/{waterTank.WaterCapacity}");
                    }
                }
                else if (choice == 4)
                {
                    if (IsWaterTanksEmpty(waterTanks))
                    {
                        continue;
                    }
                    id = AskUserWaterTankId(waterTanks);
                    quantity = AskUserWaterQuantity("Quel quantité d'eau voulez-vous retirer ? ");
                    waterTank = GetWaterTankById(waterTanks, id);
                    waterGet = waterTank.Drain(quantity);
                    if (waterTank.IsEmpty())
                    {
                        Console.WriteLine($"La citerne {waterTank.Id} est déjà vide : {waterTank.WaterLevel}/{waterTank.WaterCapacity}");
                        Console.WriteLine($"Quantité d'eau récupéré : {quantity}");
                    }
                    else
                    {
                        if (waterGet == quantity)
                        {
                            Console.WriteLine($"Quantité d'eau dans la citerne {waterTank.Id} après retrait de {quantity} litres: {waterTank.WaterLevel}/{waterTank.WaterCapacity}");
                            Console.WriteLine($"Quantité d'eau récupéré : {waterGet}");
                        }
                        else
                        {
                            Console.WriteLine($"Quantité d'eau dans la citerne {waterTank.Id} après tentative de retrait de {quantity} litres: {waterTank.WaterLevel}/{waterTank.WaterCapacity}");
                            Console.WriteLine($"Quantité d'eau récupéré : {waterGet}");
                        }
                    }
                }
                else if (choice == 5)
                {
                    if (IsWaterTanksEmpty(waterTanks))
                    {
                        continue;
                    }
                    id = AskUserWaterTankId(waterTanks);
                    waterTank = GetWaterTankById(waterTanks, id);
                    Console.WriteLine($"Le poids total de cette citerne est de {waterTank.GetTotalWeight()}kg");
                }
                else if (choice == 6)
                {
                    if (IsWaterTanksEmpty(waterTanks))
                    {
                        continue;
                    }
                    Console.WriteLine($"Niveau total d'eau des citernes : {WaterTank.TotalWaterLevel}");
                }
                else if (choice == exit.num)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Cas du menu non géré");
                }
            } while (true);
        }

        private static void ShowMenu(List<(int num, string msg)> menu, string menuTitle = "--- Menu ---")
        {
            Console.WriteLine(menuTitle);
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.num}. {item.msg}");
            }
        }
        private static int AskMenuChoice(List<(int num, string msg)> menu)
        {
            int choice;
            bool isCorrect;
            do
            {
                Console.Write("Votre choix : ");
                isCorrect = int.TryParse(Console.ReadLine(), out choice);
                if (!isCorrect)
                {
                    Console.WriteLine("Rentrez une valeur numérique");
                }
                if (!menu.Any(item => item.num == choice) && choice != 0)
                {
                    Console.WriteLine("Rentrez une valeur présent dans le menu");
                }
            } while (!isCorrect);
            return choice;
        }

        private static WaterTank AskUserWaterTank()
        {
            bool isCorrect;
            int weight, waterCapacity, waterLevel;
            do
            {
                Console.Write("Donnez le poids de votre citerne : ");
                isCorrect = int.TryParse(Console.ReadLine(), out weight);
                if (isCorrect && weight <= 0)
                {
                    isCorrect = false;
                    Console.WriteLine("Une citerne ne peut pas avoir un poids nul ou négatif");
                }
            } while (!isCorrect);
            do
            {
                Console.Write("Donnez la capacité maximale de votre citerne : ");
                isCorrect = int.TryParse(Console.ReadLine(), out waterCapacity);
                if (isCorrect && waterCapacity <= 0)
                {
                    isCorrect = false;
                    Console.WriteLine("Une citerne ne peut pas avoir une capacité nulle ou négative");
                }
            } while (!isCorrect);
            do
            {
                Console.Write("Donnez le remplissage initial de votre citerne : ");
                isCorrect = int.TryParse(Console.ReadLine(), out waterLevel);
                if (isCorrect && waterLevel <= 0)
                {
                    isCorrect = false;
                    Console.WriteLine("Une citerne ne peut pas avoir un remplissage initiale négatif");
                }
                else if (waterLevel > waterCapacity)
                {
                    isCorrect = false;
                    Console.WriteLine("Une citerne ne peut pas avoir un remplissage initial supérieur à sa capacité maximale");
                }
            } while (!isCorrect);
            return new WaterTank(weight, waterCapacity, waterLevel);
        }

        private static int AskUserWaterTankId(List<WaterTank> waterTanks)
        {
            bool isCorrect;
            int id;
            do
            {
                Console.Write("Donnez l'id de votre citerne : ");
                isCorrect = int.TryParse(Console.ReadLine(), out id);
                if (isCorrect && id < 1)
                {
                    isCorrect = false;
                    Console.WriteLine("Une citerne a un id entier supérieur à 0");
                }
                else if (!waterTanks.Any(waterTank => waterTank.Id == id))
                {
                    isCorrect = false;
                    Console.WriteLine("Cette citerne n'existe pas");
                }
            } while (!isCorrect);
            return id;
        }

        private static WaterTank GetWaterTankById(List<WaterTank> waterTanks, int id)
        {
            return waterTanks.Find(waterTank => waterTank.Id == id);
        }

        private static int AskUserWaterQuantity(string msg)
        {
            bool isCorrect;
            int quantity;
            do
            {
                Console.Write(msg);
                isCorrect = int.TryParse(Console.ReadLine(), out quantity);
                if (isCorrect && quantity <= 0)
                {
                    isCorrect = false;
                    Console.WriteLine("La quantité d'eau doit être un entier positif");
                }
            } while (!isCorrect);
            return quantity;
        }

        private static bool IsWaterTanksEmpty(List<WaterTank> waterTanks)
        {
            if (waterTanks.Count == 0)
            {
                Console.WriteLine("Pas de citernes");
                return true;
            }
            return false;
        }
    }
}
