using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmGestionIngredientes : Form
    {

        private Logica.Ingrediente IngredienteLocal { get; set; }
        private bool FlagActivar { get; set; }


        public DataTable ListaIngredientes { get; set; }
        public DataTable ListaIngredientesFiltro { get; set; }
        public FrmGestionIngredientes()
        {
            InitializeComponent();
            IngredienteLocal = new Logica.Ingrediente();
            LlenarLista(this.CbVerActivos.Checked);
        }

        private void FrmGestionIngredientes_Load(object sender, EventArgs e)
        {
            MdiParent = Locale.ObjetosGlobales.MiFormPrincipal;
            Limpiar();
            ActivarAgregar();
        }

        private void Limpiar()
        {

            //Se limpian todos los campos de texto

            //Se aciva el checkbox de visualizar activos

            TxtBuscar.Clear();
            TxtCodigo.Clear();
            TxtNombre.Clear();
            

        }

        private void LlenarLista(bool Activos, string Filtro = "")
        {

            //Se crea un objeto de tipo ingrediente y dependiendo si se dio valores para filtrar
            //se muestra la tabla con filtro o sin filtro
            Logica.Ingrediente MiIngrediente = new Logica.Ingrediente();

            if (!String.IsNullOrEmpty(Filtro.Trim()))
            {
                ListaIngredientesFiltro = MiIngrediente.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaIngredientesFiltro;
            }
            else
            {
                ListaIngredientes = MiIngrediente.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaIngredientes;
            }
            //Se limpia el DataGrid
            DgvLista.ClearSelection();
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


        private bool ValidarDatos()
        {
            bool r = false;

            //Se verifica que los campos de texto no se encuentren vacios
            if (!String.IsNullOrEmpty(TxtNombre.Text.Trim()))
            {

                r = true;


            }




            return r;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                //Si los campos son validos se crea un objeto ingrediente y se le asignan los valores de los campos de texto
                //de otra forma se le informa al usuario
                Logica.Ingrediente MiIngrediente = new Logica.Ingrediente();

                MiIngrediente.Nombre = TxtNombre.Text.Trim();

                //Si todas las pruebas fueron exitosas se agrega el ingrediente a la base de datos y se limpia el formulario
                //De otra forma se presentaran los respectivos mensajes de error al usuario

                if (MiIngrediente.Agregar())
                {
                    MessageBox.Show("Ingrediente agregado correctamente", "Exito!", MessageBoxButtons.OK);
                    Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha agregado el ingrediente de nombre " + MiIngrediente.Nombre);

                    if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                    {
                        Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                    }

                    Limpiar();
                    LlenarLista(this.CbVerActivos.Checked);

                }
                else
                {
                    MessageBox.Show("Hubo un error al agregar el ingrediente", "Error Gestion Ingredientes", MessageBoxButtons.OK);
                }






            }
            else
            {
                MessageBox.Show("Rellene todos los campos requeridos", "Verificacion datos", MessageBoxButtons.OK);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

            if (ValidarDatos())
            {

                //Si la verificacion de datos fue exitosa se crea un objeto de tipo ingrediente y se le asignan los valores ingresados por el usuario
                Logica.Ingrediente MiIngrediente = new Logica.Ingrediente();

                MiIngrediente.IngredienteID = Convert.ToInt32(TxtCodigo.Text.Trim());
                MiIngrediente.Nombre = TxtNombre.Text.Trim();




                //Se verifica que el ingrediente exista y que en caso de editar el password, este sea valido
                if (MiIngrediente.ConsultarPorID())
                {


                    if (MiIngrediente.Editar())
                    {
                        //Si el procedimiento de editar al ingrediente fue correcto se muestra un mensaje al usuario y se limpian los campos
                        //De otra forma se muestran los respectivos mensajes de error
                        MessageBox.Show("Ingrediente editado correctamente", "Exito!", MessageBoxButtons.OK);
                        Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha editado el ingrediente de ID " + MiIngrediente.IngredienteID);

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
                        MessageBox.Show("Ha ocurrido un error al editar el ingrediente", "Error editar Ingrediente", MessageBoxButtons.OK);
                    }



                }
                else
                {
                    MessageBox.Show("No se ha encontrado el ingrediente a editar", "Error validacion editar ingrediente", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos requeridos", "Gestion ingredientes", MessageBoxButtons.OK);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                //Se verifican los datos y se crea un objeto de tipo ingrediente y se le asigna solamente el ID del usuario seleccionado
                Logica.Ingrediente MiIngrediente = new Logica.Ingrediente();

                MiIngrediente.IngredienteID = Convert.ToInt32(TxtCodigo.Text.Trim());


                if (MiIngrediente.ConsultarPorID())
                {
                    if (FlagActivar)
                    {

                        //Si el usuario esta activando al ingrediente
                        //Se ejecuta el metodo de activacion
                        if (MiIngrediente.Activar())
                        {
                            MessageBox.Show("Ingrediente activado correctamente", "Exito!", MessageBoxButtons.OK);
                            Limpiar();

                            if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                            {
                                Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                            }

                            LlenarLista(CbVerActivos.Checked);
                            ActivarAgregar();
                            Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha activado el ingrediente de ID " + MiIngrediente.IngredienteID);


                        }
                        else
                        {
                            MessageBox.Show("Ha sucedido un error al activar el ingrediente", "Activacion ingrediente", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {//Si el usuario esta desactivando al ingrediente
                        //Se ejecuta el metodo de desactivacion
                        if (MiIngrediente.Desactivar())
                        {
                            MessageBox.Show("Ingrediente desactivado correctamente", "Exito!", MessageBoxButtons.OK);
                            Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha desactivado el ingrediente de ID " + MiIngrediente.IngredienteID);

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
                            MessageBox.Show("Ha sucedido un error al desactivar el ingrediente", "Desactivacion ingrediente", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el ingrediente", "Error validacion ID de ingrediente", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos requeridos", "Validacion de datos", MessageBoxButtons.OK);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            DgvLista.ClearSelection();
            ActivarAgregar();
        }

        private void CbVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            //AL activar o desactivar el checkbox de ver activos se vuelve a llenar la lista con el respectivo valor
            //para poder ver los ingrediente Activos o inactivos
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
            //Al seleccionar un item en el DataGrid se obtienen sus valores y se crea un objeto de ingrediente y se le asignan los valores
            //a los campos de texto y al checkbox de Activo
            //Ademas de que se activa el boton de editar y eliminar
            DataGridViewRow MiFila = DgvLista.SelectedRows[0];
            int IDIngrediente = Convert.ToInt32(MiFila.Cells["GCodigo"].Value);
            Logica.Ingrediente MiIngrediente = new Logica.Ingrediente();
            IngredienteLocal = MiIngrediente.Consultar(IDIngrediente);


            TxtCodigo.Text = IngredienteLocal.IngredienteID.ToString();
            TxtNombre.Text = IngredienteLocal.Nombre;

            

            ActivarEditarEliminar();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Si se ingresa texto al campo de buscar se vuelve a llenar la lista con los ingrediente filtrados
            if (!String.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 2)
            {
                LlenarLista(CbVerActivos.Checked, TxtBuscar.Text.Trim());

            }
            else
            {
                LlenarLista(CbVerActivos.Checked);
            }
        }
    }
}
