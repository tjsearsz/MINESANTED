using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using ExcepcionesSKD;

namespace DominioSKD
{

    /// <summary>
    /// Clase que representa un correo electrónico
    /// </summary>
    public class Correo : InformacionPersonal
    {

        /// <summary>
        /// Correo electrónico
        /// </summary>
        private MailAddress _email;
        public bool Primario = false;

        #region Constructores
        public Correo(int id, String mail)
            : base(id)
        {
            this._email = new MailAddress(mail);
        }
        public Correo(String mail)
            : base(-1)
        {
            this._email = new MailAddress(mail);
        }
        #endregion

        /// <summary>
        /// Implementación del método ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this._email.Address;
        }
    }
}
