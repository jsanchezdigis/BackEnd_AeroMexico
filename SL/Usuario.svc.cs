using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuario.svc or Usuario.svc.cs at the Solution Explorer and start debugging.
    public class Usuario : IUsuario
    {
        public ML.Result GetByName(string UserName)
        {
            ML.Result result = BL.Usuario.GetByName(UserName);

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
