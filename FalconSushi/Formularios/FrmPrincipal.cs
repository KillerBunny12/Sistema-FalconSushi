using System;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En caso de darle click al boton
            //Se envia a la pantalla de gestion de usuarios
            Locale.ObjetosGlobales.MiFormsGestionUsuario = new FrmGestionUsuario();
            Locale.ObjetosGlobales.MiFormsGestionUsuario.Show();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En caso de darle click al boton
            //Se envia a la pantalla de gestion de ingredientes
            Locale.ObjetosGlobales.MiFormGestionIngredientes = new FrmGestionIngredientes();
            Locale.ObjetosGlobales.MiFormGestionIngredientes.Show();
        }

        private void sushiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En caso de darle click al boton
            //Se envia a la pantalla de gestion de Sushi
            Locale.ObjetosGlobales.MiFormGestionSushi = new FrmGestionSushi();
            Locale.ObjetosGlobales.MiFormGestionSushi.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En caso de darle click al boton
            //Se envia a la pantalla de gestion de clientes
            Locale.ObjetosGlobales.MiFormGestionCliente = new FrmGestionCliente();
            Locale.ObjetosGlobales.MiFormGestionCliente.Show();
        }

        private void promocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En caso de darle click al boton
            //Se envia a la pantalla de gestion de promociones
            Locale.ObjetosGlobales.MiFormGestionPromocion = new FrmGestionPromocion();
            Locale.ObjetosGlobales.MiFormGestionPromocion.Show();
        }

        private void nuevoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En caso de darle click al boton
            //Se envia a la pantalla de gestion de creacion de  pedidos
            Locale.ObjetosGlobales.MiFormGestionPedido = new FrmCrearPedido();
            Locale.ObjetosGlobales.MiFormGestionPedido.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En caso de darle click al boton
            //Se envia a la pantalla de visualizacion de pedidos
            Locale.ObjetosGlobales.MiFormPedidos = new FrmPedidos();
            Locale.ObjetosGlobales.MiFormPedidos.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En caso de darle click al boton
            //Se envia a la pantalla de visualizacion de bitacora
            Locale.ObjetosGlobales.MiFormBitacora = new FrmBitacora();
            Locale.ObjetosGlobales.MiFormBitacora.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En caso de darle click al boton Salir
            //Se le rpeguntaa al usuario si esta seguro
            //En caso de confirmacion, se limpia el usuario global y se redirige a la pantalla de login.
            var ConfirmarSalir = MessageBox.Show("Esta seguro que desea salir de la sesion actual?", "Salir", MessageBoxButtons.YesNo);

            if (ConfirmarSalir == DialogResult.Yes)
            {
                Locale.ObjetosGlobales.MiLogin = new FrmLogin();
                Locale.ObjetosGlobales.MiLogin.Show();
                this.Close();
                Locale.ObjetosGlobales.MiUsuarioGlobal = new Logica.Usuario();
            }
            
           
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
