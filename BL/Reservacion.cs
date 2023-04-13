using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Reservacion
    {
        public static ML.Result Add(ML.Reservacion reservacion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JSanchezAeroMexicoEntities context = new DL.JSanchezAeroMexicoEntities())
                {
                    int query = context.ReservacionAdd(
                        reservacion.Vuelo.IdVuelo,
                        reservacion.Pasajero.IdPasajero);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
