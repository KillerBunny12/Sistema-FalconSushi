using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmGestionSushi : Form
    {

        private Logica.Sushi SushiLocal { get; set; }
        private bool FlagActivar { get; set; }

        public List<int> DatosAgregar;

        public DataTable DTListaIngredientes { get; set; }
        public List<int> DTListaIngredientesEliminados { get; set; }


        public DataTable ListaSushi { get; set; }
        public DataTable ListaSushiFiltro { get; set; }
        public FrmGestionSushi()
        {
            InitializeComponent();
            SushiLocal = new Logica.Sushi();
            LlenarLista(this.CbVerActivos.Checked);
            DTListaIngredientes = new DataTable();
            DTListaIngredientesEliminados = new List<int>();
            DatosAgregar = new List<int>();
        }

        private void FrmGestionSushi_Load(object sender, EventArgs e)
        {

            MdiParent = Locale.ObjetosGlobales.MiFormPrincipal;
            Limpiar();
            ActivarAgregar();
            DTListaIngredientes = SushiLocal.AsignarEsquemaDetalle();
            //DTListaIngredientesEliminados = SushiLocal.AsignarEsquemaDetalleEliminados();
        }


        private void Limpiar()
        {

            //Se limpian todos los campos de texto

            //Se aciva el checkbox de visualizar activos

            TxtBuscar.Clear();
            TxtCodigo.Clear();
            TxtNombre.Clear();
            TxtPrecio.Clear();

            TxtComentarios.Clear();
            
            DTListaIngredientes.Clear();
            DgvLista.ClearSelection();
            DatosAgregar.Clear();


        }

        private void LlenarLista(bool Activos, string Filtro = "")
        {

            //Se crea un objeto de tipo Sushi y dependiendo si se dio valores para filtrar
            //se muestra la tabla con filtro o sin filtro
            Logica.Sushi MiSushi = new Logica.Sushi();

            if (!String.IsNullOrEmpty(Filtro.Trim()))
            {
                ListaSushiFiltro = MiSushi.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaSushiFiltro;
            }
            else
            {
                ListaSushi = MiSushi.Listar(Activos, Filtro);
                DgvLista.DataSource = ListaSushi;
            }
            //Se limpia el DataGrid
            DgvLista.ClearSelection();

        }

        private void ActivarAgregar()
        {
            //Se activan el boton agregar y el campo de texto cedula
            BtnAgregar.Enabled = true;
            BtnAddIngrediente.Enabled = true;
            BtnEliminarIngrediente.Enabled = true;
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


                )
            {
                //Se verifica que se haya escogido al menos 1 igrediente para el sushi
                if (DgvIngredientes.Rows.Count == 0)
                {
                    MessageBox.Show("No se han escogido ingredientes para el sushi", "Error de validacion", MessageBoxButtons.OK);
                    return false;
                }

                r = true;


            }




            return r;
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica que lo escrito en el textbox sea un numero
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
                //Se verifican los campos y se asignan a la variable de sushi local
                SushiLocal = new Sushi();
                SushiLocal.Nombre = TxtNombre.Text.Trim();

                SushiLocal.Precio = Convert.ToDecimal(TxtPrecio.Text.Trim());

                SushiLocal.Comentarios = TxtComentarios.Text.Trim();

                LlenarDetalles();
                if (SushiLocal.Aregar())
                {
                    //Si la creacion del sushi fue exitosa se muestra un mensaje de exito y se procede a la creacion de la bitacora
                    //Se ejecuta la funcion de agregar bitacora dentro de los objetos globales con los daots
                    //Se vuelve allenar la lista y se limpian los campos
                    MessageBox.Show("Sushi agregado correctamente", "Exito!", MessageBoxButtons.OK);
                    Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha agregado el sushi de nombre: " + SushiLocal.Nombre + " y precio: " + SushiLocal.Precio);

                    if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                    {
                        Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                    }



                    Limpiar();
                    LlenarLista(this.CbVerActivos.Checked);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al intentar crear el sushi", "Error gestion sushi", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene todos los campos requeridos", "Verificacion datos", MessageBoxButtons.OK);
            }


        }

        private void LlenarDetalles()
        {
            
            foreach (DataRow fila in DTListaIngredientes.Rows)
            {
                //Por cada Ingrediente seleccionado
                //
                //Se crea un nuevo objeto ingrediente, se le asignan los valores y se agregan al sushi
                Logica.Ingrediente MiIngrediente = new Logica.Ingrediente();


                MiIngrediente.IngredienteID = Convert.ToInt32(fila["IngredienteID"]);

                SushiLocal.ListaIngredientes.Add(MiIngrediente);
            }
        }

        private void BtnAddIngrediente_Click(object sender, EventArgs e)
        {
            try
            {
                //Se abre el form de gestion agregar ingrdiente para poder seleccionar un ingrediente a agregar
                Form FormBuscarIngrediente = new Formularios.FrmGestionAgregarIngrediente();

                DialogResult Resp = FormBuscarIngrediente.ShowDialog();

                //Si la respuesta fue exitosa y se selecciono ingrediente
                //Se vuelve a cargar el datatable con los ingredientes seleccionados
                if (Resp == DialogResult.OK)
                {
                    DgvIngredientes.DataSource = DTListaIngredientes;

                    DgvLista.ClearSelection();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnEliminarIngrediente_Click(object sender, EventArgs e)
        {
            if (DgvIngredientes.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvIngredientes.SelectedRows[0];

                //Si se elimina un ingrediente del sushi se obtiene el ingrediente
                //Y se remueve del datatable

                DataRow toDelete = DTListaIngredientes.Select("IngredienteID = " + "'" + MiFila.Cells["GCodigoI"].Value.ToString() + "'" + " AND Nombre = " + "'" + MiFila.Cells["GNombreI"].Value.ToString() + "'")[0];

                int ingredienteremover = Convert.ToInt32(DgvIngredientes.SelectedRows[0].Cells["GCodigoI"].Value.ToString());
                DTListaIngredientesEliminados.Add(Convert.ToInt32(DgvIngredientes.SelectedRows[0].Cells["GCodigoI"].Value.ToString()));
                DTListaIngredientes.Rows.Remove(toDelete);

                //En caso de que este ingrediente estaba en fila para agregarse al sushi, se elimina de la cola.
                foreach (int item in DatosAgregar)
                {
                    if (item == ingredienteremover)
                    {
                        DatosAgregar.Remove(item);
                        break;
                    }
                }


                DgvIngredientes.DataSource = DTListaIngredientes;


            }
        }

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DatosAgregar.Clear();
            //Al seleccionar un item en el DataGrid se obtienen sus valores y se crea un objeto de usuario y se le asignan los valores
            //a los campos de texto y al checkbox de Activo
            //Ademas de que se activa el boton de editar y eliminar
            DataGridViewRow MiFila = DgvLista.SelectedRows[0];
            int IDSushi = Convert.ToInt32(MiFila.Cells["GCodigo"].Value);
            Logica.Sushi MiSushi = new Logica.Sushi();
            SushiLocal = MiSushi.Consultar(IDSushi);


            TxtCodigo.Text = SushiLocal.SushiID.ToString();
            TxtNombre.Text = SushiLocal.Nombre;
            TxtPrecio.Text = SushiLocal.Precio.ToString();
            TxtComentarios.Text = SushiLocal.Comentarios;

            DTListaIngredientes.Clear();
            DTListaIngredientesEliminados.Clear();
            DatosAgregar.Clear();

            SushiLocal.ListaIngredientes = MiSushi.ListaIngredientes;
            foreach (Ingrediente item in MiSushi.ListaIngredientes)
            {
                //Por cada ingrediente dentro del sushi
                //Se obtienen los datos
                //Y se agrega al datatable

                DataRow NuevaFila = DTListaIngredientes.NewRow();
                NuevaFila["IngredienteID"] = item.IngredienteID;
                NuevaFila["Nombre"] = item.Nombre;
                DTListaIngredientes.Rows.Add(NuevaFila);
            }

            DgvIngredientes.DataSource = DTListaIngredientes;

            

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
                Logica.Sushi MiSushi = new Logica.Sushi();

                MiSushi.SushiID = Convert.ToInt32(TxtCodigo.Text.Trim());
                MiSushi.Nombre = TxtNombre.Text.Trim();
                MiSushi.Precio = Convert.ToDecimal(TxtPrecio.Text.Trim());
                MiSushi.Comentarios = TxtComentarios.Text.Trim();
                MiSushi.ListaIngredientes = SushiLocal.ListaIngredientes;



                //Se eliminan los ingredientes
                //Se busca que la lista de ingredienets actual tenga el ingrediente a eliminar
                //En caso de ser encontrado, se cambia su estado a inactivo y se pone en cola de eliminacion.
                foreach (int item2 in DTListaIngredientesEliminados)
                {
                    foreach (Ingrediente item in MiSushi.ListaIngredientes)
                    {
                        int ingredinte = item2;
                        if (item2 == item.IngredienteID)
                        {

                            encontrado = true;
                            encontradoen = MiSushi.ListaIngredientes.IndexOf(item);

                        }

                        contadoritems++;
                        if (contador == DTListaIngredientesEliminados.Count)
                        {
                            break;
                        }
                    }

                    if (contador == DTListaIngredientesEliminados.Count)
                    {
                        break;
                    }

                    if (encontrado)
                    {
                        MiSushi.ListaIngredientes[encontradoen].Activo = false;
                        encontrado = false;
                    }


                }

                //Se agregan los ingredientes
                //Por cada ingrediente en la cola a agregar
                //Se crea un objeto ingrediente y se obtiene sus datos y se le agrega al sushi
                foreach (int item in DatosAgregar)
                {
                    Ingrediente MiIngrediente = new Ingrediente();
                    MiIngrediente = MiIngrediente.Consultar(item);
                    MiSushi.ListaIngredientes.Add(MiIngrediente);
                }



                //Se verifica que el sushi exista
                if (MiSushi.ConsultarPorID())
                {


                    if (MiSushi.Editar())
                    {
                        //Si el procedimiento de editar al sushi fue correcto se muestra un mensaje al usuario y se limpian los campos
                        //De otra forma se muestran los respectivos mensajes de error
                        MessageBox.Show("Sushi editado correctamente", "Exito!", MessageBoxButtons.OK);
                        Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha editado el sushi de ID " + MiSushi.SushiID);

                        if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                        {
                            Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                        }

                        Limpiar();
                        LlenarLista(CbVerActivos.Checked);
                        ActivarAgregar();
                        DTListaIngredientesEliminados.Clear();
                        DatosAgregar.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al editar el sushi", "Error editar Sushi", MessageBoxButtons.OK);
                    }



                }
                else
                {
                    MessageBox.Show("No se ha encontrado el Sushi a editar", "Error validacion editar sushi", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos requeridos", "Gestion sushi", MessageBoxButtons.OK);
            }
        }

        private void CbVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            //En caso de darse click al checkbox
            //Se vuelve a rellenar la lista de sushi
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

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Si se ingresa texto al campo de buscar se vuelve a llenar la lista con los sushi filtrados
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

                //Se verifican los datos y se crea un objeto de tipo sshi y se le asigna solamente el ID del sushi seleccionado
                Logica.Sushi MiSushi = new Logica.Sushi();

                MiSushi.SushiID = Convert.ToInt32(TxtCodigo.Text.Trim());


                if (MiSushi.ConsultarPorID())
                {
                    if (FlagActivar)
                    {

                        //Si el usuario esta activando el sushi
                        //Se ejecuta el metodo de activacion
                        if (MiSushi.Activar())
                        {
                            MessageBox.Show("Sushi activado correctamente", "Exito!", MessageBoxButtons.OK);
                            Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha activado el sushi de ID " + MiSushi.SushiID);

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
                            MessageBox.Show("Ha sucedido un error al activar el sushi", "Activacion sushi", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {//Si el usuario esta desactivando el sushi
                        //Se ejecuta el metodo de desactivacion
                        if (MiSushi.Desactivar())
                        {
                            MessageBox.Show("Sushi desactivado correctamente", "Exito!", MessageBoxButtons.OK);
                            Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha desactivado el sushi de ID " + MiSushi.SushiID);

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
                            MessageBox.Show("Ha sucedido un error al desactivar el sushi", "Desactivacion sushi", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el sushi", "Error validacion ID de sushi", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos requeridos", "Validacion de datos", MessageBoxButtons.OK);
            }
        }
    }
}
