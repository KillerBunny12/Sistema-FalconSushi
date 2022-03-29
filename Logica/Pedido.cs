using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public string NumeroFctura { get; set; }
        public Cliente cliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; }
        public bool Tipo { get; set; }
        public Usuario usuario { get; set; }

        public List<PedidoDetalle> ListaDetalles { get; set; }

        public Pedido()
        {
            Activo = true;
            cliente = new Cliente();
            usuario = new Usuario();
            ListaDetalles = new List<PedidoDetalle>();

        }



        public bool Agregar()
        {
            bool r = false;
            //Se crea la clase conexion
            //Se le dan los parametros necesarios para el procedimieto almacenado y  se ejecuta
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Fecha", this.Fecha));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@NumeroFactura", this.NumeroFctura));


            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Total", this.Total));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Tipo", this.Tipo));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@IDUsuario", this.usuario.UsuarioID));
            Object Retorno;
            if (this.cliente != null && !string.IsNullOrEmpty(this.cliente.Nombre))
            {
                MiConexion.ListadoDeParametros.Add(new SqlParameter("@IDCliente", this.cliente.ClienteID));
                Retorno = MiConexion.DLMConRetornoEscalar("SPPedidoAgregarEncabezado");
            }
            else
            {
                Retorno = MiConexion.DLMConRetornoEscalar("SPPedidoAgregarEncabezadoNoCliente");
            }

            int idCompraCreada;

            if (Retorno != null)
            {
                try
                {

                    //Si la creacion de la compra fue exitosa
                    //Se procede a crear la clase conexion nuevamente y darle paramtros//

                    idCompraCreada = Convert.ToInt32(Retorno.ToString());
                    this.PedidoID = idCompraCreada;

                    int Acumulador = 0;
                    //Por cada item que haya en la compra detalle de la compra, se agrega en la base de datos.
                    //Se ejecuta hasta que ya no hayan mas items por agregar
                    foreach (PedidoDetalle item in this.ListaDetalles)
                    {
                        Conexion MiCnn = new Conexion();
                        MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDPedido", this.PedidoID));
                        if (item.sushi != null)
                        {
                            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDSushi", item.sushi.SushiID));


                            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Subtotal", item.Cantidad * item.sushi.Precio));
                        }

                        if (item.promocion != null)
                        {
                            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDPromocion", item.promocion.PromocionID));
                            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Subtotal", item.Cantidad * item.promocion.Precio));
                        }

                        MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cantidad", item.Cantidad));




                        MiCnn.DMLUpdateDeleteInsert("SPPedidoAgregarDetalles");
                        Acumulador++;
                    }
                    if (Acumulador == this.ListaDetalles.Count)
                    {
                        r = true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return r;
        }

        public DataTable Listar(bool VerActivos = true, string Filtro = "")
        {
            //Se crea el objeto de conexion y se le dan los parametros dados por el usuario los cuales sirven para decir
            //Si se veran los usuarios activos o inactivos, ademas, de filtrar valores como nombre o user.
            //Se crea un datatable con los usuarios y se retorna al usuario
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@VerActivos", VerActivos));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Filtro", Filtro));

            r = MiConexion.DMLSelect("ListarPedidos");
            return r;
        }

        public Pedido Consultar(int PIDPedido)
        {//Se crea un objeto de tipo Sushi
            //Ademas de que se crea el objeto de tipo conexion y se le da el parametro de ID dado por el usuario
            Pedido r = new Pedido();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@IDPedido", PIDPedido));
            DataTable DatosPedido = new DataTable();
            DatosPedido = MiConexion.DMLSelect("SPPedidoConultar");


            if (DatosPedido.Rows.Count > 0)
            {
                //Si el procedimiento encontro el usuario consultado
                //Se le asignaran todos los valores al objeto usuario r antes creado y se retorna
                DataRow MiFila = DatosPedido.Rows[0];
                r.PedidoID = Convert.ToInt32(MiFila["PedidoID"]);
                r.NumeroFctura = Convert.ToString(MiFila["NumeroFactura"]);
                // r.cliente.ClienteID = Convert.ToInt32(MiFila["IDCliente"]);
                r.usuario.UsuarioID = Convert.ToInt32(MiFila["IDUsuario"]);
                r.Total = Convert.ToDecimal(MiFila["Total"]);
                r.Fecha = Convert.ToDateTime(MiFila["Fecha"]);
                r.Activo = Convert.ToBoolean(MiFila["Activo"]);
                r.Tipo = Convert.ToBoolean(MiFila["Tipo"]);

                Conexion MiCnn = new Conexion();
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDPedido", PIDPedido));
                DataTable DatosPedidoDetalle = new DataTable();
                DatosPedidoDetalle = MiCnn.DMLSelect("ListarPedidoDetalle");
                if (DatosPedidoDetalle.Rows.Count > 0)
                {
                    for (int i = 0; i < DatosPedidoDetalle.Rows.Count; i++)
                    {
                        int IDDetalle;
                        PedidoDetalle MiPedidoDetalle = new PedidoDetalle();
                        DataRow MiFilaI = DatosPedidoDetalle.Rows[i];

                        IDDetalle = Convert.ToInt32(MiFilaI["PedidoDetalleID"]);

                        ListaDetalles.Add(MiPedidoDetalle.Consultar(IDDetalle));
                    }
                }

            }
            return r;
        }

        public bool ConsultarPorID()
        {
            //La funcion sirve para saber si ya existe un usuario con el ID del usuario que esta ejecutando la funcion.
            //Si encuentra un usuario con el mismo ID retorna true
            bool R = false;
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.PedidoID));
            DataTable retorno = MiConexion.DMLSelect("SPPedidoConsultarID");
            if (retorno.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

        public bool ConsultarPorNumeroFactura()
        {
            //La funcion sirve para saber si ya existe un usuario con el ID del usuario que esta ejecutando la funcion.
            //Si encuentra un usuario con el mismo ID retorna true
            bool R = false;
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@NumeroFactura", this.NumeroFctura));
            DataTable retorno = MiConexion.DMLSelect("SPPedidoConsultarNumeroFactura");
            if (retorno.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }


        public bool Desactivar()
        {
            bool r = false;
            try
            { //Se crea el objeto de tipo conexion y se le da el parametro de ID el cual servira para identificar el usuario
                //El procedimiento se encarga de cambiar la columna Activo a 0

                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.PedidoID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPPedidoDesactivar");


                // Si el desactivado fue exitoso retorna true, de otra forma retorna false y se le informa al usuario
                if (retorno > 0)
                {
                    r = true;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return r;
        }

        public bool Activar()
        {
            bool r = false;
            try
            { //Se crea el objeto de tipo conexion y se le da el parametro de ID el cual servira para identificar el usuario
                //El procedimiento se encarga de cambiar la columna Activo a 0

                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.PedidoID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPPedidoActivar");


                // Si el desactivado fue exitoso retorna true, de otra forma retorna false y se le informa al usuario
                if (retorno > 0)
                {
                    r = true;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return r;
        }


        public DataTable AsignarEsquemaSushi()
        {
            //Esta funcion asigna el esquema necesario para los valores de el formulario gestion de compras
            //Se ejecuta el procedimiento almacenado y devuelve el esquema creado
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();
            r = MiConexion.DMLSelect("SPAsignarEsquemaPedidoSushi", true);
            return r;
        }

        public DataTable AsignarEsquemaPromocion()
        {
            //Esta funcion asigna el esquema necesario para los valores de el formulario gestion de compras
            //Se ejecuta el procedimiento almacenado y devuelve el esquema creado
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();
            r = MiConexion.DMLSelect("SPAsignarEsquemaPedidoPromocion", true);
            return r;
        }

        public DataTable AsignarEsquemaDetalles()
        {
            //Esta funcion asigna el esquema necesario para los valores de el formulario gestion de compras
            //Se ejecuta el procedimiento almacenado y devuelve el esquema creado
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();
            r = MiConexion.DMLSelect("SPAsignarEsquemaPedidoDetalles", true);
            return r;
        }


    }
}
