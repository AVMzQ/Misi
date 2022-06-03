using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Encriptar
    {
        string llave = "asdkyknub12321bc";

        public string Encr(string Contra)
        {
            // Encriptar es el valor que se quiere encriptar (dato)
            // llave es la contrasena del usuario administrador
            byte[] KeyArray;
            byte[] Encriptar = Encoding.UTF8.GetBytes(Contra);

            KeyArray = Encoding.UTF8.GetBytes(llave);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = KeyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTrans = tdes.CreateEncryptor();
            byte[] resultado = cTrans.TransformFinalBlock(Encriptar, 0, Encriptar.Length);
            tdes.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length);
        }
        public string Descriptar(string contra)
        {
            byte[] KeyArray;
            byte[] Des = Convert.FromBase64String(contra);

            KeyArray = Encoding.UTF8.GetBytes(llave);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = KeyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] recontra = cTransform.TransformFinalBlock(Des, 0, Des.Length);
            tdes.Clear();
            return Encoding.UTF8.GetString(recontra);
        }


    }
}
