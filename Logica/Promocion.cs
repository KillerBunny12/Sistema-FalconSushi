using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Promocion
    {
        public int PromocionID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Comentarios { get; set; }
        public bool Activo { get; set; }


        public List<Sushi> ListaSushi { get; set; }

        public Promocion()
        {
            Activo = true;
            ListaSushi = new List<Sushi>();
        }


        public bool Aregar()
        {
            bool r = false;
            //Se crea la clase conexion
            //Se le dan los parametros necesarios para el procedimieto almacenado y  se ejecuta
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Descripcion", this.Descripcion));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Precio", this.Precio));
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Comentarios", this.Comentarios));

            Object Retorno = MiConexion.DLMConRetornoEscalar("SPAgregarPromocion");
            int IDPromocioCreada;

            if (Retorno != null)
            {
                try
                {

                    //Si la creacion de la promocion fue exitosa
                    //Se procede a crear la clase conexion nuevamente y darle paramtros//

                    IDPromocioCreada = Convert.ToInt32(Retorno.ToString());
                    this.PromocionID = IDPromocioCreada;

                    int Acumulador = 0;
                    //Por cada item que haya en los ingredientes del sushi, se agrega en la base de datos.
                    //Se ejecuta hasta que ya no hayan mas items por agregar
                    foreach (Sushi item in this.ListaSushi)
                    {
                        Conexion MiCnn = new Conexion();
                        MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDPromocion", this.PromocionID));
                        MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDSushi", item.SushiID));


                        MiCnn.DMLUpdateDeleteInsert("SPPromocionAgregarSushi");
                        Acumulador++;
                    }
                    if (Acumulador == this.ListaSushi.Count)
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

        public void DesactivarSushi(int PSushiID)
        {
            foreach (Sushi item in this.ListaSushi)
            {

                if (item.SushiID == PSushiID)
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


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.PromocionID));

                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Descripcion", this.Descripcion));
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Precio", this.Precio));
                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@Comentarios", this.Comentarios));







                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPPromocionEditar");


                //Si el insert fue exitoso retorna true, de otra forma retorna false y se le informa al usuario
                if (retorno > 0)
                {
                    try
                    {

                        int Acumulador = 0;
                        //Por cada item que haya en los sushi de la promocion, se edita en la base de datos.
                        //Se ejecuta hasta que ya no hayan mas items por editar
                        foreach (Sushi item in this.ListaSushi)
                        {

                            if (!item.Activo)
                            {
                                Conexion MiCnn = new Conexion();
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@PromocionID", this.PromocionID));
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@SushiID", item.SushiID));


                                MiCnn.DMLUpdateDeleteInsert("SPPromocionSushiDesactivar");


                            }
                            else
                            {
                                Conexion MiCnn = new Conexion();
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@PromocionID", this.PromocionID));
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@SushiID", item.SushiID));
                                DataTable datos = MiCnn.DMLSelect("SPPromocionSushiConsultarID");
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
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@PromocionID", this.PromocionID));
                                MiCnn.ListadoDeParametros.Add(new SqlParameter("@SushiID", item.SushiID));
                                MiCnn.DMLUpdateDeleteInsert("SPPromocionAgregarSushi");

                            }

                            Acumulador++;
                        }
                        if (Acumulador == this.ListaSushi.Count)
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
            { //Se crea el objeto de tipo conexion y se le da el parametro de ID el cual servira para identificar el usuario
                //El procedimiento se encarga de cambiar la columna Activo a 0

                Conexion MiCOnexion = new Conexion();


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.PromocionID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPPromocionDesactivar");


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


                MiCOnexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.PromocionID));

                int retorno = MiCOnexion.DMLUpdateDeleteInsert("SPPromocionActivar");


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

        public Promocion Consultar(int PIDPromocion)
        {//Se crea un objeto de tipo Sushi
            //Ademas de que se crea el objeto de tipo conexion y se le da el parametro de ID dado por el usuario
            Promocion r = new Promocion();
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@IDPromocion", PIDPromocion));
            DataTable DatosPromocion = new DataTable();
            DatosPromocion = MiConexion.DMLSelect("SPPromocionConsultar");


            if (DatosPromocion.Rows.Count > 0)
            {
                //Si el procedimiento encontro el usuario consultado
                //Se le asignaran todos los valores al objeto usuario r antes creado y se retorna
                DataRow MiFila = DatosPromocion.Rows[0];
                r.PromocionID = Convert.ToInt32(MiFila["PromocionID"]);
                r.Nombre = Convert.ToString(MiFila["Nombre"]);
                r.Descripcion = Convert.ToString(MiFila["Descripcion"]);
                r.Precio = Convert.ToDecimal(MiFila["Precio"]);
                r.Comentarios = Convert.ToString(MiFila["Comentarios"]);
                r.Activo = Convert.ToBoolean(MiFila["Activo"]);

                Conexion MiCnn = new Conexion();
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDPromocion", PIDPromocion));
                DataTable DatosSushi = new DataTable();
                DatosSushi = MiCnn.DMLSelect("SPConsultarSushiporPromocion");
                if (DatosSushi.Rows.Count > 0)
                {
                    for (int i = 0; i < DatosSushi.Rows.Count; i++)
                    {
                        int IDSushi;
                        Sushi MiSushi = new Sushi();
                        DataRow MiFilaI = DatosSushi.Rows[i];

                        IDSushi = Convert.ToInt32(MiFilaI["SushiID"]);

                        ListaSushi.Add(MiSushi.Consultar(IDSushi));
                    }
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

            r = MiConexion.DMLSelect("SPPromocionListar");
            return r;
        }

        public bool ConsultarPorID()
        {
            //La funcion sirve para saber si ya existe un usuario con el ID del usuario que esta ejecutando la funcion.
            //Si encuentra un usuario con el mismo ID retorna true
            bool R = false;
            Conexion MiConexion = new Conexion();
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@ID", this.PromocionID));
            DataTable retorno = MiConexion.DMLSelect("SPPromocionConsultarID");
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
            r = MiConexion.DMLSelect("AsignarEsquemaPromocionSushi", true);
            return r;
        }

        public DataTable AsignarEsquemaDetalleEliminados()
        {
            //Esta funcion asigna el esquema necesario para los valores de el formulario gestion de sushi
            //Se ejecuta el procedimiento almacenado y devuelve el esquema creado
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();
            r = MiConexion.DMLSelect("AsignarEsquemaPromocionSushiEliminados", true);
            return r;
        }
    }
}
