using FalconSushi.Formularios;
using Logica;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FalconSushi.Locale
{
    class ObjetosGlobales
    {
        public static Usuario MiUsuarioGlobal = new Usuario();
        public static Formularios.FrmPrincipal MiFormPrincipal = new Formularios.FrmPrincipal();
        public static FrmGestionUsuario MiFormsGestionUsuario;
        public static FrmGestionIngredientes MiFormGestionIngredientes;
        public static FrmGestionSushi MiFormGestionSushi;
        public static FrmLogin MiLogin = new FrmLogin();
        public static FrmGestionCliente MiFormGestionCliente;
        public static FrmGestionPromocion MiFormGestionPromocion;
        public static FrmCrearPedido MiFormGestionPedido;
        public static FrmPedidos MiFormPedidos;
        public static FrmBitacora MiFormBitacora;
        public static FrmGestionPedidoAgregarClientr MiFormPedidAgregarcliente;


        public static bool AgregarBitacora(string Detalles)
        {
            bool r = false;

            try
            {
                //Se crea un objeto de conexion y se le asignan parametros para el procedimiento almacenado y se ejecuta
                Conexion MiCOnexion = new Conexion();

                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Detalles", Detalles));
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Fecha", DateTime.Now));



                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPBitcoraAgregar");


                //Si el insert fue exitoso retorna true, de otra forma retorna false y se le informa al usuario
                if (retorno > 0)
                {
                    r = true;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return r;
        }


        
    }
}
