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

            //Se llena la lista con todos los sushi que se encuentren activos y disponibles en el sistema
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
                //En casod e validar los datos
                //Se verifica que no se haya agregado el sushi a la promocion
                foreach (DataRow item in Locale.ObjetosGlobales.MiFormGestionPromocion.DTListaSushi.Rows)
                {
                    if (Convert.ToInt32(item["SushiID"]) == Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value))
                    {
                        existe = true;

                    }
                }

                if (!existe)
                {

                    //En caso de que no se haya agregado aun
                    //Se obtiene los datos del sushi seleccionado y se agrega al datatable
                    DataRow NuevaFila = Locale.ObjetosGlobales.MiFormGestionPromocion.DTListaSushi.NewRow();
                    NuevaFila["SushiID"] = Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value);
                    NuevaFila["Nombre"] = DgvLista.SelectedRows[0].Cells["GNombre"].Value.ToString();
                    //NuevaFila["Descripcion"] = DgvLista.SelectedRows[0].Cells["GDescripcion"].Value.ToString();
                    NuevaFila["Precio"] = Convert.ToDecimal(DgvLista.SelectedRows[0].Cells["GPrecio"].Value);
                    Locale.ObjetosGlobales.MiFormGestionPromocion.DTListaSushi.Rows.Add(NuevaFila);

                    bool agregando = false;

                    //Se recorre la lista de cola a agregar de la promocion
                    //Se verifica si el sushi seleccionado ya se encuentra en la lista
                    foreach (int item in Locale.ObjetosGlobales.MiFormGestionPromocion.DatosAgregar)
                    {
                        if (item == Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value))
                        {
                            agregando = true;
                        }
                    }

                    if (!agregando)
                    {
                        //En caso de que el item no se encuentre en la lista
                        //Se agrega con el codigo
                        Locale.ObjetosGlobales.MiFormGestionPromocion.DatosAgregar.Add(Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value));

                        foreach (int item in Locale.ObjetosGlobales.MiFormGestionPromocion.DTListaSushiEliminados)
                        {
                            //Se recorre la lista de cola a aliminar
                            //En caso de que e sushi seleccionado se encuentre ahi
                            //Se elimina de la lista
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
