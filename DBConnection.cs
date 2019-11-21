using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NetProject01
{
    sealed class DBConnection
    {
        private DBConnection() { }
        private static volatile SqlConnection instance;
        public static SqlConnection BD_connection
        {
            get{
                if (instance == null)
                {
                    instance = new SqlConnection(ConfigurationManager.ConnectionStrings["CS_ADO_NET"].ConnectionString);
                }
            }
        }
    }
}
