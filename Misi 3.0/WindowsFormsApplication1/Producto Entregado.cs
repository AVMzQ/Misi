using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    public partial class Producto_Entregado : Form
    {
        public Producto_Entregado()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Producto_Entregado_Load(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.cadena();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand("select * from Entrega", con);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                DataTable tb = new DataTable();
                adp.Fill(tb);
                dataGridView1.DataSource = tb;
            }
        }
    }
}
