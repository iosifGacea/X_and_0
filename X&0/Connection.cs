using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Connection
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["nume"].ConnectionString;

        public static SqlConnection Con
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        //public static InternetConnection...
    }
}
