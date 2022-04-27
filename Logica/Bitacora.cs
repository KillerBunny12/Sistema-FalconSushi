using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Bitacora
    {




        public DataTable ListarBitacora(bool UltimoMes)
        {
            //Se crea el objeto de conexion y se le dan los parametros dados por el usuario los cuales sirven para decir
            //Si se veran las bitacoras del ultimo mes o de todo el sistema
            //Se crea un datatable con las bitacoras y se retornan al usuario
            DataTable r = new DataTable();
            Conexion MiConexion = new Conexion();

            if (UltimoMes == true)
            {
                r = MiConexion.DMLSelect("SPListarBitacoraMes");
            }
            else
            {
                r = MiConexion.DMLSelect("SPListarBitacora");
            }

            return r;
        }
    }
}
