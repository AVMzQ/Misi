using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class Conexion
    {

        public static SqlConnection cadena()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Misi;Integrated Security=True");
            try
            {
                con.Open();
                return con;
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}
