using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace templateApp.GUI
{

    /// <summary>
    /// Clase encargada de resolver validaciones de expresiones regulares y cualquier
    /// otro tipo de validacion requerida sobre un dato que se ingreso por el usuario
    /// al sistema
    /// </summary>
    public static class Validaciones
    {

        #region Metodos de validaciones

        ///<sumary>
        ///Metodo que valida la expresion regular en una lista de datos
        ///</sumary>
        ///<param name="datos">Lista de String con los datos a validar</param>
        ///<param name="expresionRegular">Regex con la expresion regular a validar</param>
        ///<returns>true, si todo los datos de la lista cumplen con la expresion regular
        ///         false, si al menos un dato no cumple con la expresion regular</returns>
        public static bool ValidarExpresionRegular(List<String> datos, Regex expresionRegular)
        {
            for (int i = 0; i < datos.Count; i++)
            {
                if (!expresionRegular.IsMatch(datos[i]))
                {
                    return false;
                }
            }
            return true;
        }

        ///<sumary>
        ///Metodo que se encarga de validar si los datos de la lista alguno de ellos esta vacio  
        ///</sumary>
        ///<param name="datos">Lista de String con los datos a validar</param>
        ///<returns>true, sin ningun dato en la lista esta vacio
        ///         false, si al menos un dato es igual a vacio</returns>
        public static bool ValidarCamposVacios(List<String> datos)
        {
            String caracterVacio = "";

            for (int i = 0; i < datos.Count; i++)
            {
                if (datos[i].Equals(caracterVacio))
                {
                    return false;
                }
            }
            return true;
        }
#endregion

    }
}