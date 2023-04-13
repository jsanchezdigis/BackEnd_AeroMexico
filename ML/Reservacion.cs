using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Reservacion
    {
        public int IdReservacion { get; set; }
        public Vuelo Vuelo { get; set; }
        public Pasajero Pasajero { get; set; }
        public List<object> Reservaciones { get; set; }
    }
}
