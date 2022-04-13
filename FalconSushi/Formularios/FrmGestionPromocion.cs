using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmGestionPromocion : Form
    {
        private Logica.Promocion PromocionLocal { get; set; }
        private bool FlagActivar { get; set; }

        public List<int> DatosAgregar;

        public DataTable DTListaSushi { get; set; }
        public List<int> DTListaSushiEliminados { get; set; }


        public DataTable ListaPromocion { get; set; }
        public DataTable ListaPromocionFiltro { get; set; }
        public FrmGestionPromocion()
        {
            InitializeComponent();
            PromocionLocal = new Logica.Promocion();
            LlenarLista(this.CbVerActivos.Checked);
            DTListaSushi = new DataTable();
            DTListaSushiEliminados = new List<int>();
            DatosAgregar = new List<int>();
        }

        private void FrmGestionPromocion_Load(object sender, EventArgs e)
        {
            MdiParent = Locale.ObjetosGlobales.MiFormPrincipal;
            Limpiar();
            ActivarAgregar();
            DTListaSushi = PromocionLocal.AsignarEsquemaDetalle();
        }

        private void Limpiar()
        {

            //Se limpian todos los campos de texto

            //Se aciva el checkbox de visualizar activos

            TxtBuscar.Clear();
            TxtCodigo.Clear();
            TxtNombre.Clear();
            TxtPrecio.Clear();
            TxtDescripcion.Clear();
            TxtComentarios.Clear();
            
            DTListaSushi.Clear();
            DgvLista.ClearSelection();
            DatosAgregar.Clear();


        }

        private void LlenarLista(bool Activos, string Filtro = "")
        {

            //Se crea un objeto de tipo Usuario y dependiendo si se dio valores para filtrar
            //se muestra la tabla con filtro o sin filtro
            Logica.Promocion MiPropmocion = new Logica.Promocion();

            if (!String.IsNullOrEmpty(Filtro.Trim()))
            {
                ListaPromocionFiltro = MiPropmocion.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaPromocionFiltro;
            }
            else
            {
                ListaPromocion = MiPropmocion.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaPromocion;
            }
            //Se limpia el DataGrid
            DgvLista.ClearSelection();

        }

        private void ActivarAgregar()
        {
            //Se activan el boton agregar y el campo de texto cedula
            BtnAgregar.Enabled = true;
            BtnAddSushi.Enabled = true;
            BtnEliminarSushi.Enabled = true;
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
                && !String.IsNullOrEmpty(TxtPrecio.Text.Trim())
                && !String.IsNullOrEmpty(TxtDescripcion.Text.Trim())


                )
            {

                if (DgvSushi.Rows.Count == 0)
                {
                    MessageBox.Show("No se han escogido Sushi para la promocion", "Error de validacion", MessageBoxButtons.OK);
                    return false;
                }

                r = true;


            }




            return r;
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // permite decimales
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                //Se verifican los campos y se asignan a la variable de compra local
                PromocionLocal = new Logica.Promocion();
                PromocionLocal.Nombre = TxtNombre.Text.Trim();

                PromocionLocal.Precio = Convert.ToDecimal(TxtPrecio.Text.Trim());

                PromocionLocal.Comentarios = TxtComentarios.Text.Trim();
                PromocionLocal.Descripcion = TxtDescripcion.Text.Trim();

                LlenarDetalles();
                if (PromocionLocal.Aregar())
                {
                    //Si la compra fue exitosa se muestra un mensaje de exito y se procede a la creacion del reporte
                    //Se crea un documento de reporte y se imprime con todos los valores registrados
                    MessageBox.Show("Promocion agregada correctamente", "Exito!", MessageBoxButtons.OK);
                    Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha agregado la promocion de nombre: " + PromocionLocal.Nombre + " y precio: " + PromocionLocal.Precio);

                    if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                    {
                        Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                    }

                    Limpiar();
                    LlenarLista(this.CbVerActivos.Checked);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al intentar crear la promocion", "Error gestion promocion", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene todos los campos requeridos", "Verificacion datos", MessageBoxButtons.OK);
            }
        }

        private void LlenarDetalles()
        {
            //SushiLocal.ListaIngredientes.Clear();
            foreach (DataRow fila in DTListaSushi.Rows)
            {
                //Por cada producto en la compra
                //
                //Se crea un nuevo objeto de linea de deallte y se le asignan los valores calculados y se agregan a la compra
                Logica.Sushi MiSushi = new Logica.Sushi();


                MiSushi.SushiID = Convert.ToInt32(fila["SushiID"]);

                PromocionLocal.ListaSushi.Add(MiSushi);
            }
        }

        private void BtnAddIngrediente_Click(object sender, EventArgs e)
        {
            try
            {
                //Se abre el form de Compra detalle gestion para poder seleccionar y producto a agregar
                Form FormBuscarSushi = new Formularios.FrmGestioAgregarSushi();

                DialogResult Resp = FormBuscarSushi.ShowDialog();

                //Si la respuesta fue exitosa y se selecciono producto
                //Se vuelve a cargar el datatable con los productos seleccionados y se calcula el precio de venta
                if (Resp == DialogResult.OK)
                {
                    DgvSushi.DataSource = DTListaSushi;

                    DgvLista.ClearSelection();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnEliminarSushi_Click(object sender, EventArgs e)
        {
            if (DgvSushi.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvSushi.SelectedRows[0];

                //Si se elimina un producto de la compra se obtiene el producto y se elimina del datatable, ademas de aumentar el stock del producto

                DataRow toDelete = DTListaSushi.Select("SushiID = " + "'" + MiFila.Cells["GCodigoS"].Value.ToString() + "'" + " AND Nombre = " + "'" + MiFila.Cells["GNombreS"].Value.ToString() + "'")[0];

                int SushiRemover = Convert.ToInt32(DgvSushi.SelectedRows[0].Cells["GCodigoS"].Value.ToString());
                DTListaSushiEliminados.Add(Convert.ToInt32(DgvSushi.SelectedRows[0].Cells["GCodigoS"].Value.ToString()));
                DTListaSushi.Rows.Remove(toDelete);

                foreach (int item in DatosAgregar)
                {
                    if (item == SushiRemover)
                    {
                        DatosAgregar.Remove(item);
                        break;
                    }
                }



                //DTListaIngredientesEliminados.Rows.Add(toDelete);


                //  DTListaIngredientesEliminados.Rows.Add(toDelete);


                DgvSushi.DataSource = DTListaSushi;


            }
        }

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DatosAgregar.Clear();
            //Al seleccionar un item en el DataGrid se obtienen sus valores y se crea un objeto de usuario y se le asignan los valores
            //a los campos de texto y al checkbox de Activo
            //Ademas de que se activa el boton de editar y eliminar
            DataGridViewRow MiFila = DgvLista.SelectedRows[0];
            int IDPromocion = Convert.ToInt32(MiFila.Cells["GCodigo"].Value);
            Logica.Promocion MiPromocion = new Logica.Promocion();
            PromocionLocal = MiPromocion.Consultar(IDPromocion);


            TxtCodigo.Text = PromocionLocal.PromocionID.ToString();
            TxtNombre.Text = PromocionLocal.Nombre;
            TxtPrecio.Text = PromocionLocal.Precio.ToString();
            TxtDescripcion.Text = PromocionLocal.Descripcion;
            TxtComentarios.Text = PromocionLocal.Comentarios;

            DTListaSushi.Clear();
            DTListaSushiEliminados.Clear();
            DatosAgregar.Clear();

            PromocionLocal.ListaSushi = MiPromocion.ListaSushi;
            foreach (Sushi item in MiPromocion.ListaSushi)
            {


                DataRow NuevaFila = DTListaSushi.NewRow();
                NuevaFila["SushiID"] = item.SushiID;
                NuevaFila["Nombre"] = item.Nombre;
                NuevaFila["Precio"] = item.Precio;
                DTListaSushi.Rows.Add(NuevaFila);
            }

            DgvSushi.DataSource = DTListaSushi;

        

            ActivarEditarEliminar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            int contadoritems = 0;
            bool encontrado = false;
            int encontradoen = 0;
            if (ValidarDatos())
            {

                //Si la verificacion de datos fue exitosa se crea un objeto de tipo sushi y se le asignan los valores ingresados por el usuario
                Logica.Promocion MiPromocion = new Logica.Promocion();

                MiPromocion.PromocionID = Convert.ToInt32(TxtCodigo.Text.Trim());
                MiPromocion.Nombre = TxtNombre.Text.Trim();
                MiPromocion.Descripcion = TxtDescripcion.Text.Trim();
                MiPromocion.Precio = Convert.ToDecimal(TxtPrecio.Text.Trim());
                MiPromocion.Comentarios = TxtComentarios.Text.Trim();
                MiPromocion.ListaSushi = PromocionLocal.ListaSushi;



                //Se eliminan los ingredientes
                foreach (int item2 in DTListaSushiEliminados)
                {
                    foreach (Sushi item in MiPromocion.ListaSushi)
                    {
                        int sushi = item2;
                        if (item2 == item.SushiID)
                        {

                            encontrado = true;
                            encontradoen = MiPromocion.ListaSushi.IndexOf(item);

                        }

                        contadoritems++;
                        if (contador == DTListaSushiEliminados.Count)
                        {
                            break;
                        }
                    }

                    if (contador == DTListaSushiEliminados.Count)
                    {
                        break;
                    }

                    if (encontrado)
                    {
                        MiPromocion.ListaSushi[encontradoen].Activo = false;
                        encontrado = false;
                    }


                }

                //Se agregan los ingredientes

                foreach (int item in DatosAgregar)
                {
                    Sushi MiSushi = new Sushi();
                    MiSushi = MiSushi.Consultar(item);
                    MiPromocion.ListaSushi.Add(MiSushi);
                }



                //Se verifica que el sushi exista
                if (MiPromocion.ConsultarPorID())
                {


                    if (MiPromocion.Editar())
                    {
                        //Si el procedimiento de editar al usuario fue correcto se muestra un mensaje al usuario y se limpian los campos
                        //De otra forma se muestran los respectivos mensajes de error
                        MessageBox.Show("Promocion editada correctamente", "Exito!", MessageBoxButtons.OK);
                        Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha editado la promocion de ID " + MiPromocion.PromocionID);

                        if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                        {
                            Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                        }

                        Limpiar();
                        LlenarLista(CbVerActivos.Checked);
                        ActivarAgregar();
                        DTListaSushiEliminados.Clear();
                        DatosAgregar.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al editar la promocion", "Error editar Promocion", MessageBoxButtons.OK);
                    }



                }
                else
                {
                    MessageBox.Show("No se ha encontrado la promocion a editar", "Error validacion editar promocion", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos requeridos", "Gestion promocion", MessageBoxButtons.OK);
            }
        }

        private void CbVerActivos_CheckedChanged(object sender, EventArgs e)
        {
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {

            Limpiar();
            DgvLista.ClearSelection();
            ActivarAgregar();

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                //Se verifican los datos y se crea un objeto de tipo usuario y se le asigna solamente el ID del usuario seleccionado
                Logica.Promocion MiPromocion = new Logica.Promocion();

                MiPromocion.PromocionID = Convert.ToInt32(TxtCodigo.Text.Trim());


                if (MiPromocion.ConsultarPorID())
                {
                    if (FlagActivar)
                    {

                        //Si el usuario esta activando el sushi
                        //Se ejecuta el metodo de activacion
                        if (MiPromocion.Activar())
                        {
                            MessageBox.Show("Promocion activada correctamente", "Exito!", MessageBoxButtons.OK);
                            Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha activado la promocion de ID " + MiPromocion.PromocionID);

                            if (Locale.ObjetosGlobales.MiFormBitacora.Visible)
                            {
                                Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                            }

                            Limpiar();
                            LlenarLista(CbVerActivos.Checked);
                            ActivarAgregar();


                        }
                        else
                        {
                            MessageBox.Show("Ha sucedido un error al activar la promocion", "Activacion promocion", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {//Si el usuario esta desactivando el sushi
                        //Se ejecuta el metodo de desactivacion
                        if (MiPromocion.Desactivar())
                        {
                            MessageBox.Show("Promocion desactivado correctamente", "Exito!", MessageBoxButtons.OK);
                            Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha desactivado la promocion de ID " + MiPromocion.PromocionID);

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
                            MessageBox.Show("Ha sucedido un error al desactivar la promocion", "Desactivacion promocion", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha encontrado la promocion", "Error validacion ID de promocion", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos requeridos", "Validacion de datos", MessageBoxButtons.OK);
            }
        }
    }
}
