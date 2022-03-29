using System;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class PedidoDetalle
    {
        public int PedidoDetalleID { get; set; }
        public Pedido pedido { get; set; }
        public Sushi sushi { get; set; }
        public Promocion promocion { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public PedidoDetalle()
        {

            sushi = new Sushi();
            promocion = new Promocion();
            pedido = new Pedido();
        }

        public DataTable Listar(int PIDPedido)
        {
            //Se crea el objeto de conexion y se le dan los parametros dados por el usuario los cuales sirven para decir
            //Si se veran los usuarios activos o inactivos, ademas, de filtrar valores como nombre o user.
            //Se crea un datatable con los usuarios y se retorna al usuario
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@IDPedido", PIDPedido));


            r = MiConexion.DMLSelect("ListarPedidoDetalle");
            return r;
        }

        public PedidoDetalle Consultar(int PIDPedidoDetalle)
        {//Se crea un objeto de tipo usuario
            //Ademas de que se crea el objeto de tipo conexion y se le da el parametro de ID dado por el usuario
            PedidoDetalle r = new PedidoDetalle();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@IDPedidoDetalle", PIDPedidoDetalle));
            DataTable DatosDetalle = new DataTable();
            DatosDetalle = MiConexion.DMLSelect("SPDetalleConsultar");

            if (DatosDetalle.Rows.Count > 0)
            {
                //Si el procedimiento encontro el usuario consultado
                //Se le asignaran todos los valores al objeto usuario r antes creado y se retorna
                DataRow MiFila = DatosDetalle.Rows[0];
                r.PedidoDetalleID = Convert.ToInt32(MiFila["PedidoDetalleID"]);
                r.pedido.PedidoID = Convert.ToInt32(MiFila["IDPedido"]);
                if (MiFila["IDSushi"] != System.DBNull.Value)
                {
                    r.sushi.SushiID = Convert.ToInt32(MiFila["IDSushi"]);
                    r.promocion = null;
                }
                else if (MiFila["IDPromocion"] != System.DBNull.Value)
                {
                    r.promocion.PromocionID = Convert.ToInt32(MiFila["IDPromocion"]);
                    r.sushi = null;
                }


                r.Cantidad = Convert.ToInt32(MiFila["Cantidad"]);
                r.Subtotal = Convert.ToDecimal(MiFila["Subtotal"]);


            }
            return r;
        }
    }
}
