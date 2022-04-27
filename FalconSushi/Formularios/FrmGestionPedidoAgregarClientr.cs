using Logica;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmGestionPedidoAgregarClientr : Form
    {

        public DataTable ListaCliente { get; set; }
        public DataTable ListaClienteFiltro { get; set; }
        public Logica.Cliente MiCliente { get; set; }
        public FrmGestionPedidoAgregarClientr()
        {
            InitializeComponent();
            ListaCliente = new DataTable();
            ListaClienteFiltro = new DataTable();
            MiCliente = new Logica.Cliente();
        }

        private void FrmGestionPedidoAgregarClientr_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        public void LlenarLista(string Filtro = "")
        {

            //Se llena la lista con todos los clientes que se encuentren activos y disponibles en el sistema
            //Si se escribio un valor en el cmapo de texto buscar se filtran los resultados
            Logica.Cliente MiCliente = new Logica.Cliente();

            if (!String.IsNullOrEmpty(Filtro.Trim()))
            {
                ListaClienteFiltro = MiCliente.Listar(true, Filtro);
                DgvLista.DataSource = ListaClienteFiltro;
            }
            else
            {
                ListaCliente = MiCliente.Listar(true, Filtro);
                DgvLista.DataSource = ListaCliente;
            }

            DgvLista.ClearSelection();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            //En caso de escribir en el campo de texto se ejecuta el metodo de llenar lista con los datos ingresados
            if (!String.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 2)
            {
                LlenarLista(TxtBuscar.Text.Trim());

            }
            else
            {
                LlenarLista();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {



                //En caso de validarse los datos
                //Se obtiene el id del cliente y se consulta
                //Se agrega el cliente al pedido actual
                int cod = Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value);

                Cliente Micliente = new Cliente();
                Locale.ObjetosGlobales.MiFormGestionPedido.MiClienteLocal = new Cliente();
                Locale.ObjetosGlobales.MiFormGestionPedido.MiClienteLocal = MiCliente.Consultar(cod);





                this.DialogResult = DialogResult.OK;



            }
            else
            {
                MessageBox.Show("Seleccione al menos 1 cliente", "Verificacion datos", MessageBoxButtons.OK);
            }
        }

        private bool ValidarDatos()
        {

            //Se verifica que se haya seleccionado 1 cliente
            if (DgvLista.SelectedRows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
