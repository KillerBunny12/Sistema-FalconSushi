using System;
using System.Security.Cryptography;
using System.Text;


namespace Logica
{
    public class Crypto
    {
        //Llave personalizada para la encriptacion de passwords
        string LlavePersonalizada = "FalconSushi/FX44YSHYcCsCo6x9";

        //Funcion utilizada para la encriptacion de constraseñas de los usuarios utilizando la llave personalizada
        public string EncriptarPassword(string Pass)
        {
            String R = string.Empty;

            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    Byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(LlavePersonalizada));

                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;

                    Byte[] data = Encoding.UTF8.GetBytes(Pass);

                    R = Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));

                }
            }

            return R;

        }



    }
}
