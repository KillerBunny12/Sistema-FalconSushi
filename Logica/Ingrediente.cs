using System;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Ingrediente
    {
        public int IngredienteID { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }


        public Ingrediente()
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



                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPIngredienteAgregar");


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


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.IngredienteID));

                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));





                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPIngredienteEditar");


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

        public bool Desactivar()
        {
            bool r = false;
            try
            { //Se crea el objeto de tipo conexion y se le da el parametro de ID el cual servira para identificar el usuario
                //El procedimiento se encarga de cambiar la columna Activo a 0

                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.IngredienteID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPIngredienteDesactivar");


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
                //Se crea el objeto de tipo conexion y se le da el parametro de ID el cual servira para identificar el usuario
                //El procedimiento se encarga de cambiar la columna Activo a 1
                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.IngredienteID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPIngredienteActivar");


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

        public Ingrediente Consultar(int PIDIngrediente)
        {//Se crea un objeto de tipo usuario
            //Ademas de que se crea el objeto de tipo conexion y se le da el parametro de ID dado por el usuario
            Ingrediente r = new Ingrediente();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@IDIngrediente", PIDIngrediente));
            DataTable DatosUsuario = new DataTable();
            DatosUsuario = MiConexion.DMLSelect("SPIngredienteConsultar");

            if (DatosUsuario.Rows.Count > 0)
            {
                //Si el procedimiento encontro el usuario consultado
                //Se le asignaran todos los valores al objeto usuario r antes creado y se retorna
                DataRow MiFila = DatosUsuario.Rows[0];
                r.IngredienteID = Convert.ToInt32(MiFila["IngredienteID"]);
                r.Nombre = Convert.ToString(MiFila["Nombre"]);


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

            r = MiConexion.DMLSelect("SPIngredienteListar");
            return r;
        }

        public bool ConsultarPorID()
        {
            //La funcion sirve para saber si ya existe un usuario con el ID del usuario que esta ejecutando la funcion.
            //Si encuentra un usuario con el mismo ID retorna true
            bool R = false;
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.IngredienteID));
            DataTable retorno = MiConexion.DMLSelect("SPIngredienteConsultarID");
            if (retorno.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }
    }
}
