using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Entidades
{
    public static class PaqueteDAO
    {
         static SqlCommand comando;
         static SqlConnection connection;

        static PaqueteDAO()
        {
           
        }

        public bool Insertar(Paquete p)
        {
            return true;
        }

    }
}
