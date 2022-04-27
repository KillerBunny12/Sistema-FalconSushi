using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmGestionCliente : Form
    {
        private Logica.Cliente ClienteLocal { get; set; }
        private bool FlagActivar { get; set; }


        public DataTable ListaClientes { get; set; }
        public DataTable ListaClientesFiltro { get; set; }
        public FrmGestionCliente()
        {
            InitializeComponent();
            ClienteLocal = new Logica.Cliente();
            LlenarLista(this.CbVerActivos.Checked);
        }

        private void FrmGestionCliente_Load(object sender, EventArgs e)
        {
            MdiParent = Locale.ObjetosGlobales.MiFormPrincipal;
            Limpiar();
            ActivarAgregar();
            DgvLista.ClearSelection();
        }


        private void Limpiar()
        {

            //Se limpian todos los campos de texto

            //Se aciva el checkbox de visualizar activos

            TxtBuscar.Clear();
            TxtCodigo.Clear();
            TxtNombre.Clear();
            TxtDireccion.Clear();
            TxtTelefono.Clear();
          

        }

        private void LlenarLista(bool Activos, string Filtro = "")
        {

            //Se crea un objeto de tipo Cliente y dependiendo si se dio valores para filtrar
            //se muestra la tabla con filtro o sin filtro
            Logica.Cliente MiCliente = new Logica.Cliente();

            if (!String.IsNullOrEmpty(Filtro.Trim()))
            {
                ListaClientesFiltro = MiCliente.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaClientesFiltro;
            }
            else
            {
                ListaClientes = MiCliente.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaClientes;
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
            if (!String.IsNullOrEmpty(TxtNombre.Text.Trim())
                && !String.IsNullOrEmpty(TxtDireccion.Text.Trim())
                && !String.IsNullOrEmpty(TxtTelefono.Text.Trim())

                )
            {

                r = true;


            }




            return r;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                //Si los campos son validos se crea un objeto Cliente y se le asignan los valores de los campos de texto
                //de otra forma se le informa al usuario
                Logica.Cliente MiCliente = new Logica.Cliente();

                MiCliente.Nombre = TxtNombre.Text.Trim();
                MiCliente.Direccion = TxtDireccion.Text.Trim();
                MiCliente.Telefono = TxtTelefono.Text.Trim();


                //Si todas las pruebas fueron exitosas se agrega el Cliente a la base de datos y se limpia el formulario
                //De otra forma se presentaran los respectivos mensajes de error al usuario

                if (MiCliente.Agregar())
                {
                    MessageBox.Show("Cliente agregado correctamente", "Exito!", MessageBoxButtons.OK);
                    Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha agregado un cliente con el nombre " + MiCliente.Nombre + " y telefono: " + MiCliente.Telefono);

                    if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                    {
                        Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                    }



                    Limpiar();
                    LlenarLista(this.CbVerActivos.Checked);

                }
                else
                {
                    MessageBox.Show("Hubo un error al agregar el cliente", "Error Gestion clientes", MessageBoxButtons.OK);
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

                //Si la verificacion de datos fue exitosa se crea un objeto de tipo Cliente y se le asignan los valores ingresados por el usuario
                Logica.Cliente MiCliente = new Logica.Cliente();

                MiCliente.ClienteID = Convert.ToInt32(TxtCodigo.Text.Trim());
                MiCliente.Nombre = TxtNombre.Text.Trim();
                MiCliente.Direccion = TxtDireccion.Text.Trim();
                MiCliente.Telefono = TxtTelefono.Text.Trim();




                //Se verifica que el Cliente exista y que en caso de editar el password, este sea valido
                if (MiCliente.ConsultarPorID())
                {


                    if (MiCliente.Editar())
                    {
                        //Si el procedimiento de editar al Cliente fue correcto se muestra un mensaje al usuario y se limpian los campos
                        //De otra forma se muestran los respectivos mensajes de error
                        MessageBox.Show("Cliente editado correctamente", "Exito!", MessageBoxButtons.OK);
                        Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha editado el cliente de ID " + MiCliente.ClienteID);

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
                        MessageBox.Show("Ha ocurrido un error al editar el cliente", "Error editar cliente", MessageBoxButtons.OK);
                    }



                }
                else
                {
                    MessageBox.Show("No se ha encontrado el cliente a editar", "Error validacion editar cliente", MessageBoxButtons.OK);
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

                //Se verifican los datos y se crea un objeto de tipo Cliente y se le asigna solamente el ID del usuario seleccionado
                Logica.Cliente MiCliente = new Logica.Cliente();

                MiCliente.ClienteID = Convert.ToInt32(TxtCodigo.Text.Trim());


                if (MiCliente.ConsultarPorID())
                {
                    if (FlagActivar)
                    {

                        //Si el usuario esta activando al Cliente
                        //Se ejecuta el metodo de activacion
                        if (MiCliente.Activar())
                        {
                            MessageBox.Show("Cliente activado correctamente", "Exito!", MessageBoxButtons.OK);
                            Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha activado el cliente de ID " + MiCliente.ClienteID);

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
                            MessageBox.Show("Ha sucedido un error al activar el cliente", "Activacion cliente", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {//Si el usuario esta desactivando al Cliente
                        //Se ejecuta el metodo de desactivacion
                        if (MiCliente.Desactivar())
                        {
                            MessageBox.Show("Cliente desactivado correctamente", "Exito!", MessageBoxButtons.OK);
                            Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha desactivado el cliente de ID " + MiCliente.ClienteID);

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
                            MessageBox.Show("Ha sucedido un error al desactivar el cliente", "Desactivacion cliente", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el cliente", "Error validacion ID de cliente", MessageBoxButtons.OK);
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

            //En caso de darse click al checkbox
            //Se vuelve a rellenar la lista de clientes
            //Dependiendo de si desea ver activos o inactivos
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
            //Al seleccionar un item en el DataGrid se obtienen sus valores y se crea un objeto de cliente y se le asignan los valores
            //a los campos de texto y al checkbox de Activo
            //Ademas de que se activa el boton de editar y eliminar
            DataGridViewRow MiFila = DgvLista.SelectedRows[0];
            int IDCliente = Convert.ToInt32(MiFila.Cells["GCodigo"].Value);
            Logica.Cliente MiCliente = new Logica.Cliente();
            ClienteLocal = MiCliente.Consultar(IDCliente);


            TxtCodigo.Text = ClienteLocal.ClienteID.ToString();
            TxtNombre.Text = ClienteLocal.Nombre;
            TxtDireccion.Text = ClienteLocal.Direccion;
            TxtTelefono.Text = ClienteLocal.Telefono;

          

            ActivarEditarEliminar();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Si se ingresa texto al campo de buscar se vuelve a llenar la lista con los clientes filtrados
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
