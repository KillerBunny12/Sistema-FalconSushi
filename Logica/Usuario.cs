using System;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public bool Activo { get; set; }


        public Usuario()
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
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@User", this.User));


                string MiPasswordEncriptado = miencriptador.EncriptarPassword(this.Pass);
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Pass", MiPasswordEncriptado));


                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPUsuarioAgregar");


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


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@User", this.User));

                //Usando la clase Crypto se encripta el password antes de guardarse en la base de datos
                Crypto MiEncriptador = new Crypto();
                string PasswordEncriptado = "";

                if (!string.IsNullOrEmpty(this.Pass))
                {
                    PasswordEncriptado = MiEncriptador.EncriptarPassword(this.Pass);

                }

                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Pass", PasswordEncriptado));


                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPUsuarioEditar");


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


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPUsuarioDesactivar");


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

        public Usuario Consultar(int PIDUsuario)
        {//Se crea un objeto de tipo usuario
            //Ademas de que se crea el objeto de tipo conexion y se le da el parametro de ID dado por el usuario
            Usuario r = new Usuario();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@IDUsuario", PIDUsuario));
            DataTable DatosUsuario = new DataTable();
            DatosUsuario = MiConexion.DMLSelect("SPUsuarioConsular");

            if (DatosUsuario.Rows.Count > 0)
            {
                //Si el procedimiento encontro el usuario consultado
                //Se le asignaran todos los valores al objeto usuario r antes creado y se retorna
                DataRow MiFila = DatosUsuario.Rows[0];
                r.UsuarioID = Convert.ToInt32(MiFila["UsuarioID"]);
                r.Nombre = Convert.ToString(MiFila["Nombre"]);
                r.User = Convert.ToString(MiFila["User"]);
                r.Pass = Convert.ToString(MiFila["Pass"]);
                r.Activo = Convert.ToBoolean(MiFila["Activo"]);

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

            r = MiConexion.DMLSelect("SPUsuarioListar");
            return r;
        }


        public int ValidarLogin(string pUser, string pPass)
        {
            int R = 0;
            //Se obtienen el email y password que el usuario ingreso en el login y se encripta el password.
            //Estas variables se asignan como parametros para el procedimiento almacenado y se comparan en la base de datos
            //Si el procedimiento encuentra un usuario con el mismo email y password
            //Se retorna el ID del usuario encontrado
            this.User = pUser;
            this.Pass = pPass;
            Crypto crypto = new Crypto();

            string PasswordEncriptado = crypto.EncriptarPassword(this.Pass);
            Conexion MiConexion = new Conexion();

            MiConexion.ListadoDeParametros.Add(new SqlParameter("@User", this.User));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Pass", PasswordEncriptado));
            DataTable Respuesta = MiConexion.DMLSelect("SPUsuarioValidadLogin");
            if (Respuesta != null && Respuesta.Rows.Count > 0)
            {
                DataRow MiFila = Respuesta.Rows[0];
                R = Convert.ToInt32(MiFila["UsuarioID"]);
            }


            return R;
        }

        public bool ConsultarPorID()
        {
            //La funcion sirve para saber si ya existe un usuario con el ID del usuario que esta ejecutando la funcion.
            //Si encuentra un usuario con el mismo ID retorna true
            bool R = false;
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));
            DataTable retorno = MiConexion.DMLSelect("SQUsuarioConsultarPorID");
            if (retorno.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

        public bool Activar()
        {
            bool r = false;
            try
            {
                //Se crea el objeto de tipo conexion y se le da el parametro de ID el cual servira para identificar el usuario
                //El procedimiento se encarga de cambiar la columna Activo a 1
                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPUSuarioActivar");


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

    }
}
