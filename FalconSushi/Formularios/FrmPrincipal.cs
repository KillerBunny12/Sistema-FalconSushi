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
            Application.Exit();
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
    }
}
