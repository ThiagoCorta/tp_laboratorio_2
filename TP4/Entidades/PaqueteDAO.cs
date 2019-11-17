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
    /// <summary>
    /// Declaro el delegado para comunicar el form con la clase paqueteDao
    /// </summary>
    /// <param name="message"></param>
    public delegate void DelegateSqlError(string message);
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection connection;
        public static event DelegateSqlError errorSql;

        /// <summary>
        /// Setea los valores por defecto para conectarse a la base de datos.
        /// </summary>
        static PaqueteDAO()
        {
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
            connectionString.DataSource = ".\\SQLEXPRESS";
            connectionString.InitialCatalog = "correo-sp-2017";
            connectionString.IntegratedSecurity = true;
            connection = new SqlConnection(connectionString.ToString());
            comando = new SqlCommand();
            comando.Connection = connection;
            comando.CommandType = System.Data.CommandType.Text;
        }


        /// <summary>
        /// Inicia la coneccion con la base de datos y guarda la informacion del paquete que se envia como parametro
        /// </summary>
        /// <param name="p">Paquete que se guarda en la base de datos</param>
        /// <returns>true si el numero de filas afectadas es > 0 false si no pudo afectar ninguna fila</returns>
        public static bool Insertar(Paquete p)
        {
            bool isOk = false;
            if (p is null) return isOk;
            comando.CommandText = String.Format($"INSERT INTO dbo.Paquetes(direccionEntrega, trackingID, alumno) VALUES('{p.DireccionEntrega}', '{p.TrackingID}', 'Thiago Tomas Corta')");
            try
            {
                connection.Open();
                isOk = comando.ExecuteNonQuery() != 0 ? true : false;
            }
            catch (Exception e)
            {
                errorSql.Invoke(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return isOk;
        }
    }
}
