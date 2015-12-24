using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Modulo1;
using templateApp.GUI.Master;
using LogicaNegociosSKD.Modulo1;
using LogicaNegociosSKD.Modulo2;

namespace templateApp.GUI.Modulo1
{
    public partial class Index : System.Web.UI.Page
    {
        public Boolean valueInfo = false;
        public AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[RecursosInterfazMaster.sessionUsuarioID] == null)
            {
                errorLogin.Visible = false;
                warningLog.Visible = false;
                infoLog.Visible = false;
                successLog.Visible = false;
                string sessionRequest;

                

                if ((Request.QueryString[RecursosInterfazModulo1.tipoInfo] != null))
                {
                    sessionRequest =
                   cripto.DesencriptarCadenaDeCaracteres
                   (Request.QueryString[RecursosInterfazModulo1.tipoInfo].ToString(), RecursosLogicaModulo2.claveDES);

                    if (sessionRequest == RecursosInterfazModulo1.parametroURLCorreoEnviado)
                        mensajeLogin(RecursosInterfazModulo1.logInfo, RecursosInterfazModulo1.tipoInfo);

                    else if (sessionRequest == RecursosInterfazModulo1.parametroURLRestablecerCaducado)
                        mensajeLogin(RecursosInterfazModulo1.logErrRestablecer, RecursosInterfazModulo1.tipoWarning);
                    else
                        warningLog.Visible = false;
                }
                if (Request.QueryString[RecursosInterfazModulo1.tipoSucess] != null)
                {
                    sessionRequest = cripto.DesencriptarCadenaDeCaracteres
                     (Request.QueryString[RecursosInterfazModulo1.tipoSucess].ToString(), RecursosLogicaModulo2.claveDES);
                    if (sessionRequest == RecursosInterfazModulo1.parametroURLReestablecerExito)
                        mensajeLogin(RecursosInterfazModulo1.logSuccess, RecursosInterfazModulo1.tipoSucess);
                    else
                        successLog.Visible = false;
                }
                if (Request.QueryString[RecursosInterfazModulo1.tipoErrMalicioso] != null
                    && Request.QueryString[RecursosInterfazModulo1.tipoErrMalicioso].ToString() == "input_malicioso")
                    mensajeLogin(RecursosInterfazModulo1.logCadenaMaliciosa,RecursosInterfazModulo1.tipoErr);
            }
            else
                Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
        }
        /// <summary>
        /// Metodo que envia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EnvioCorreo(object sender, EventArgs e)
        {

            EnviarCorreo();
        }

        /// <summary>
        /// Metodo resultante de accionar el acceder realiza la conexion con LogicaNegocioSKD para validar los input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValidarUsuario(object sender, EventArgs e)
        {
            List<String> campos=new List<String>();
            campos.Add(userIni.Value);
            campos.Add(passwordIni.Value);
            logicaLogin validarLogin = new logicaLogin();
            if (validarLogin.ValidarCamposVacios(campos))
            {
                if (validarLogin.ValidarCaracteres(userIni.Value, true) &&
                   validarLogin.ValidarCaracteres(passwordIni.Value, false))
                    consultarUsuario();
                else
                    mensajeLogin(RecursosInterfazModulo1.logCaracterInvalidos, RecursosInterfazModulo1.tipoErr);
            }
        }
        /// <summary>
        /// Metodo para Establecer un mensaje de alerta en el login
        /// </summary>
        /// <param name="visible">Si queremos que sea visible</param>
        /// <param name="mensaje">Mensaje que aparecerá en la alerta</param>
        /// <param name="tipo">stirng Error;Warning;Info;Sucess</param>
        public void mensajeLogin(string mensaje,string tipo)
        {
            switch (tipo)
            {
                case "Error": mensajeVisible(false, false, false, true,mensaje); break;
                case "Warning": mensajeVisible(false, false, true, false,mensaje); break;
                case "Info": mensajeVisible(false, true, false, false,mensaje); break;
                case "Success": mensajeVisible(true, false, false, false,mensaje); break;
            }
        }

        /// <summary>
        /// Metodo que Vuelve visible y no visible los mensajes en el login
        /// </summary>
        /// <param name="success">mensaje de exito: Verde</param>
        /// <param name="info">mensaje de informacion: Azul</param>
        /// <param name="warning">Mensaje de alerta: amarillo</param>
        /// <param name="error">Mensaje de error: rojo</param>
        /// <param name="mensaje">Mensaje a mostrar por pantalla</param>
        public void mensajeVisible(bool success,bool info,bool warning,bool error,string mensaje)
        {
            successLog.Visible = success;
            warningLog.Visible = warning;
            errorLogin.Visible = error;
            infoLog.Visible = info;

            if (success)
                successLog.InnerText = mensaje;
            else if (info)
                infoLog.InnerText = mensaje;
            else if (warning)
                warningLog.InnerText = mensaje;
            else if (error)
                errorLogin.InnerText = mensaje;

        }


        /// <summary>
        /// Metodo para el envio de correo electrónico 
        /// </summary>
        public void EnviarCorreo()
        {
            String CorreoDestino= RestablecerCorreo.Value;
            try
            {
                new logicaLogin().EnviarCorreo(CorreoDestino);
                string value= cripto.EncriptarCadenaDeCaracteres
                 (RecursosInterfazModulo1.parametroURLCorreoEnviado,RecursosLogicaModulo2.claveDES);

                Response.Redirect(RecursosInterfazModulo1.direccionM1_Index + RecursosInterfazModulo1.signoPregunta
                    + RecursosInterfazModulo1.tipoInfo + RecursosInterfazModulo1.signoIgual +
                    value);
            }
            catch (Exception e)
            {
                mensajeLogin(e.Message,RecursosInterfazModulo1.tipoErr);
            }
            finally
            {
                RestablecerCorreo.Value = "";
            }
                    
           
        }
        /// <summary>
        /// Metodo que valida si la clave y nombre de usuario introducidos son validos y procede a inicias sesión
        /// </summary>
        public void consultarUsuario()
        {
            try
            {
                string correo = userIni.Value;
                string clave = passwordIni.Value;
                string[] Respuesta = new logicaLogin().iniciarSesion(correo, clave);
                if (Respuesta != null)
                {
                    Session[RecursosInterfazMaster.sessionRol] = Respuesta[3];
                    Session[RecursosInterfazMaster.sessionUsuarioNombre] = Respuesta[1];
                    Session[RecursosInterfazMaster.sessionRoles] = Respuesta[2];
                    Session[RecursosInterfazMaster.sessionUsuarioID] = Respuesta[0];
                    Session[RecursosInterfazMaster.sessionImagen] = Respuesta[4];
                    Session[RecursosInterfazMaster.sessionNombreCompleto] = Respuesta[5];
                    Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                    mensajeLogin(RecursosInterfazModulo1.logErr, RecursosInterfazModulo1.tipoErr);
                }
                else
                    mensajeLogin(RecursosInterfazModulo1.logErr, RecursosInterfazModulo1.tipoErr);
            }
            catch (Exception ex)
            {
                mensajeLogin(ex.Message, RecursosInterfazModulo1.tipoErr);
            }
        }
           
    }
}