using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Sushi
    {
        public int SushiID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Comentarios { get; set; }
        public bool Activo { get; set; }
        public List<Ingrediente> ListaIngredientes { get; set; }

        public Sushi()
        {
            Activo = true;
            ListaIngredientes = new List<Ingrediente>();
        }

        public bool Aregar()
        {
            bool r = false;
            //Se crea la clase conexion
            //Se le dan los parametros necesarios para el procedimieto almacenado y  se ejecuta
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Precio", this.Precio));

            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Comentarios", this.Comentarios));

            Object Retorno = MiConexion.DLMConRetornoEscalar("SPAgregarSushi");
            int IDSushiCreado;

            if (Retorno != null)
            {
                try
                {

                    //Si la creacion del sushi fue exitosa
                    //Se procede a crear la clase conexion nuevamente y darle paramtros//

                    IDSushiCreado = Convert.ToInt32(Retorno.ToString());
                    this.SushiID = IDSushiCreado;

                    int Acumulador = 0;
                    //Por cada item que haya en los ingredientes del sushi, se agrega en la base de datos.
                    //Se ejecuta hasta que ya no hayan mas items por agregar
                    foreach (Ingrediente item in this.ListaIngredientes)
                    {
                        Conexion MiCnn = new Conexion();
                        MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDSushi", this.SushiID));
                        MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDIngrediente", item.IngredienteID));


                        MiCnn.DMLUpdateDeleteInsert("SPSushiAgregarIngrediente");
                        Acumulador++;
                    }
                    if (Acumulador == this.ListaIngredientes.Count)
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

        //En caso remover el ingrediente de un sushi, se cambia su alor Activo, para que ya no se muestre ni se use por este sushi
        public void DesactivarIngrediente(int PIngredienteID)
        {
            foreach (Ingrediente item in this.ListaIngredientes)
            {

                if (item.IngredienteID == PIngredienteID)
                {
                    item.Activo = false;
                }


            }
        }
        public bool Editar()
        {
            bool r = false;
            bool encontrado = false;

            try
            {
                //Se crea un objeto de tipo conexion y se le dan los parametros necesarios para el procedimiento almacenado de editar
                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.SushiID));

                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Precio", this.Precio));

                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Comentarios", this.Comentarios));







                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPSushiEditar");


                //Si el insert fue exitoso retorna true, de otra forma retorna false y se le informa al usuario
                if (retorno > 0)
                {
                    try
                    {

                        int Acumulador = 0;
                        //Por cada item que haya en los ingredientes del sushi, se edita en la base de datos.
                        //Se ejecuta hasta que ya no hayan mas items por editar
                        foreach (Ingrediente item in this.ListaIngredientes)
                        {

                            //En caso de que el item ingrediente no este activo, se cambia en la base de datos
                            if (!item.Activo)
                            {
                                Conexion MiCnn = new Conexion();
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@SushiID", this.SushiID));
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IngredienteID", item.IngredienteID));


                                MiCnn.DMLUpdateDeleteInsert("SPSushiIngredienteDesactivar");


                            }
                            else
                            {

                                //En caso del ingrediente ser activo
                                //Se crea la clase conexion y se verifica que el ingrediente exista
                                //En caso de existir se agrega a la tabla SushiIngredientes
                                //Se ejecuta en un ciclo hasta que a no haya items en la lista
                                Conexion MiCnn = new Conexion();
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDSushi", this.SushiID));
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDIngrediente", item.IngredienteID));
                                DataTable datos = MiCnn.DMLSelect("SushiIngredienteConsultarID");
                                if (datos.Rows.Count > 0)
                                {
                                    encontrado = true;
                                }
                                else
                                {
                                    encontrado = false;
                                }

                            }

                            if (!encontrado)
                            {
                                Conexion MiCnn = new Conexion();
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDSushi", this.SushiID));
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDIngrediente", item.IngredienteID));
                                MiCnn.DMLUpdateDeleteInsert("SPSushiAgregarIngrediente");

                            }

                            Acumulador++;
                        }
                        if (Acumulador == this.ListaIngredientes.Count)
                        {
                            r = true;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
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
            { //Se crea el objeto de tipo conexion y se le da el parametro de ID el cual servira para identificar el Sushi
                //El procedimiento se encarga de cambiar la columna Activo a 0

                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.SushiID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPSushiDesactivar");


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
                //Se crea el objeto de tipo conexion y se le da el parametro de ID el cual servira para identificar el sushi
                //El procedimiento se encarga de cambiar la columna Activo a 1
                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.SushiID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPSushiActivar");


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

        public Sushi Consultar(int PIDSushi)
        {//Se crea un objeto de tipo Sushi
            //Ademas de que se crea el objeto de tipo conexion y se le da el parametro de ID dado por el usuario
            Sushi r = new Sushi();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@IDSushi", PIDSushi));
            DataTable DatosSushi = new DataTable();
            DatosSushi = MiConexion.DMLSelect("SPSushiConsultar");


            if (DatosSushi.Rows.Count > 0)
            {
                //Si el procedimiento encontro el sushi consultado
                //Se le asignaran todos los valores al objeto usuario r antes creado y se retorna
                //Ademasse agregan los ingredientes encontrados a la lista
                DataRow MiFila = DatosSushi.Rows[0];
                r.SushiID = Convert.ToInt32(MiFila["SushiID"]);
                r.Nombre = Convert.ToString(MiFila["Nombre"]);
                r.Precio = Convert.ToDecimal(MiFila["Precio"]);
                r.Comentarios = Convert.ToString(MiFila["Comentarios"]);
                r.Activo = Convert.ToBoolean(MiFila["Activo"]);

                Conexion MiCnn = new Conexion();
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDSushi", PIDSushi));
                DataTable DatosIngredientes = new DataTable();
                DatosIngredientes = MiCnn.DMLSelect("SPConsultarIngredientePorSushi");
                if (DatosIngredientes.Rows.Count > 0)
                {
                    for (int i = 0; i < DatosIngredientes.Rows.Count; i++)
                    {
                        int IDIngrediente;
                        Ingrediente MiIngrediente = new Ingrediente();
                        DataRow MiFilaI = DatosIngredientes.Rows[i];

                        IDIngrediente = Convert.ToInt32(MiFilaI["IngredienteID"]);

                        ListaIngredientes.Add(MiIngrediente.Consultar(IDIngrediente));
                    }
                }

            }
            return r;
        }




        public DataTable Listar(bool VerActivos = true, string Filtro = "")
        {
            //Se crea el objeto de conexion y se le dan los parametros dados por el usuario los cuales sirven para decir
            //Si se veran los sushis activos o inactivos, ademas, de filtrar el valor Nombre
            //Se crea un datatable con los sushis y se retorna al usuario
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@VerActivos", VerActivos));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Filtro", Filtro));

            r = MiConexion.DMLSelect("SPSushiListar");
            return r;
        }

        public bool ConsultarPorID()
        {
            //La funcion sirve para saber si ya existe un sushi con el ID del sushi que esta ejecutando la funcion.
            //Si encuentra un sushi con el mismo ID retorna true
            bool R = false;
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.SushiID));
            DataTable retorno = MiConexion.DMLSelect("SPSushiConsultarID");
            if (retorno.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

        public DataTable AsignarEsquemaDetalle()
        {
            //Esta funcion asigna el esquema necesario para los valores de el formulario gestion de sushi
            //Se ejecuta el procedimiento almacenado y devuelve el esquema creado
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();
            r = MiConexion.DMLSelect("AsignarEsquemaSushiIngrediente", true);
            return r;
        }

        public DataTable AsignarEsquemaDetalleEliminados()
        {
            //Esta funcion asigna el esquema necesario para los valores de el formulario gestion de sushi
            //Se ejecuta el procedimiento almacenado y devuelve el esquema creado
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();
            r = MiConexion.DMLSelect("AsignarEsquemaSushiIngredienteEliminados", true);
            return r;
        }
    }
}
