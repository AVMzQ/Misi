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
    public partial class BitacoraVenta : Form
    {
        public BitacoraVenta()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BitacoraVenta_Load(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.cadena();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand("select * from Venta", con);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                DataTable tb = new DataTable();
                adp.Fill(tb);
                dgvVenta.DataSource = tb;

                SqlCommand cmd1 = new SqlCommand("select * from DetalleVenta", con);
                SqlDataAdapter adp1 = new SqlDataAdapter();
                adp1.SelectCommand = cmd1;
                DataTable tb1 = new DataTable();
                adp.Fill(tb1);
                dgvDetalleVenta.DataSource = tb1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteExcel re = new ReporteExcel(DateTime.Now.ToString("yyyy/MM/dd"), dgvVenta);

        }
    }
}
