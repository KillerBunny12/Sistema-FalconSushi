using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmGestionPedidoAgregarSushi : Form
    {

        public DataTable ListaSushi { get; set; }
        public DataTable ListaSushiFiltro { get; set; }
        public Logica.Sushi MiSushi { get; set; }
        public FrmGestionPedidoAgregarSushi()
        {
            InitializeComponent();
            MiSushi = new Logica.Sushi();
            ListaSushi = new DataTable();
            ListaSushiFiltro = new DataTable();
        }

        private void FrmGestionPedidoAgregarSushi_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista(string Filtro = "")
        {

            //Se llena la lista con todos los productos que se encuentren activos y disponibles en el sistema
            //Si se escribio un valor en el cmapo de texto buscar se filtran los resultados
            Logica.Sushi MiSushi = new Logica.Sushi();

            if (!String.IsNullOrEmpty(Filtro.Trim()))
            {
                ListaSushiFiltro = MiSushi.Listar(true, Filtro);
                DgvLista.DataSource = ListaSushiFiltro;
            }
            else
            {
                ListaSushi = MiSushi.Listar(true, Filtro);
                DgvLista.DataSource = ListaSushi;
            }

            DgvLista.ClearSelection();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            bool existe = false;

            if (ValidarDatos())
            {
                foreach (DataRow item in Locale.ObjetosGlobales.MiFormGestionPedido.DTListaSushi.Rows)
                {
                    if (Convert.ToInt32(item["SushiID"]) == Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value))
                    {
                        existe = true;

                    }
                }

                if (!existe)
                {

                    int codprod = Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value);

                    DataRow NuevaFila = Locale.ObjetosGlobales.MiFormGestionPedido.DTListaSushi.NewRow();
                    NuevaFila["SushiID"] = Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value);
                    NuevaFila["Nombre"] = DgvLista.SelectedRows[0].Cells["GNombre"].Value.ToString();
                    //NuevaFila["Descripcion"] = DgvLista.SelectedRows[0].Cells["GDescripcion"].Value.ToString();
                    NuevaFila["Precio"] = Convert.ToDecimal(DgvLista.SelectedRows[0].Cells["GPrecio"].Value);
                    NuevaFila["Cantidad"] = NudCantidad.Value;
                    Locale.ObjetosGlobales.MiFormGestionPedido.DTListaSushi.Rows.Add(NuevaFila);





                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Este Sushi ya se encuentra agregado", "Error Validacion", MessageBoxButtons.OK);
                }


            }
        }

        private bool ValidarDatos()
        {
            bool r = false;
            //Se verifica que se haya seleccionado 1 producto y que se haya solicitado al menos 1 de estos
            if (DgvLista.SelectedRows.Count == 1 && NudCantidad.Value > 0)
            {
                r = true;
            }
            else
            {
                if (NudCantidad.Value <= 0)
                {
                    MessageBox.Show("La cantidad no puede ser cero o negativo. ", "Error de validacion", MessageBoxButtons.OK);
                }
            }

            return r;
        }
    }
}
