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
using System.Data.SqlTypes;

namespace WindowsFormsApplication1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.cadena();
            string mensage;
            string caption;
            int TipoU;
            MessageBoxButtons buttons;
            DialogResult result;
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand("spLogueo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //Descriptar la contrasena y compararla con la contrasena tecleada en el textBox
                //si las dos coiciden entra a spLogueo
                cmd.Parameters.AddWithValue("@codigo",txtCodigo.Text);

                cmd.Parameters.AddWithValue("@Contra", txtContra.Text);

                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = null;
                cmd.Parameters["@Nombre"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = 0;
                cmd.Parameters["@tipo"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = 0;
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();


                bool status = bool.Parse(cmd.Parameters["@Status"].Value.ToString());
                TipoU = int.Parse(cmd.Parameters["@tipo"].Value.ToString());
                string Nombre = cmd.Parameters["@Nombre"].Value.ToString();

                int CodigoUs = Convert.ToInt32(txtCodigo.Text);
                if (status && TipoU == 1)
                {
                    mensage = ("Bienvenido " + Nombre + Environment.NewLine + "Jefe \nCodigo: " + CodigoUs);
                    caption = "Datos Validos";
                    buttons = MessageBoxButtons.OK;
                    result = MessageBox.Show(mensage, caption, buttons);

                    if (result == DialogResult.OK)
                    {
                        Venta v = new Venta(TipoU, CodigoUs, Nombre);
                        v.Show();
                        this.Hide();
                    }
                }
                else if (status && TipoU == 2)
                {
                    mensage = ("Bienvenido " + Nombre + Environment.NewLine + "Gerente \nCodigo: " + CodigoUs);
                    caption = "Datos Validos";
                    buttons = MessageBoxButtons.OK;
                    result = MessageBox.Show(mensage, caption, buttons);

                    if (result == DialogResult.OK)
                    {
                        Venta v = new Venta(TipoU, CodigoUs, Nombre);
                        v.Show();
                        this.Hide();
                    }

                }
                else if (status && TipoU == 3)
                {
                    mensage = ("Bienvenido " + Nombre + Environment.NewLine + "Empleado \nCodigo: " + CodigoUs);
                    caption = "Datos Validos";
                    buttons = MessageBoxButtons.OK;
                    result = MessageBox.Show(mensage, caption, buttons);

                    if (result == DialogResult.OK)
                    {
                        Venta v = new Venta(TipoU, CodigoUs, Nombre);
                        v.Show();
                        this.Hide();
                    }
                }
                else
                    MessageBox.Show("Usuario o contraseña incorrectos \nPrueba de nuevo");


            }
            else
                MessageBox.Show("Error de conexion. \n Intentalo de nuevo");


        }

        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
