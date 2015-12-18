using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Diseño
    {
        #region atributos

        private int id;
        private string contenido;

        #endregion

        #region metodos

        public Diseño()
        {

        }
        public Diseño(int id, string contenido)
        {
            this.id = id;
            this.contenido = contenido;
        }

        public Diseño(string contenido)
        {
            this.contenido = contenido;
        }

        public void Base64Encode()
        {
            byte[] cadenaByte = new byte[this.contenido.Length];
            cadenaByte = System.Text.Encoding.UTF8.GetBytes(this.contenido);
            string encodedCadena = Convert.ToBase64String(cadenaByte);
            this.contenido = encodedCadena;
        }

        public void Base64Decode()
        {
            var encoder = new System.Text.UTF8Encoding();
            var utf8Decode = encoder.GetDecoder();

            byte[] cadenaByte = Convert.FromBase64String(this.contenido);
            int charCount = utf8Decode.GetCharCount(cadenaByte, 0, cadenaByte.Length);
            char[] decodedChar = new char[charCount];
            utf8Decode.GetChars(cadenaByte, 0, cadenaByte.Length, decodedChar, 0);
            string result = new String(decodedChar);
            this.contenido = result;
        }
        #endregion

        #region gets y sets

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
        #endregion
    }
}
