namespace Citerne.Classes
{
    internal class WaterTank
    {
        private int _waterLevel = 0;

        private static int _Id = 1;
        private static int _totalWaterLevel;
        private int _id;
        private int _weight;
        private int _waterCapacity;
        public int Id { get => _id; set
            {
                if (value < 1)
                {
                    throw new Exception();
                }
                _id = value;
            }
        }
        public int Weight { get => _weight; set
            {
                if (value <= 0)
                {
                    throw new Exception();
                }
                _weight = value;
            }
        }
        public int WaterCapacity
        {
            get => _waterCapacity;
            set
            {
                if (value < 0)
                {
                    throw new Exception();
                }
                _waterCapacity = value;
            }
        }
        public int WaterLevel {
            get => _waterLevel; set
            {
                if (value < 0)
                {
                    throw new Exception();
                }
                TotalWaterLevel -= _waterLevel;
                _waterLevel = value;
                TotalWaterLevel += _waterLevel;
            }
        }
        public static int TotalWaterLevel { get => _totalWaterLevel; private set
            {
                if (value < 0)
                {
                    throw new Exception();
                }
                _totalWaterLevel = value;
            }
        }

        public WaterTank(int weight, int waterCapacity, int waterLevel) 
        {
            WaterCapacity = waterCapacity;
            WaterLevel = waterLevel;
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
                waterGet = WaterLevel + quantity - WaterCapacity;
                WaterLevel = WaterCapacity;
            } else
            {
                WaterLevel += quantity;
            }
            return waterGet;
        }

        public int Drain(int quantity)
        {
            int waterGet;
            if (WaterLevel - quantity < 0)
            {
                waterGet = WaterLevel;
                WaterLevel = 0;
            }
            else
            {
                waterGet = quantity;
                WaterLevel -= quantity;
            }
            return waterGet;
        }

        public override string ToString()
        {
            return $"La citerne {Id} à un poids à vide de {Weight}kg et contient {WaterLevel}/{WaterCapacity} litres d'eau";
        }

        public bool IsEmpty()
        {
            return WaterLevel == 0;
        }

        public bool IsFull()
        {
            return WaterLevel == WaterCapacity;
        }
    }
}
