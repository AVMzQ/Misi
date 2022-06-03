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
    public partial class Venta : Form
    {
        int tipoU,id;
        string nom;
        string sta;
        List<double> Precio = new List<double>();
        List<int> cantidad = new List<int>();
        List<int> Codigo = new List<int>();
        
        enum Estado { Venta };
        Estado estado = Estado.Venta;
        public Venta(int tipo,int Codigo,string nom)
        {
            
            tipoU = tipo;
            id = Codigo;
            this.nom = nom;
            InitializeComponent();
        }


        private void panelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tipoU == 1||tipoU==2)
            {
                PanelControl pc = new PanelControl(tipoU,id,nom);
                pc.Show();
            }
            else
                MessageBox.Show("No tienes premiso");
        }

        private void CerrarSecion_Click(object sender, EventArgs e)
        {
            Inicio i = new Inicio();
            this.Close();
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {

            if (tipoU == 1)
            {
                sta = "Administrador";
            }
            else if (tipoU == 2)
            {
                sta = "Gerente";
            }
            else if (tipoU == 3)
            {
                sta = "Empleado";
            }
            lblNombre.Text = nom;
            lblTipoEmp.Text = sta;
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
        //----------------------------------------------------------------------------------------------------
        int cont1;
        double total = 0;
        private void btnTotal_Click(object sender, EventArgs e)
        {
            double[] multi = new double[Precio.Count];
            lstVista.ClearSelected();
            try
            {
                if (estado == Estado.Venta)
                {
                    for (int i = 0; i < Precio.Count; i++)
                    {
                        multi[i] = Precio[i] * cantidad[i];
                        Precio[i] = multi[i];
                        total += multi[i];
                    }

                    lstVista.Items.Add("Total a pagar: " + total);
                    lblTotal.Text = "" + total;
                   
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x);

            }
        }
        double cambio = 0;
        int b = 0, a = 0;
        private void btnPago_Click(object sender, EventArgs e)
        {

            SqlConnection con = Conexion.cadena();
            if (con != null)
            {
                double efectivo = Convert.ToDouble(txtEfectivo.Text);
                cambio = efectivo - total;
                if (cambio < 0)
                {
                    cambio = -1 * cambio;
                    lstVista.Items.Add("Pago: " + txtEfectivo.Text + "  falta: " + cambio);
                    lblCambio.Text = "" + cambio;
                    total = cambio;
                    cambio = 0;
                }
                else
                {
                    SqlTransaction tran = null;
                    //Consultas y Fechas
                    DateTime f = DateTime.Now;
                    string fecha = f.ToString("yyyy/MM/dd");
                    string fecha2 = f.ToString("yyyy/MM/dd HH:mm:ss");
                   
                    int idVen = 0;

                    lstVista.Items.Add("Pago: " + txtEfectivo.Text + "  Cambio: " + cambio);
                    lblCambio.Text = "" + cambio;
                    tran = con.BeginTransaction();

                    //Insertar datos de Tabla venta
                    string Venta = "insert into Venta (Fecha,idEmpleado,MontoAcumulado) values(@Fecha,@idEmp,@MontoAcum)";
                    bool TodoBien = true;
                    try
                    {
                        using (SqlCommand V = new SqlCommand(Venta, con, tran))
                        {
                            V.Parameters.AddWithValue("@Fecha", fecha2);
                            V.Parameters.AddWithValue("@idEmp", id);
                            V.Parameters.AddWithValue("@MontoAcum", total);
                            V.ExecuteNonQuery();

                            SqlCommand cmd = new SqlCommand("select Codigo from Venta where Fecha='" + fecha2 + "'", con, tran);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                idVen = Convert.ToInt32(dr["Codigo"]);

                            }
                            dr.Close();
                        }
                    }
                    catch (Exception)
                    {
                        TodoBien = false;
                    }
                    finally
                    {
                        if (TodoBien)
                        {
                            tran.Commit();
                            MessageBox.Show("Todo chido en venta");
                        }
                        else
                        {
                            tran.Rollback();

                        }
                    }
                    if (idVen != 0)
                    {
                        SqlTransaction transaction = null;

                        int b = 0, a = 0;

                        do
                        {
                            string ConsulDetalleV = "insert into DetalleVenta values (@idMed,@idVen,@Cantidad,@Fecha,@Precio)";
                            SqlCommand Detalle = new SqlCommand(ConsulDetalleV, con, transaction);
                            for (int i = a; i < Codigo.Count; i++)
                            {

                                Detalle.Parameters.Clear();
                                Detalle.Parameters.AddWithValue("@idMed", Codigo[i]);
                                Detalle.Parameters.AddWithValue("@idVen", idVen);
                                Detalle.Parameters.AddWithValue("@Cantidad", cantidad[i]);
                                Detalle.Parameters.AddWithValue("@Fecha", fecha);
                                Detalle.Parameters.AddWithValue("@precio", Precio[i]);
                                Detalle.ExecuteNonQuery();

                                a++;
                                break;
                            }
                            b++;
                        } while (b < Codigo.Count);


                        con.Close();
                    }
                }
            }
            cambio = 0;
            total = 0;
            cont1 = 0;
            Precio.Clear();
            cantidad.Clear();
            Codigo.Clear();
            lstVista.ClearSelected();



        }
        double revicion;
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection con = Conexion.cadena();
                if (con != null)
                {
                    if (estado == Estado.Venta)
                    {
                        SqlCommand cmd = new SqlCommand("select CodigoMed from Inventario where CodigoMed=" + txtCodigo.Text, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            int d = dr.GetInt32(0);
                            dr.Close();
                            if (cont1 == 0)
                            {
                                lstVista.Items.Add("Codigo       Articulo           cantidad     precio por pieza");
                                cont1++;
                            }

                            Codigo.Add(Convert.ToInt32(txtCodigo.Text));
                            cmd = new SqlCommand("select Precio,Nombre from Inventario where CodigoMed=" + txtCodigo.Text, con);
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {

                                lstVista.Items.Add(txtCodigo.Text + "     " + dr["Nombre"].ToString() + "   " + txtCantidad.Text + "  " + dr["Precio"].ToString());
                                revicion = Convert.ToDouble(dr["Precio"].ToString());

                                if (revicion != 0)
                                {
                                    Precio.Add(revicion);
                                    cantidad.Add(Convert.ToInt32(txtCantidad.Text));
                                }
                            }
                            dr.Close();
                            double[] multi = new double[Precio.Count];
                            double total = 0;
                            for (int i = 0; i < Precio.Count; i++)
                            {
                                multi[i] = Precio[i] * cantidad[i];
                                total += multi[i];
                            }
                            lblTotal.Text = "" + total;
                        }
                        else
                            MessageBox.Show("El id que quieres ingresar es incorrecto o \nno existe");
                    }
                }     
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x);

            }
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstVista.Items.Clear();
            lstProd.Items.Clear();
            Precio.Clear();
            total = 0;
           
            cantidad.Clear();
            Codigo.Clear();
            txtCantidad.Text = "";
            txtCodigo.Text = "";
            txtEfectivo.Text = "";
            
        }
        private void Venta_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult r = MessageBox.Show("Estas apunto de cerrar la aplicacion\nEstas seguro de esto?\nsi escoges que no, saldras a la pantalla de logueo", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            string f = r.ToString();
            if (f == "Yes")
            {
                Application.Exit();
            }
            else if(f=="No")
            {
                SqlConnection con = Conexion.cadena();
                con.Close();
                Inicio i = new Inicio();
                i.Show();
            }
        }
        //============================================================================================
        List<int> CodProv = new List<int>();
        List<int> CodProd = new List<int>();

        List<string> med = new List<string>();
        List<int> canti= new List<int>();
        List<double> PrecioE = new List<double>();
        List<string> FechaCad = new List<string>();
        
        int Indice = 0;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int condprod = 0;
                if (txtCodProdu.Text == "")
                {
                    CodProd.Add(Convert.ToInt32(condprod));
                    
                }
                else
                    CodProd.Add(Convert.ToInt32(txtCodProdu.Text));
                CodProv.Add(Convert.ToInt32(txtCodProv.Text));

                med.Add(txtNombre.Text);
                PrecioE.Add(Convert.ToDouble(txtPrecio.Text));
                canti.Add(Convert.ToInt32(txtCantidadEntrega.Text));
                FechaCad.Add(txtFechaCad.Text);

                lstProd.Items.Add(txtCodProdu.Text + "        " + txtNombre.Text + "                " + txtCantidadEntrega.Text);
            }
            catch (Exception x)
            {
                MessageBox.Show("" + x);
            }
        }

        private void lstProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProd.SelectedIndex!=-1)
            {
                Indice = lstProd.SelectedIndex;
            }
        }
        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.cadena();
            try
            {
                DialogResult r = MessageBox.Show("Estas a punto de eliminar del registro a:\n" +
                    "codigo: " + CodProd[Indice - 1] + " Nombre:" + med[Indice - 1], "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                string f = r.ToString();
                if (f == "Yes")
                {
                    lstProd.Items.RemoveAt(Indice);
                    CodProv.RemoveAt(Indice - 1);
                    CodProd.RemoveAt(Indice - 1);
                    med.RemoveAt(Indice - 1);
                    canti.RemoveAt(Indice - 1);
                    PrecioE.RemoveAt(Indice - 1);
                }
            }
            catch (Exception x)
            {

                MessageBox.Show("" + x);
            }
            
            
            
        }
        public int idEntrega = 0;
        //Tienes que editar este codigo
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            //try
            //{
            
            SqlConnection con = Conexion.cadena();
            
            if (con != null)
            {
                string fechaE = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                int a = 0; b = 0;
                SqlTransaction transaction = null;
                do
                {
                   
                    
                    SqlCommand cmd = new SqlCommand("insert into Entrega values (@CodigoProv,@CodigoPed,@med,@Can,@F_E,@idEmp,@idmed,@precio,@F_C)", con,transaction);
                    for (int i = a; i < med.Count; i++)
                    {

                        cmd.Parameters.AddWithValue("@CodigoProv", CodProv[i]);
                        cmd.Parameters.AddWithValue("@CodigoPed", txtCodPed.Text);

                        cmd.Parameters.AddWithValue("@med", med[i]);
                        cmd.Parameters.AddWithValue("@can", canti[i]);
                        cmd.Parameters.AddWithValue("@F_E", fechaE);
                        cmd.Parameters.AddWithValue("@IdEmp", idEntrega);
                        if (CodProd[i] != 0)
                        {
                            cmd.Parameters.AddWithValue("@idmed", CodProd[i]);
                        }
                        else
                            cmd.Parameters.AddWithValue("@idmed", DBNull.Value);
                        cmd.Parameters.AddWithValue("@precio", PrecioE[i]);
                        cmd.Parameters.AddWithValue("@F_C", FechaCad[i]);

                        cmd.ExecuteNonQuery();
                        a++;
                        break;
                    }
                    b++;
                } while (b < med.Count);

                con.Close();

                CodProv.Clear();
                CodProd.Clear();
                med.Clear();
                canti.Clear();
                PrecioE.Clear();
                FechaCad.Clear();

                lstProd.Items.Clear();
                lstProd.Items.Add("ID =|=Nombre=======|=Cantidad");
                txtCodPed.Text = null;
                txtCodProv.Text = null;
                txtCodProdu.Text = null;
                txtCantidadEntrega.Text = null;
            }
            //}
            //catch (Exception x)
            //{
            //    MessageBox.Show("" + x);
            //}
            
            
        }

        //=======================Entrega de producto======================================================
        
        private void recibirMedicamentoVacunasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstProd.Items.Add("ID =|=Nombre=======|=Cantidad");
            PanelContra.Show();
            PanelContra.BringToFront();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.cadena();
            try
            {
                if (con != null)
                {
                    using (SqlCommand cmd = new SqlCommand("spLogueo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Descriptar la contrasena y compararla con la contrasena tecleada en el textBox
                        //si las dos coiciden entra a spLogueo
                        cmd.Parameters.AddWithValue("@codigo", txtCodigoU.Text);

                        cmd.Parameters.AddWithValue("@Contra", txtContra.Text);

                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = null;
                        cmd.Parameters["@Nombre"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = 0;
                        cmd.Parameters["@tipo"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = 0;
                        cmd.Parameters["@Status"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool status = bool.Parse(cmd.Parameters["@Status"].Value.ToString());
                        int TipoU = int.Parse(cmd.Parameters["@tipo"].Value.ToString());
                        string Nombre = cmd.Parameters["@Nombre"].Value.ToString();

                        int CodigoUs = Convert.ToInt32(txtCodigoU.Text);
                        if (status && TipoU == 1)
                        {

                            DialogResult result = MessageBox.Show("Acceso autorizado", "Estado", MessageBoxButtons.OK, MessageBoxIcon.None);

                            if (result == DialogResult.OK)
                            {
                                idEntrega =int.Parse(txtCodigoU.Text);
                                PanelEntregaProd.Show();
                                PanelEntregaProd.BringToFront();
                            }
                        }
                        else if (status && TipoU == 2)
                        {
                            DialogResult result = MessageBox.Show("Acceso autorizado", "Estado", MessageBoxButtons.OK, MessageBoxIcon.None);
                            if (result == DialogResult.OK)
                            {
                                idEntrega = int.Parse(txtCodigoU.Text);
                                PanelEntregaProd.Show();
                                PanelEntregaProd.BringToFront();
                            }
                        }
                        else if (status && TipoU > 2)
                        {
                            DialogResult result = MessageBox.Show("Acceso Denegado", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (result == DialogResult.OK)
                            {
                                PanelContra.Hide();
                                PanelEntregaProd.Hide();
                            }
                        }
                    } 
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("" + x);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelContra.Hide();
            PanelEntregaProd.Hide();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            PanelContra.Hide();
            PanelEntregaProd.Hide();

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelContra.Hide();
            PanelEntregaProd.Hide();
        }

        private void realizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Realizar pedido
        }



        //----------------------------------------------------------------------------------------------------
        private void Venta_Load(object sender, EventArgs e)
        {
            PanelContra.Hide();
            PanelEntregaProd.Hide();
        }
    }
}
