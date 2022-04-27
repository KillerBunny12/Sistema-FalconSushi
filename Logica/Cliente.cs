using System;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public bool Activo { get; set; }





        public Cliente()
        {
            Activo = true;

        }

        public bool Agregar()
        {
            bool r = false;

            try
            {
                //Se crea un objeto de conexion y se le asignan parametros para el procedimiento almacenado y se ejecuta
                Conexion MiCOnexion = new Conexion();
                Crypto miencriptador = new Crypto();
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Direccion", this.Direccion));
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));



                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPClienteAgregar");


                //Si el insert fue exitoso retorna true, de otra forma retorna false y se le informa al usuario
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

        public bool Editar()
        {
            bool r = false;

            try
            {
                //Se crea un objeto de tipo conexion y se le dan los parametros necesarios para el procedimiento almacenado de editar
                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.ClienteID));

                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Direccion", this.Direccion));
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));




                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPClienteEditar");


                //Si el edit fue exitoso retorna true, de otra forma retorna false y se le informa al usuario
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

        public bool Desactivar()
        {
            bool r = false;
            try
            { //Se crea el objeto de tipo conexion y se le da el parametro de ID el cual servira para identificar el cliente
                //El procedimiento se encarga de cambiar la columna Activo a 0

                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.ClienteID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPClienteDesactivar");


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
            {
                //Se crea el objeto de tipo conexion y se le da el parametro de ID el cual servira para identificar el cliente
                //El procedimiento se encarga de cambiar la columna Activo a 1
                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.ClienteID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPClienteActivar");


                // Si el procedimiento fue exitoso retorna true, de otra forma retorna false y se le informa al usuario
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

        public Cliente Consultar(int PIDCliente)
        {//Se crea un objeto de tipo Cliente
            //Ademas de que se crea el objeto de tipo conexion y se le da el parametro de ID dado por el usuario
            Cliente r = new Cliente();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@IDCliente", PIDCliente));
            DataTable DatosCliente = new DataTable();
            DatosCliente = MiConexion.DMLSelect("SPClienteConsultar");

            if (DatosCliente.Rows.Count > 0)
            {
                //Si el procedimiento encontro el cliente consultado
                //Se le asignaran todos los valores al objeto Cliente r antes creado y se retorna
                DataRow MiFila = DatosCliente.Rows[0];
                r.ClienteID = Convert.ToInt32(MiFila["ClienteID"]);
                r.Nombre = Convert.ToString(MiFila["Nombre"]);
                r.Direccion = Convert.ToString(MiFila["Direccion"]);
                r.Telefono = Convert.ToString(MiFila["Telefono"]);


            }
            return r;
        }

        public DataTable Listar(bool VerActivos = true, string Filtro = "")
        {
            //Se crea el objeto de conexion y se le dan los parametros dados por el usuario los cuales sirven para decir
            //Si se veran los clientes activos o inactivos, ademas, de filtrar el valor Nombre
            //Se crea un datatable con los clientes y se retorna al usuario
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@VerActivos", VerActivos));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Filtro", Filtro));

            r = MiConexion.DMLSelect("SPClienteListar");
            return r;
        }

        public bool ConsultarPorID()
        {
            //La funcion sirve para saber si ya existe un cliente con el ID del cliente que esta ejecutando la funcion.
            //Si encuentra un cliente con el mismo ID retorna true
            bool R = false;
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.ClienteID));
            DataTable retorno = MiConexion.DMLSelect("SPClienteConsultarID");
            if (retorno.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

    }
}
