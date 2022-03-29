using System;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            Logica.Usuario MiUsuario = new Logica.Usuario();
            if (!String.IsNullOrEmpty(TxtUser.Text.Trim()) && !String.IsNullOrEmpty(TxtPass.Text.Trim()))
            {
                string us = TxtUser.Text.Trim();
                string pass = TxtPass.Text.Trim();

                int UserID = MiUsuario.ValidarLogin(us, pass);
                if (UserID > 0)
                {

                    Locale.ObjetosGlobales.MiUsuarioGlobal = MiUsuario.Consultar(UserID);
                    Locale.ObjetosGlobales.MiFormPrincipal.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("El usuario o contraseña ingresados son incorrectos, intente de nuevo.", "Error de validacion", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos requeridos.", "Error de validacion", MessageBoxButtons.OK);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            Logica.Usuario Dummy = new Logica.Usuario();
            Locale.ObjetosGlobales.MiUsuarioGlobal = Dummy.Consultar(1);
            Locale.ObjetosGlobales.MiFormPrincipal.Show();
            this.Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
