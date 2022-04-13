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
            Locale.ObjetosGlobales.MiFormsGestionUsuario = new FrmGestionUsuario();
            Locale.ObjetosGlobales.MiFormsGestionUsuario.Show();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locale.ObjetosGlobales.MiFormGestionIngredientes = new FrmGestionIngredientes();
            Locale.ObjetosGlobales.MiFormGestionIngredientes.Show();
        }

        private void sushiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locale.ObjetosGlobales.MiFormGestionSushi = new FrmGestionSushi();
            Locale.ObjetosGlobales.MiFormGestionSushi.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locale.ObjetosGlobales.MiFormGestionCliente = new FrmGestionCliente();
            Locale.ObjetosGlobales.MiFormGestionCliente.Show();
        }

        private void promocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locale.ObjetosGlobales.MiFormGestionPromocion = new FrmGestionPromocion();
            Locale.ObjetosGlobales.MiFormGestionPromocion.Show();
        }

        private void nuevoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locale.ObjetosGlobales.MiFormGestionPedido = new FrmCrearPedido();
            Locale.ObjetosGlobales.MiFormGestionPedido.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locale.ObjetosGlobales.MiFormPedidos = new FrmPedidos();
            Locale.ObjetosGlobales.MiFormPedidos.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locale.ObjetosGlobales.MiFormBitacora = new FrmBitacora();
            Locale.ObjetosGlobales.MiFormBitacora.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var ConfirmarSalir = MessageBox.Show("Esta seguro que desea salir de la sesion actual?", "Salir", MessageBoxButtons.YesNo);

            if (ConfirmarSalir == DialogResult.Yes)
            {
                Locale.ObjetosGlobales.MiLogin = new FrmLogin();
                Locale.ObjetosGlobales.MiLogin.Show();
                this.Close();
                Locale.ObjetosGlobales.MiUsuarioGlobal = new Logica.Usuario();
            }
            
           
            
        }
    }
}
