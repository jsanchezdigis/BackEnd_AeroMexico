using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Pasajero" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Pasajero.svc or Pasajero.svc.cs at the Solution Explorer and start debugging.
    public class Pasajero : IPasajero
    {
        public ML.Result Add(ML.Pasajero pasajero)
        {
            ML.Result result = BL.Pasajero.Add(pasajero);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
