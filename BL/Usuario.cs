using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetByName(string UserName)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JSanchezAeroMexicoEntities context = new DL.JSanchezAeroMexicoEntities())
                {
                    var query = context.UsuarioGetByUserName(UserName).AsEnumerable().FirstOrDefault();

                    if (query != null)
                    {
                        result.Object = new List<object>();
                        var obj = query;
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Password = obj.Password;

                            result.Object = usuario;
                        }
                        result.Correct = true;
                        result.ErrorMessage = "Autorizado";
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No Autorizado";
                    }
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
