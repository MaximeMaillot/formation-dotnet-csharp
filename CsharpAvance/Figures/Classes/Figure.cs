using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Figures.Interfaces;

namespace Figures.Classes
{
    internal abstract class Figure : IDeplacable
    {
        public Point Origine { get; set; }

        public Figure(Point origine)
        {
            Origine = origine;
        }

        public Figure(double posX, double posY)
        {
            Origine = new Point(posX, posY);
        }

        public virtual void Deplacement(double posX, double posY)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
