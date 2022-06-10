using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Guia_Tramites_Api.Entities
{
    public class DALBase
    {
        public static SqlConnection getConnection()
        {
            try
            {
                return new SqlConnection("Data Source=srv-sql;Initial Catalog=GUIA_TRAMITES;User ID=general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
