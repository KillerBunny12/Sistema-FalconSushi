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
            //Al darle click al boton ingresar
            //El sistema crea un objeto Usuario y se le asignan los datos
            //Se ejecuta el metodo de validarLogin y en caso de ser valido
            //Se guarda al usuario en los objetos globales y se procede a ingresar al menu prinicpal
            //En otro caso, se le informa al usuario
            Logica.Usuario MiUsuario = new Logica.Usuario();
            if (!String.IsNullOrEmpty(TxtUser.Text.Trim()) && !String.IsNullOrEmpty(TxtPass.Text.Trim()))
            {
                string us = TxtUser.Text.Trim();
                string pass = TxtPass.Text.Trim();

                int UserID = MiUsuario.ValidarLogin(us, pass);
                if (UserID > 0)
                {
                    Locale.ObjetosGlobales.MiFormPrincipal = new FrmPrincipal();
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
            //Al darle click al boton salir, se termina la ejecucion del programa
            Application.Exit();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            //Boton de administrador que sirve para ingresar al sistema sin loguearse, este solo es utulizado para depuracion
            //Y no se encuentra disponible en el sistema final.
            Logica.Usuario Dummy = new Logica.Usuario();
            Locale.ObjetosGlobales.MiUsuarioGlobal = Dummy.Consultar(1);
            Locale.ObjetosGlobales.MiFormPrincipal = new FrmPrincipal();
            Locale.ObjetosGlobales.MiFormPrincipal.Show();
            this.Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           /// this.BtnAdmin.Visible = false;
        }
    }
}
