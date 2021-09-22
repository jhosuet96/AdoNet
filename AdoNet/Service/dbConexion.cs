using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdoNet.Service
{
    public class dbConexion
    {
        protected SqlConnection con;
        protected SqlCommand comando;
        protected SqlDataAdapter adapter;
        protected SqlDataReader reader;
        protected DataSet ds;
        protected DataTable dt;
        protected string dbconexion;


       // protected string procedure;

       public dbConexion()
        {
            this.dbconexion = ConfigurationManager.ConnectionStrings["LPII"].ConnectionString;
            this.con = new SqlConnection(dbconexion);
        }


    }
}
