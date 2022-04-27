using System.Text.RegularExpressions;

namespace FalconSushi.Locale
{
    public class Herramientas
    {
        //AL menos 1 mayuscula, 1 minuscula, 1 numero y 1 caracter especial
        const string PasswordRegex = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,}$";

        public static bool ValidadPassword(string pass)
            //Funcion que permite validar si la contraseña ingresada por un usuario es valida.
        {//Si el password es valido respecto al Regex se retorna true
            if (pass != null)
            {
                return Regex.IsMatch(pass, PasswordRegex);
            }
            else
            {
                return false;
            }
        }
    }
}
