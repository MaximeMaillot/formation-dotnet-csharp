using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citerne.Classes
{
    internal class Watertank
    {
        private static int _Id = 1;
        public int Id { get; set; }
        public int Weight { get; set; }
        public int WaterCapacity { get; set; }
        public int WaterLevel { get; set; } = 0;
        public static int TotalWaterLevel { get; set; }

        public Watertank(int weight, int waterCapacity, int waterLevel) 
        {
            WaterCapacity = waterCapacity;
            WaterLevel = waterLevel;
            TotalWaterLevel += waterLevel;
            Weight = weight;
            Id = _Id++;
        }

        public int GetTotalWeight()
        {
            return Weight + WaterLevel;
        }

        public int Fill(int quantity)
        {
            int waterGet = 0;
            if (WaterLevel + quantity > WaterCapacity)
            {
                TotalWaterLevel += WaterCapacity - WaterLevel;
                WaterLevel = WaterCapacity;
                waterGet = WaterLevel + quantity - WaterCapacity;
                Console.WriteLine($"Excès d'eau récupéré : {waterGet}");
            } else
            {
                TotalWaterLevel += WaterLevel;
                WaterLevel += quantity;
            }
            Console.WriteLine($"Quantité d'eau dans la citerne {Id} après ajout de {quantity} litres: {WaterLevel}/{WaterCapacity}");
            return waterGet;
        }

        public int Drain(int quantity)
        {
            int waterGet;
            if (WaterLevel - quantity < 0)
            {
                TotalWaterLevel -= WaterLevel;
                waterGet = WaterLevel;
                Console.WriteLine($"Quantité d'eau récupéré : {WaterLevel}");
                WaterLevel = 0;
            }
            else
            {
                Console.WriteLine($"Quantité d'eau récupéré : {quantity}");
                TotalWaterLevel -= quantity;
                WaterLevel -= quantity;
                waterGet = quantity;
            }
            Console.WriteLine($"Quantité d'eau dans la citerne {Id} après tentative de retrait de {quantity} litres: {WaterLevel}/{WaterCapacity}");
            return waterGet;
        }

        public void ShowWaterLevel()
        {
            Console.WriteLine($"Quantité d'eau dans la citerne {Id} : {WaterLevel}");
        }

        public void ShowWeight()
        {
            Console.WriteLine($"Poids total de la citerne {Id} : {GetTotalWeight()}");
        }

        public static void ShowTotalWaterLevel()
        {
            Console.WriteLine($"Quantité d'eau dans toutes les citernes : {TotalWaterLevel}");
        }
    }
}
