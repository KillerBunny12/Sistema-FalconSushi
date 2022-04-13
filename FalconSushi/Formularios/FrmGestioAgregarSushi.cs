using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmGestioAgregarSushi : Form
    {

        public DataTable ListaSushi { get; set; }
        public DataTable ListaSushiFiltro { get; set; }
        public Logica.Sushi MiSushi { get; set; }
        public FrmGestioAgregarSushi()
        {
            InitializeComponent();
            MiSushi = new Logica.Sushi();
            ListaSushi = new DataTable();
            ListaSushiFiltro = new DataTable();

        }

        private void FrmGestioAgregarSushi_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        public void LlenarLista(string Filtro = "")
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
                foreach (DataRow item in Locale.ObjetosGlobales.MiFormGestionPromocion.DTListaSushi.Rows)
                {
                    if (Convert.ToInt32(item["SushiID"]) == Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value))
                    {
                        existe = true;

                    }
                }

                if (!existe)
                {


                    DataRow NuevaFila = Locale.ObjetosGlobales.MiFormGestionPromocion.DTListaSushi.NewRow();
                    NuevaFila["SushiID"] = Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value);
                    NuevaFila["Nombre"] = DgvLista.SelectedRows[0].Cells["GNombre"].Value.ToString();
                    //NuevaFila["Descripcion"] = DgvLista.SelectedRows[0].Cells["GDescripcion"].Value.ToString();
                    NuevaFila["Precio"] = Convert.ToDecimal(DgvLista.SelectedRows[0].Cells["GPrecio"].Value);
                    Locale.ObjetosGlobales.MiFormGestionPromocion.DTListaSushi.Rows.Add(NuevaFila);

                    bool agregando = false;

                    foreach (int item in Locale.ObjetosGlobales.MiFormGestionPromocion.DatosAgregar)
                    {
                        if (item == Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value))
                        {
                            agregando = true;
                        }
                    }

                    if (!agregando)
                    {
                        Locale.ObjetosGlobales.MiFormGestionPromocion.DatosAgregar.Add(Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value));

                        foreach (int item in Locale.ObjetosGlobales.MiFormGestionPromocion.DTListaSushiEliminados)
                        {
                            if (item == Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value))
                            {
                                Locale.ObjetosGlobales.MiFormGestionPromocion.DTListaSushiEliminados.Remove(item);
                                break;
                            }
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Este Sushi ya se encuentra agregado", "Error Validacion", MessageBoxButtons.OK);
                }


            }
            else
            {
                MessageBox.Show("Seleccione al menos 1 sushi", "Verificacion datos", MessageBoxButtons.OK);
            }
        }

        private bool ValidarDatos()
        {
            bool r = false;
            //Se verifica que se haya seleccionado 1 ingrediente
            if (DgvLista.SelectedRows.Count == 1)
            {
                r = true;
            }
            else
            {
                MessageBox.Show("Seleccione al menos 1 sushi a agregar ", "Error de validacion", MessageBoxButtons.OK);
            }

            return r;
        }
    }
}
