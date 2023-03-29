namespace Demo.Classes
{
    internal class Chaise
    {
        private int _nbPieds;
        private string _color;
        private string _material;
        public Chaise()
        {
            NbPieds = 4;
            Color = "Blanche";
            Material = "Bois";
        }
        public Chaise(int nbPieds, string color, string material)
        {
            NbPieds = nbPieds;
            Color = color;
            Material = material;
        }
        public int NbPieds
        {
            get => _nbPieds;
            set => _nbPieds = value;
        }
        public string Color
        {
            get => _color;
            set => _color = value;
        }
        public string Material
        {
            get => _material;
            set => _material = value;
        }

        public override string ToString()
        {
            return $"Je suis une Chaise, avec {NbPieds} pieds en {Material} et de couleur {Color}";
        }
    }
}
