using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vuelo
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JSanchezAeroMexicoEntities context = new DL.JSanchezAeroMexicoEntities())
                {
                    var query = context.VueloGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Vuelo vuelo = new ML.Vuelo();

                            vuelo.IdVuelo = obj.IdVuelo;
                            vuelo.NumeroVuelo = obj.NumeroVuelo;
                            vuelo.Origen = obj.Origen;
                            vuelo.Destino = obj.Destino;
                            vuelo.FechaSalida = obj.FechaSalida.ToString();

                            result.Objects.Add(vuelo);
                        }
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
