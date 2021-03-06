using Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmCrearPedido : Form
    {

        public Logica.Pedido MiPedidoLocal { get; set; }
        public DataTable DTListaSushi { get; set; }
        public DataTable DTListaPromocion { get; set; }
        public Logica.Sushi MiSushiLocal { get; set; }
        public Logica.Promocion MiPromocionLocal { get; set; }
        public Logica.Cliente MiClienteLocal { get; set; }

        public FrmCrearPedido()
        {
            InitializeComponent();
            MiPedidoLocal = new Logica.Pedido();
            DTListaSushi = new DataTable();
            DTListaPromocion = new DataTable();
            MiSushiLocal = new Logica.Sushi();
            MiPromocionLocal = new Logica.Promocion();
            MiClienteLocal = null;



        }

        private void FrmCrearPedido_Load(object sender, EventArgs e)
        {
            MdiParent = Locale.ObjetosGlobales.MiFormPrincipal;
            //Se asigna el usuario global como el facturador
            LblUsuarioRegistra.Text = "Compra registrada por " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre;
            Limpiar();
            GenerarNumeroFactura();

        }

        private void GenerarNumeroFactura()
        {
            //Se genera un numero de factura aleatorio que comienza con "FS-"
            //Y se le asigna al campo de texto
            string nf = "FS-";

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[10];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            nf += new String(stringChars);
            TxtNumeroFactura.Text = nf;
        }


        private void Limpiar()
        {
            //Se limpian todos los campos
            //Se genera un nuevo numero de actura
            //Se carga el esquema de compra al DataTable y se carga en el DataGrid
            DtpFecha.Value = DateTime.Now.Date;
            TxtNumeroFactura.Clear();

            DTListaSushi = MiPedidoLocal.AsignarEsquemaSushi();
            DTListaPromocion = MiPedidoLocal.AsignarEsquemaPromocion();
            DgvListaSushi.DataSource = DTListaSushi;
            DgvListaPromocion.DataSource = DTListaPromocion;
            //DgvLista.DataSource = DTListaProductos;
            TxtTotalCompra.Text = "0";
            GenerarNumeroFactura();

            CBCliente.Checked = false;
            MiPedidoLocal = new Pedido();

        }

        private void BtnAgregarSushi_Click(object sender, EventArgs e)
        {
            try
            {
                //Se abre el form de gestion pedido agregar sushi para poder seleccionar un sushi a agregar
                Form FormBuscarSushi = new Formularios.FrmGestionPedidoAgregarSushi();

                DialogResult Resp = FormBuscarSushi.ShowDialog();

                //Si la respuesta fue exitosa y se selecciono sushi
                //Se vuelve a cargar el datatable con el sushi seleccionados y se calcula el precio de venta
                if (Resp == DialogResult.OK)
                {
                    DgvListaSushi.DataSource = DTListaSushi;
                    TxtTotalCompra.Text = string.Format("{0:c2}", Totalizar());

                    DgvListaSushi.ClearSelection();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Decimal Totalizar()
        {
            decimal r = 0;

            //Se verifica que haya al menos 1 sushi en la compra
            if (DTListaSushi.Rows.Count > 0)
            {
                foreach (DataRow item in DTListaSushi.Rows)
                {
                    //Por cada sushi seleccionado se calcula el precio total
                    r += Convert.ToDecimal(item["Cantidad"]) * Convert.ToDecimal(item["Precio"]);
                }
            }

            //Se verifica que haya al menos 1 promocion en la compra
            if (DTListaPromocion.Rows.Count > 0)
            {
                foreach (DataRow item in DTListaPromocion.Rows)
                {
                    //Por cada promocion seleccionado se calcula el precio total
                    r += Convert.ToDecimal(item["Cantidad"]) * Convert.ToDecimal(item["Precio"]);
                }
            }
            return r;
        }

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {

            //Se verifica que la fecha no sea mayor a la actual
            if (DtpFecha.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("La fecha del pedido no puede ser mayor a la fecha actual", "Error de validacion", MessageBoxButtons.OK);
                DtpFecha.Value = DateTime.Now.Date;


            }
        }

        private void BtnAgregarPromocion_Click(object sender, EventArgs e)
        {
            try
            {
                //Se abre el form de gestion pedido agregar promocion para poder seleccionar una promocion a agregar
                Form FormBuscarPromocion = new Formularios.FrmGestionPedidoAgregarPromocion();

                DialogResult Resp = FormBuscarPromocion.ShowDialog();

                //Si la respuesta fue exitosa y se selecciono promocion
                //Se vuelve a cargar el datatable con la promocion seleccionado y se calcula el precio de venta
                if (Resp == DialogResult.OK)
                {
                    DgvListaPromocion.DataSource = DTListaPromocion;
                    TxtTotalCompra.Text = string.Format("{0:c2}", Totalizar());

                    DgvListaPromocion.ClearSelection();
                }

            }

            catch (Exception)
            {

                throw;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnCrearCompra_Click(object sender, EventArgs e)
        {
            if (ValidarCompra())
            {
                //Se verifican los campos y se asignan a la variable de compra local
                MiPedidoLocal.Fecha = DtpFecha.Value.Date;

                MiPedidoLocal.usuario.UsuarioID = Locale.ObjetosGlobales.MiUsuarioGlobal.UsuarioID;
                MiPedidoLocal.NumeroFctura = TxtNumeroFactura.Text.Trim();


                MiPedidoLocal.Total = Convert.ToDecimal(Totalizar());

                //En caso de haber seleccionado un cliente, se asigna el tipo de compra con cliente
                //En otro caso, el cliente sera anonimo
                if (MiClienteLocal != null)
                {
                    MiPedidoLocal.cliente = MiClienteLocal;
                    MiPedidoLocal.Tipo = true;
                }
                else
                {
                    MiPedidoLocal.Tipo = false;
                }


                LlenarDetalles();
                if (MiPedidoLocal.Agregar())
                {
                    //Si la compra fue exitosa se muestra un mensaje de exito y se procede a la creacion de la bitacora
                    //Se crea la bitacora con los datos de la compra creada
                    MessageBox.Show("Se ha creado la compra correctamente", "Exito", MessageBoxButtons.OK);
                    Locale.ObjetosGlobales.AgregarBitacora("El usuario: " + Locale.ObjetosGlobales.MiUsuarioGlobal.Nombre + " ha creado la compra con el numero de factura " + MiPedidoLocal.NumeroFctura);

                    if (Locale.ObjetosGlobales.MiFormBitacora != null && Locale.ObjetosGlobales.MiFormBitacora.Visible)
                    {
                        Locale.ObjetosGlobales.MiFormBitacora.LlenarLista(Locale.ObjetosGlobales.MiFormBitacora.VerUltimoMes);
                    }

                 
                    
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al intentar registrar la compra", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Rellene todos los campos requeridos", "Verificacion datos", MessageBoxButtons.OK);
            }
        }

        private void LlenarDetalles()
        {
            foreach (DataRow fila in DTListaSushi.Rows)
            {
                //Por cada sushi en la compra
                //
                //Se crea un nuevo objeto de linea de deallte y se le asignan los valores calculados y se agregan a la compra
                //Se le asignan los datos del sushi
                //Se asigna la promocion como null
                Sushi MiSushi = new Sushi();
                Logica.PedidoDetalle MiDetalle = new Logica.PedidoDetalle();
                MiDetalle.promocion = null;
                MiDetalle.sushi = MiSushi.Consultar(Convert.ToInt32(fila["SushiID"]));
                MiDetalle.Cantidad = Convert.ToInt32(fila["Cantidad"]);

                //MiDetalle.MiProducto.Nombre = fila["Nombre"].ToString();

                MiPedidoLocal.ListaDetalles.Add(MiDetalle);
            }

            foreach (DataRow fila in DTListaPromocion.Rows)
            {
                //Por cada promocion en la compra
                //
                //Se crea un nuevo objeto de linea de deallte y se le asignan los valores calculados y se agregan a la compra
                //Se le asignan los datos d ela promocion
                //Se asigna el sushi como null
                Promocion miPromocion = new Promocion();
                Logica.PedidoDetalle MiDetalle = new Logica.PedidoDetalle();
                MiDetalle.sushi = null;
                MiDetalle.promocion = miPromocion.Consultar(Convert.ToInt32(fila["PromocionID"]));
                MiDetalle.Cantidad = Convert.ToInt32(fila["Cantidad"]);

                //MiDetalle.MiProducto.Nombre = fila["Nombre"].ToString();

                MiPedidoLocal.ListaDetalles.Add(MiDetalle);
            }
        }

        private bool ValidarCompra()
        {
            bool r = false;
            //Se verifica que la fecha no sea mayor a la actual ademas de que los campos de texto no esten vacios
            //Se verifica que se haya seleccionado al menos 1 sushi O Promocion
            //De otra forma, se muestran los mensajes de error correspondientes
            if (DtpFecha.Value.Date <= DateTime.Now.Date

                && !string.IsNullOrEmpty(TxtNumeroFactura.Text.Trim())
                && (DTListaSushi.Rows.Count > 0 || DTListaPromocion.Rows.Count > 0)

                )
            {
                r = true;
            }
            else
            {
                if (DtpFecha.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha del pedido no puede ser mayor a la fecha actual", "Error de validacion", MessageBoxButtons.OK);
                    return false;
                }



                if (string.IsNullOrEmpty(TxtNumeroFactura.Text.Trim()))
                {
                    MessageBox.Show("El numero de factura no puede estar vacio", "Error de validacion", MessageBoxButtons.OK);
                    return false;
                }

                if (DTListaPromocion.Rows.Count == 0 && DTListaSushi.Rows.Count > 0)
                {
                    MessageBox.Show("No se han escogido productos a comprar", "Error de validacion", MessageBoxButtons.OK);
                    return false;
                }

            }
            return r;
        }

        private void CBCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (CBCliente.Checked)
            {
                //En caso de darle click al check de usar cliente
                try
                {
                    //Se abre el form de gestion pedido agregar cliente para poder seleccionar un cliente para el pedido
                    Locale.ObjetosGlobales.MiFormPedidAgregarcliente = new Formularios.FrmGestionPedidoAgregarClientr();

                    DialogResult Resp = Locale.ObjetosGlobales.MiFormPedidAgregarcliente.ShowDialog();

                    //Si la respuesta fue exitosa y se selecciono cliente
                    //Se asigna el campo de texto con el nombre del cliente
                    if (Resp == DialogResult.OK)
                    {
                        TxtCliente.Text = MiClienteLocal.Nombre;
                    }
                    else
                    {
                        CBCliente.Checked = false;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                //En caso de que se desactive la opcion
                //Se remueve el cliente
                //Y el campo de texto cambia a Anonimo
                MiClienteLocal = null;
                TxtCliente.Text = "Anonimo";
            }
        }

        private void BtnEliminarSushi_Click(object sender, EventArgs e)
        {
            if (DgvListaSushi.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvListaSushi.SelectedRows[0];
                //En caso de haberse seleccionado 1 sushi
                //Si se elimina un sushi de la compra se obtiene el sushi y se elimina del datatable
                //Se vuelve a calcular el total del pedido

                DataRow toDelete = DTListaSushi.Select("SushiID = " + MiFila.Cells["GCodigo"].Value.ToString())[0];
                DTListaSushi.Rows.Remove(toDelete);
                DgvListaSushi.DataSource = DTListaSushi;
                TxtTotalCompra.Text = string.Format("{0:c2}", Totalizar());


            }
        }

        private void BtnEliminarPromocion_Click(object sender, EventArgs e)
        {
            if (DgvListaPromocion.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvListaPromocion.SelectedRows[0];

                //En caso de haberse seleccionado 1 promocion
                //Si se elimina una promocion de la compra se obtiene la promocion y se elimina del datatable
                //Se vuelve a calcular el total del pedido

                DataRow toDelete = DTListaPromocion.Select("PromocionID = " + MiFila.Cells["GCodigo"].Value.ToString())[0];
                DTListaPromocion.Rows.Remove(toDelete);
                DgvListaPromocion.DataSource = DTListaPromocion;
                TxtTotalCompra.Text = string.Format("{0:c2}", Totalizar());


            }
        }
    }
}
