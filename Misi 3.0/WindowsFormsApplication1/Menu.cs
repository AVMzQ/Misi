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
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class PanelControl : Form
    {
        int tipo, id; string sta,nom;
        public PanelControl(int tipo,int id,string nom)
        {
            this.tipo = tipo;
            this.id = id;
            this.nom = nom;
            InitializeComponent();
        }

        private void btnABC_Click(object sender, EventArgs e)
        {
            if (tipo==1|| tipo==2)
            {
                string c = null;
                ABC abc = new ABC(tipo, id);
                abc.Show();
            }
            else
                MessageBox.Show("No tienes permisos");


        }

        private void btnBitaEmpl_Click(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
                BitacoraEmpleado BE = new BitacoraEmpleado();
                BE.Show();
            }
            else
                MessageBox.Show("No tienes permisos");
        }

        private void btnRegVentas_Click(object sender, EventArgs e)
        {
            if (tipo==1)
            {
                BitacoraVenta BV = new BitacoraVenta();
                BV.Show();
            }
            else
                MessageBox.Show("No tienes permisos");

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        

        private void PanelControl_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
                sta = "Jefe";
            }
            else if (tipo == 2)
            {
                sta = "Gerente";
            }
            else if (tipo == 3)
            {
                sta = "Empleado";
            }
            lblNombre.Text = nom;
            lblStatus.Text = sta;
            lblCodigo.Text = id.ToString();
            panelDefaul.BringToFront();
            PanelPedido.SendToBack();

            SqlConnection con = Conexion.cadena();
            SqlCommand cmd = new SqlCommand("select  Foto from Empleado where Codigo=" + id, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //MessageBox.Show("" + dr["Foto"].ToString());
                if (dr["Foto"].ToString() == "")
                {

                }
                else
                    PcbFoto.Image = Image.FromFile(Application.StartupPath + "\\Usuario" + dr.GetString(0));
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tipo==1||tipo==2)
            {
                proveedores pro = new proveedores();
                pro.Show();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tipo==1|| tipo==2)
            {
                CompraProveedores cp = new CompraProveedores();
                cp.Show();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tipo==1 || tipo==2)
            {
                Producto_Entregado pe = new Producto_Entregado();
                pe.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tipo==1)
            {
                PanelPedido.BringToFront();
                panelDefaul.SendToBack();
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            int a = 0, b = 0;
            SqlConnection con = Conexion.cadena();
            try
            {
                if (con != null)
                {
                    string f = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                   
                    using (SqlCommand cmd = new SqlCommand("insert into Pedido (CodigoProv,CodigoEmp,Medicamentos,TotalMedicamentos,MontoTotal,Fecha)" +
                        " values (@CodProv,@CodEmp,@med,@TotalMed,@MontoTotal,@Fecha)", con))
                    {
                        b++;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@CodProv", txtCodProv.Text);
                        cmd.Parameters.AddWithValue("@CodEmp", id);
                        cmd.Parameters.AddWithValue("@med", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@TotalMed", txtTotalMed.Text);
                        cmd.Parameters.AddWithValue("@MontoTotal", txtMontoTotal.Text);
                        cmd.Parameters.AddWithValue("@Fecha", f);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                else
                    MessageBox.Show("Error de conexion!", "Error");
                a += b;
              
            }
            catch (Exception x)
            {
                MessageBox.Show("" + x);
            }

            panelDefaul.BringToFront();
            PanelPedido.SendToBack();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (tipo==1||tipo==2)
            {
                Inventario inve = new Inventario();
                inve.Show();
            }
        }
        private void FechaHora_Tick(object sender, EventArgs e)
        {
            
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
