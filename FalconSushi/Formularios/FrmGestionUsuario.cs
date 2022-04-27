using FalconSushi.Locale;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmGestionUsuario : Form
    {

        private Logica.Usuario UsuarioLocal { get; set; }
        private bool FlagActivar { get; set; }

        private bool FlagCambioContra { get; set; }
        public DataTable ListaUsuarios { get; set; }
        public DataTable ListaUsuariosFiltro { get; set; }

        public FrmGestionUsuario()
        {
            InitializeComponent();
            UsuarioLocal = new Logica.Usuario();
            LlenarLista(this.CbVerActivos.Checked);
        }

        private void FrmGestionUsuario_Load(object sender, EventArgs e)
        {
            MdiParent = Locale.ObjetosGlobales.MiFormPrincipal;
            Limpiar();
            ActivarAgregar();
        }

        private void Limpiar()
        {

            //Se limpian todos los campos de texto
            //Se aciva el checkbox de visualizar activos
            //Se asigna el flag de cambio de password en false
            TxtBuscar.Clear();
            TxtCodigo.Clear();
            TxtNombre.Clear();
            TxtPass.Clear();
            TxtUser.Clear();


            
            FlagCambioContra = false;



        }



        private void LlenarLista(bool Activos, string Filtro = "")
        {

            //Se crea un objeto de tipo Usuario y dependiendo si se dio valores para filtrar
            //se muestra la tabla con filtro o sin filtro
            Logica.Usuario MiUsuario = new Logica.Usuario();

            if (!String.IsNullOrEmpty(Filtro.Trim()))
            {
                ListaUsuariosFiltro = MiUsuario.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaUsuariosFiltro;
            }
            else
            {
                ListaUsuarios = MiUsuario.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaUsuarios;
            }
            //Se limpia el DataGrid
            DgvLista.ClearSelection();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                //Si los campos son validos se crea un objeto usuario y se le asignan los valores de los campos de texto
                //de otra forma se le informa al usuario
                Logica.Usuario MiUsuario = new Logica.Usuario();

                MiUsuario.Nombre = TxtNombre.Text.Trim();
                MiUsuario.User = TxtUser.Text.Trim();
                MiUsuario.Pass = TxtPass.Text.Trim();


                //se verifica que el password posea 1 mayuscula, 1 minuscula, 1 numero y 1 caracter especial

                bool ValidPass = Herramientas.ValidadPassword(MiUsuario.Pass);




                if (ValidPass)
                {

                    //Si todas las pruebas fueron exitosas se agrega el usuario a la base de datos y se limpia el formulario
                    //De otra forma se presentaran los respectivos mensajes de error al usuario

                    if (MiUsuario.Agregar())
                    {
                        MessageBox.Show("Usuario agregado correctamente", "Exito!", MessageBoxButtons.OK);
                        Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha agregado el usuario de nombre " + MiUsuario.Nombre);

                        if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                        {
                            Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                        }

                        Limpiar();
                        LlenarLista(this.CbVerActivos.Checked);

                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al agregar al usuario", "Error Gestion Usuario", MessageBoxButtons.OK);
                    }




                }
                else
                {
                    MessageBox.Show("El password debe contener 1 Mayuscula, 1 Minuscula, 1 Numero y 1 Caracter Especial(@!#$%)", "Verificacion password", MessageBoxButtons.OK);
                }



            }
            else
            {
                MessageBox.Show("Rellene todos los campos requeridos", "Verificacion datos", MessageBoxButtons.OK);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            DgvLista.ClearSelection();
            ActivarAgregar();

        }

        private void ActivarAgregar()
        {
            //Se activan el boton agregar y el campo de texto cedula
            BtnAgregar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnEliminar.Enabled = false;

        }

        private void ActivarEditarEliminar()
        {

            //Se activan los botones Editar y Eliminar
            BtnAgregar.Enabled = false;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarDatos()
        {
            bool r = false;

            //Se verifica que los campos de texto no se encuentren vacios
            if (!String.IsNullOrEmpty(TxtNombre.Text.Trim())
                && !String.IsNullOrEmpty(TxtUser.Text.Trim())

                )
            {

                if (BtnEditar.Enabled)
                {
                    r = true;
                }
                else
                {
                    if (!String.IsNullOrEmpty(TxtPass.Text.Trim()))
                    {
                        //Si el boton editar no esta activado se verifica que el password no este vacio
                        r = true;
                    }
                }


            }




            return r;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                //Se verifican los datos y se crea un objeto de tipo usuario y se le asigna solamente el ID del usuario seleccionado
                Logica.Usuario MiUsuario = new Logica.Usuario();

                MiUsuario.UsuarioID = Convert.ToInt32(TxtCodigo.Text.Trim());


                if (MiUsuario.ConsultarPorID())
                {
                    if (FlagActivar)
                    {

                        //Si el usuario esta activando al usuario
                        //Se ejecuta el metodo de activacion
                        if (MiUsuario.Activar())
                        {
                            MessageBox.Show("Usuario activado correctamente", "Exito!", MessageBoxButtons.OK);
                            Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha activado el usuario de ID " + MiUsuario.UsuarioID);

                            if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                            {
                                Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                            }

                            Limpiar();
                            LlenarLista(CbVerActivos.Checked);
                            ActivarAgregar();


                        }
                        else
                        {
                            MessageBox.Show("Ha sucedido un error al activar el usuario", "Activacion usuario", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {//Si el usuario esta desactivando al usuario
                        //Se ejecuta el metodo de desactivacion
                        if (MiUsuario.Desactivar())
                        {
                            if (MiUsuario.UsuarioID != Locale.ObjetosGlobales.MiUsuarioGlobal.UsuarioID)
                            {


                                MessageBox.Show("Usuario desactivado correctamente", "Exito!", MessageBoxButtons.OK);
                                Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha desactivado el usuario de ID " + MiUsuario.UsuarioID);

                                if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                                {
                                    Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                                }

                                Limpiar();
                                LlenarLista(CbVerActivos.Checked);
                                ActivarAgregar();

                            }
                            else
                            {
                                MessageBox.Show("No se puede desactivar este usuario debido a que s eencuentra logueado en el sistema", "Desctivacion usuario", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ha sucedido un error al desactivar el usuario", "Desactivacion usuario", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha encontrado al usuario", "Error validacion ID de usuario", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos requeridos", "Validacion de datos", MessageBoxButtons.OK);
            }
        }

        private void CbVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            //AL activar o desactivar el checkbox de ver activos se vuelve a llenar la lista con el respectivo valor
            //para poder ver los usuarios Activos o inactivos
            //Ademas se cambia el nombre del boton eliminar a Activar y desactivar respectivamente
            LlenarLista(CbVerActivos.Checked);
            Limpiar();
            DgvLista.ClearSelection();
            ActivarAgregar();

            if (!CbVerActivos.Checked)
            {
                BtnEliminar.Text = "Activar";
                FlagActivar = true;
            }
            else
            {
                BtnEliminar.Text = "Desactivar";
                FlagActivar = false;
            }
        }

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al seleccionar un item en el DataGrid se obtienen sus valores y se crea un objeto de usuario y se le asignan los valores
            //a los campos de texto y al checkbox de Activo
            //Ademas de que se activa el boton de editar y eliminar
            DataGridViewRow MiFila = DgvLista.SelectedRows[0];
            int IDUsuario = Convert.ToInt32(MiFila.Cells["GCodigo"].Value);
            Logica.Usuario MiUsuario = new Logica.Usuario();
            UsuarioLocal = MiUsuario.Consultar(IDUsuario);

            TxtPass.Text = "";
            TxtCodigo.Text = UsuarioLocal.UsuarioID.ToString();
            TxtNombre.Text = UsuarioLocal.Nombre;
            TxtUser.Text = UsuarioLocal.User;
            

            ActivarEditarEliminar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            bool ValidPass = false;
            if (ValidarDatos())
            {

                //Si la verificacion de datos fue exitosa se crea un objeto de tipo usuario y se le asignan los valores ingresados por el usuario
                Logica.Usuario MiUsuario = new Logica.Usuario();

                MiUsuario.UsuarioID = Convert.ToInt32(TxtCodigo.Text.Trim());
                MiUsuario.Nombre = TxtNombre.Text.Trim();
                MiUsuario.User = TxtUser.Text.Trim();

                MiUsuario.Pass = "";

                if (FlagCambioContra)
                {
                    //Si el usuario va a cambiar el password se valida que sea correcto
                    MiUsuario.Pass = TxtPass.Text;
                    ValidPass = Herramientas.ValidadPassword(MiUsuario.Pass);
                }



                //Se verifica que el usuario exista y que en caso de editar el password, este sea valido
                if (MiUsuario.ConsultarPorID())
                {

                    if (FlagCambioContra && ValidPass == false)
                    {
                        MessageBox.Show("El password debe contener 1 Mayuscula, 1 Minuscula, 1 Numero y 1 Caracter Especial(@!#$%)", "Verificacion password", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (MiUsuario.Editar())
                        {
                            //Si el procedimiento de editar al usuario fue correcto se muestra un mensaje al usuario y se limpian los campos
                            //De otra forma se muestran los respectivos mensajes de error
                            MessageBox.Show("Usuario editado correctamente", "Exito!", MessageBoxButtons.OK);
                            Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha editado el usuario de ID " + MiUsuario.UsuarioID);
                            if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                            {
                                Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                            }

                            Limpiar();
                            LlenarLista(CbVerActivos.Checked);
                            ActivarAgregar();

                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al editar el usuario", "Error editar Usuario", MessageBoxButtons.OK);
                        }
                    }


                }
                else
                {
                    MessageBox.Show("No se ha encontrado el usuario a editar", "Error validacion editar usuario", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos requeridos", "Gestion Usuarios", MessageBoxButtons.OK);
            }
        }

        private void TxtPass_TextChanged(object sender, EventArgs e)
        {
            //Si el usuario escribio en el campo de texto de password y el boton editar esta habilitado, se inicia el Flag de cambio de password
            if (!String.IsNullOrEmpty(TxtPass.Text.Trim()) && BtnEditar.Enabled)
            {
                FlagCambioContra = true;
            }
            else
            {
                FlagCambioContra = false;
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Si se ingresa texto al campo de buscar se vuelve a llenar la lista con los usuarios filtrados
            if (!String.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 2)
            {
                LlenarLista(CbVerActivos.Checked, TxtBuscar.Text.Trim());

            }
            else
            {
                LlenarLista(CbVerActivos.Checked);
            }
        }

        private void CbVerActivos_CheckStateChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("STATUS CAMBIO", "Gestion Usuarios", MessageBoxButtons.OK);
        }
    }
}
