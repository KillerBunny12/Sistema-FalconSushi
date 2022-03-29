using Logica;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmPedidos : Form
    {

        public Pedido MiPedidoLocal { get; set; }
        public PedidoDetalle DetalleLocal { get; set; }
        private bool FlagActivar { get; set; }
        public DataTable ListaPedido { get; set; }
        public DataTable ListaPedidoFiltro { get; set; }
        public DataTable DTListaDetalle { get; set; }
        public FrmPedidos()
        {
            InitializeComponent();
            MiPedidoLocal = new Pedido();
            DetalleLocal = new PedidoDetalle();
            DTListaDetalle = new DataTable();
            LlenarLista(this.CbVerActivos.Checked);

        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            MdiParent = Locale.ObjetosGlobales.MiFormPrincipal;
            DTListaDetalle = MiPedidoLocal.AsignarEsquemaDetalles();
            Limpiar();

        }

        private void Limpiar()
        {

            //Se limpian todos los campos de texto

            //Se aciva el checkbox de visualizar activos

            DgvLista.ClearSelection();
            DgvDetalles.ClearSelection();
            // CbVerActivos.Checked = true;
            DTListaDetalle.Clear();
            DesactivarEliminar();


        }

        private void LlenarLista(bool Activos, string Filtro = "")
        {

            //Se crea un objeto de tipo Usuario y dependiendo si se dio valores para filtrar
            //se muestra la tabla con filtro o sin filtro
            DTListaDetalle.Clear();
            DesactivarEliminar();
            Logica.Pedido MiPedido = new Logica.Pedido();

            if (!String.IsNullOrEmpty(Filtro.Trim()))
            {
                ListaPedidoFiltro = MiPedido.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaPedidoFiltro;
            }
            else
            {
                ListaPedido = MiPedido.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaPedido;
            }
            //Se limpia el DataGrid
            DgvLista.ClearSelection();

        }

        private void ActivarEliminar()
        {
            BtnEliminar.Enabled = true;
        }

        private void DesactivarEliminar()
        {
            BtnEliminar.Enabled = false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvLista.SelectedRows.Count == 1)
            {



                if (MiPedidoLocal.ConsultarPorID())
                {
                    if (FlagActivar)
                    {

                        //Si el usuario esta activando el sushi
                        //Se ejecuta el metodo de activacion
                        if (MiPedidoLocal.Activar())
                        {
                            MessageBox.Show("Pedido activado correctamente", "Exito!", MessageBoxButtons.OK);
                            Limpiar();
                            LlenarLista(CbVerActivos.Checked);



                        }
                        else
                        {
                            MessageBox.Show("Ha sucedido un error al activar el pedido", "Activacion pedido", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {//Si el usuario esta desactivando el sushi
                        //Se ejecuta el metodo de desactivacion
                        if (MiPedidoLocal.Desactivar())
                        {
                            MessageBox.Show("Pedido desactivado correctamente", "Exito!", MessageBoxButtons.OK);
                            Limpiar();
                            LlenarLista(CbVerActivos.Checked);

                        }
                        else
                        {
                            MessageBox.Show("Ha sucedido un error al desactivar el pedido", "Desactivacion pedido", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el pedido", "Error validacion ID de pedido", MessageBoxButtons.OK);
                }
            }
        }

        private void CbVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            LlenarLista(CbVerActivos.Checked);
            Limpiar();
            DgvLista.ClearSelection();
            DgvDetalles.ClearSelection();


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

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 2)
            {
                LlenarLista(CbVerActivos.Checked, TxtBuscar.Text.Trim());

            }
            else
            {
                LlenarLista(CbVerActivos.Checked);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DTListaDetalle.Clear();
            DataGridViewRow MiFila = DgvLista.SelectedRows[0];
            int IDPedido = Convert.ToInt32(MiFila.Cells["GCodigo"].Value);

            Logica.Pedido MiPedido = new Logica.Pedido();
            MiPedidoLocal = MiPedido.Consultar(IDPedido);



            foreach (PedidoDetalle item in MiPedido.ListaDetalles)
            {


                DataRow NuevaFila = DTListaDetalle.NewRow();
                NuevaFila["PedidoDetalleID"] = item.PedidoDetalleID;
                if (item.sushi != null)
                {
                    item.sushi = item.sushi.Consultar(item.sushi.SushiID);
                    NuevaFila["NombreProducto"] = item.sushi.Nombre;

                    NuevaFila["Precio"] = item.sushi.Precio;
                }
                else if (item.promocion != null)
                {
                    item.promocion = item.promocion.Consultar(item.promocion.PromocionID);
                    NuevaFila["NombreProducto"] = item.promocion.Nombre;
                    NuevaFila["Precio"] = item.promocion.Precio;
                }

                NuevaFila["Cantidad"] = item.Cantidad;
                NuevaFila["Subtotal"] = item.Subtotal;

                DTListaDetalle.Rows.Add(NuevaFila);
            }

            DgvDetalles.DataSource = DTListaDetalle;

            ActivarEliminar();
        }
    }
}
