using FalconSushi.Formularios;
using Logica;


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
    }
}
