using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHotel.Models
{
    internal class ReservationChambre
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int ChambreId { get; set; }
        public Chambre Chambre { get; set; }
    }
}
