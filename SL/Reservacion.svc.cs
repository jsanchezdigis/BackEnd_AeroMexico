﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Reservacion" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Reservacion.svc or Reservacion.svc.cs at the Solution Explorer and start debugging.
    public class Reservacion : IReservacion
    {
        public ML.Result Add(ML.Reservacion reservacion)
        {
            ML.Result result = BL.Reservacion.Add(reservacion);

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
