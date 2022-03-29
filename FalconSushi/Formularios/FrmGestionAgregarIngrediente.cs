using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmGestionAgregarIngrediente : Form
    {

        public DataTable ListaIngredientes { get; set; }
        public DataTable ListaIngredienteFiltro { get; set; }
        public Logica.Ingrediente MiIngrediente { get; set; }
        public FrmGestionAgregarIngrediente()
        {
            InitializeComponent();
            MiIngrediente = new Logica.Ingrediente();
            ListaIngredienteFiltro = new DataTable();
            ListaIngredientes = new DataTable();
        }

        private void FrmGestionAgregarIngrediente_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista(string Filtro = "")
        {

            //Se llena la lista con todos los productos que se encuentren activos y disponibles en el sistema
            //Si se escribio un valor en el cmapo de texto buscar se filtran los resultados
            Logica.Ingrediente MiIngrediente = new Logica.Ingrediente();

            if (!String.IsNullOrEmpty(Filtro.Trim()))
            {
                ListaIngredienteFiltro = MiIngrediente.Listar(true, Filtro);
                DgvLista.DataSource = ListaIngredienteFiltro;
            }
            else
            {
                ListaIngredientes = MiIngrediente.Listar(true, Filtro);
                DgvLista.DataSource = ListaIngredientes;
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
                foreach (DataRow item in Locale.ObjetosGlobales.MiFormGestionSushi.DTListaIngredientes.Rows)
                {
                    if (Convert.ToInt32(item["IngredienteID"]) == Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value))
                    {
                        existe = true;

                    }
                }

                if (!existe)
                {


                    DataRow NuevaFila = Locale.ObjetosGlobales.MiFormGestionSushi.DTListaIngredientes.NewRow();
                    NuevaFila["IngredienteID"] = Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value);
                    NuevaFila["Nombre"] = DgvLista.SelectedRows[0].Cells["GNombre"].Value.ToString();
                    Locale.ObjetosGlobales.MiFormGestionSushi.DTListaIngredientes.Rows.Add(NuevaFila);

                    bool agregando = false;

                    foreach (int item in Locale.ObjetosGlobales.MiFormGestionSushi.DatosAgregar)
                    {
                        if (item == Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value))
                        {
                            agregando = true;
                        }
                    }

                    if (!agregando)
                    {
                        Locale.ObjetosGlobales.MiFormGestionSushi.DatosAgregar.Add(Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value));

                        foreach (int item in Locale.ObjetosGlobales.MiFormGestionSushi.DTListaIngredientesEliminados)
                        {
                            if (item == Convert.ToInt32(DgvLista.SelectedRows[0].Cells["GCodigo"].Value))
                            {
                                Locale.ObjetosGlobales.MiFormGestionSushi.DTListaIngredientesEliminados.Remove(item);
                                break;
                            }
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Este ingrediente ya se encuentra agregado", "Error Validacion", MessageBoxButtons.OK);
                }


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
                MessageBox.Show("Seleccione al menos 1 ingrediente a agregar ", "Error de validacion", MessageBoxButtons.OK);
            }

            return r;
        }
    }
}
