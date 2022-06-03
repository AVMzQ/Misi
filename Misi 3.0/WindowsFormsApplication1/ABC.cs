using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    enum Opciones {Alta,Baja,Cambio,Neutral,Enc}
   
    public partial class ABC : Form
    {
        Opciones es = Opciones.Neutral;
        int tipo, id; string ruta,path;
        public ABC(int tipo,int id)
        {
            this.tipo = tipo;
            this.id = id;
            InitializeComponent();
        }

        private void ABC_Load(object sender, EventArgs e)
        {
            //Te envie el tipo de usuario y id por parametros
            
        }
        int cont = 0;
        //==========================================
     
        //tablas
        private void TablaEmp()
        {
            SqlConnection con = Conexion.cadena();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand("select * from Empleado", con);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                DataTable tb = new DataTable();
                adp.Fill(tb);
                dgvEmp.DataSource = tb;
            }
        }
        private void TablaEProd()
        {
            SqlConnection con = Conexion.cadena();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand("select * from Inventario", con);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                DataTable tbas = new DataTable();
                adp.Fill(tbas);
                dgvProd.DataSource = tbas;
            }
        }
        private void TablaProv()
        {
            SqlConnection con = Conexion.cadena();

            if (con!= null)
            {
                SqlCommand cmd = new SqlCommand("select * from Proveedores", con);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                DataTable tb = new DataTable();
                adp.Fill(tb);
                dgvprov.DataSource = tb;
            }
        }
        //ACCIONES
       
        private void btnAlta_Click(object sender, EventArgs e)
		{
            
            try
            {
                SqlConnection con = Conexion.cadena();

                if (con != null)
                {

                    //Altas
                    if (rdbEmpleados.Checked == true && es == Opciones.Alta)
                    {
                        cont = 0;
                        SqlCommand com = new SqlCommand();
                        com.Connection = con;
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandText = "spEmpIU";
                        com.Parameters.Clear();
                        char Sexo = 'H';

                        ruta = Application.StartupPath + ("\\Usuario\\") + txtNomEmp.Text + "_" + txtIDEMP.Text + ".jpg";
                        path = Path.GetFileName(ruta);
                        if (rdbHombre.Checked == true)
                        {
                            Sexo = 'H';

                        }
                        else
                        {
                            if (rdbMujer.Checked == true)
                            {
                                Sexo = 'M';
                            }
                            else
                            {
                                MessageBox.Show("Sexo no definido");
                            }
                        }

                        com.Parameters.Add("@idResponsable", SqlDbType.Int).Value = id;
                        com.Parameters.Add("@codigo", SqlDbType.Int).Value = DBNull.Value;
                        com.Parameters.Add("@Nombre", SqlDbType.Char, 100).Value = txtNomEmp.Text;
                        com.Parameters.Add("@Ap", SqlDbType.Char, 100).Value = txtApPatEmp.Text;
                        com.Parameters.Add("@Am", SqlDbType.Char, 100).Value = txtApMaEmp.Text;
                        com.Parameters.Add("@Edad", SqlDbType.Int).Value = int.Parse(txtEdad.Text);
                        com.Parameters.Add("@sexo", SqlDbType.Char, 1).Value = Sexo;
                        com.Parameters.Add("@Telefono", SqlDbType.Char, 10).Value = txtTelefono.Text;
                        com.Parameters.Add("@Direccion", SqlDbType.Char, 100).Value = txtDireccion.Text;
                        com.Parameters.Add("@Estado", SqlDbType.Char, 100).Value = txtEstado.Text;
                        com.Parameters.Add("@Ciudad", SqlDbType.Char, 100).Value = txtCiudad.Text;
                        com.Parameters.Add("@RFC", SqlDbType.Char, 13).Value = txtRFCEmp.Text;
                        com.Parameters.Add("@motivo", SqlDbType.Char, 250).Value = txtMotivo.Text;
                        com.Parameters.Add("@tipo", SqlDbType.Int).Value = int.Parse(txtTipo.Text);
                        com.Parameters.Add("@foto", SqlDbType.Text).Value = "\\" + path;
                        com.Parameters.Add("@Contra", SqlDbType.Char, 20).Value = txtContra.Text;
                        com.Parameters.Add("@Opcion", SqlDbType.Int).Value = 1;
                        com.Parameters.Add("@Resul", SqlDbType.Int).Value = 1;


                        DialogResult r = MessageBox.Show("Estan correctos los datos? ", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        string f = r.ToString();
                        if (f == "OK")
                        {
                            int a = com.ExecuteNonQuery();
                            if (a > 0)
                            {
                                MessageBox.Show("Listo! \nEmpleado Dado de alta", "Exito!");
                                TablaEmp();
                            }
                            else
                                MessageBox.Show("Error: Ocurrio un problema inesperado \n Intentelo de nuevo");
                        }



                    }
                    if (rdbProductos.Checked==true && es == Opciones.Alta)
                    {
                        cont = 0;

                        SqlCommand cmd = new SqlCommand("SP_Cambia_Producto_Inventario", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Accion", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@idProd", SqlDbType.Int).Value = DBNull.Value;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = txtNombre.Text;
                        cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = int.Parse(txtCan.Text);
                        cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = int.Parse(txtprecio.Text);
                        cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = int.Parse(txtEstado_Producto.Text);
                        cmd.Parameters.Add("@Fecha_Cad", SqlDbType.Date).Value = txtFepro.Text;
                        DialogResult r = MessageBox.Show("Estan correctos los datos? ", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        string f = r.ToString();
                        if (f == "OK")
                        {
                            int a = cmd.ExecuteNonQuery();
                            if (a > 0)
                            {
                                MessageBox.Show("Producto dado de alta con exito!");
                                TablaEProd();
                            }
                            else
                                MessageBox.Show("Error: Ocurrio un problema inesperado \n Intentelo de nuevo");
                        }
                        else
                            MessageBox.Show("Producto no dado de alta");


                    }
                    if (rdbProvee.Checked==true && es == Opciones.Alta)
                    {
                        cont = 0;
                        SqlCommand cmd = new SqlCommand("spACProv", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = DBNull.Value;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = txtNomProv.Text;
                        cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = txtNomProv.Text;
                        cmd.Parameters.Add("@Tel", SqlDbType.VarChar, 10).Value = txtTelProv.Text;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 200).Value = txtCorreoProv.Text;
                        cmd.Parameters.Add("@Accion", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@Res", SqlDbType.Int).Value = 1;


                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Proveedor dado de alta con exito!");
                            TablaProv();
                        }
                        else
                            MessageBox.Show("Error: Ocurrio un problema inesperado \n Intentelo de nuevo");

                    }
					//Bajas
					if (rdbEmpleados.Checked == true && es == Opciones.Baja)
					{
                        string Codigo = "delete from Empleado Where Codigo=@Codigo insert into Bitacora values (@ID, " + "'Borro a un empleado', 'En la base de datos', @Motivo," + " GETDATE())";
                        SqlCommand cmd = new SqlCommand(Codigo, con);

                        cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = int.Parse(txtIDEMP.Text);
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@Motivo", SqlDbType.VarChar, 250).Value = txtMotivo.Text;


                        cont = 0;
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Empleado dado de baja con exito");
                            TablaEmp();
                        }
                        else
                        {
                            MessageBox.Show("Error: Ocurrio un problema inesperado \n Intentelo de nuevo");
                        }


                    }
                    if (rdbProductos.Checked == true && es == Opciones.Baja)
                    {
                        cont = 0;
                        string Codigo = "delete from Inventario Where CodigoMed=@Codigo insert into Bitacora values (@ID, " + "'Borro un producto', 'En la base de datos', @Motivo," + " GETDATE())";
                        SqlCommand cmd = new SqlCommand(Codigo, con);

                        cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = int.Parse(txtidprod.Text);
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@Motivo", SqlDbType.VarChar, 250).Value = txtMotivo.Text;
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Producto dado de baja con exito");
                            TablaEProd();
                        }
                        else
                            MessageBox.Show("Error: Ocurrio un problema inesperado \n Intentelo de nuevo");
                    }
                    if (rdbProvee.Checked == true && es == Opciones.Baja)
                    {
                        cont = 0;
                        string Codigo = "delete from Proveedores Where Codigo=@Codigo insert into Bitacora values (@ID, " + "'Borro un proveedor', 'En la base de datos', @Motivo," + " GETDATE())";
                        SqlCommand cmd = new SqlCommand(Codigo, con);

                        cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = int.Parse(txtIDprov.Text);
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@Motivo", SqlDbType.VarChar, 250).Value = txtMotivo.Text;

                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Proveedor dado de baja con exito");
                            TablaProv();

                        }
                        else
                            MessageBox.Show("Error: Ocurrio un problema inesperado \n Intentelo de nuevo");
                    }
                    //Cambios
                    if (rdbEmpleados.Checked == true && es == Opciones.Cambio)
                    {

                        cont = 0;
                        SqlCommand cmd = new SqlCommand("spEmpIU", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        ruta = Application.StartupPath + ("\\Usuario\\") + txtNomEmp.Text + "_" + txtIDEMP.Text + ".jpg";
                        path = Path.GetFileName(ruta);

                        char Sexo = 'H';


                        if (rdbHombre.Checked == true)
                        {
                            Sexo = 'H';

                        }
                        else
                        {
                            if (rdbMujer.Checked == true)
                            {
                                Sexo = 'M';
                            }
                            else
                            {
                                MessageBox.Show("Sexo no definido");
                            }
                        }

                        cmd.Parameters.Add("@idResponsable", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@codigo", SqlDbType.Int).Value = int.Parse(txtIDEMP.Text);
                        cmd.Parameters.Add("@Nombre", SqlDbType.Char, 100).Value = txtNomEmp.Text;
                        cmd.Parameters.Add("@Ap", SqlDbType.Char, 100).Value = txtApPatEmp.Text;
                        cmd.Parameters.Add("@Am", SqlDbType.Char, 100).Value = txtApMaEmp.Text;
                        cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = int.Parse(txtEdad.Text);
                        cmd.Parameters.Add("@sexo", SqlDbType.Char, 1).Value = Sexo;
                        cmd.Parameters.Add("@Telefono", SqlDbType.Char, 10).Value = txtTelefono.Text;
                        cmd.Parameters.Add("@Direccion", SqlDbType.Char, 100).Value = txtDireccion.Text;
                        cmd.Parameters.Add("@Estado", SqlDbType.Char, 100).Value = txtEstado.Text;
                        cmd.Parameters.Add("@Ciudad", SqlDbType.Char, 100).Value = txtCiudad.Text;
                        cmd.Parameters.Add("@RFC", SqlDbType.Char, 13).Value = txtRFCEmp.Text;
                        cmd.Parameters.Add("@motivo", SqlDbType.Char, 250).Value = txtMotivo.Text;
                        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = int.Parse(txtTipo.Text);
                        cmd.Parameters.Add("@foto", SqlDbType.Text).Value = "\\" + path;
                        cmd.Parameters.Add("@Contra", SqlDbType.Char, 20).Value = txtContra.Text;
                        cmd.Parameters.Add("@Opcion", SqlDbType.Int).Value = 2;
                        cmd.Parameters.Add("@Resul", SqlDbType.Int).Value = 1;

                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("se realizaron los cambios con exito");
                            TablaEmp();
                        }
                        else
                        {
                            MessageBox.Show("Error: Ocurrio un problema inesperado \n Intentelo de nuevo");
                        }
                    }
                    if (rdbProductos.Checked == true && es == Opciones.Cambio)
                    {
                        cont = 0;

                        SqlCommand cmd = new SqlCommand("SP_Cambia_Producto_Inventario", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Accion", SqlDbType.Int).Value = 2;
                        cmd.Parameters.Add("@idProd", SqlDbType.Int).Value = int.Parse(txtidprod.Text);
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = txtNombre.Text;
                        cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = int.Parse(txtCan.Text);
                        cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = txtprecio.Text;
                        cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = int.Parse(txtEstado_Producto.Text);
                        cmd.Parameters.Add("@Fecha_Cad", SqlDbType.Date).Value = Convert.ToDateTime(txtFepro.Text);
                        DialogResult r = MessageBox.Show("Estan correctos los datos? ", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        string f = r.ToString();
                        if (f == "OK")
                        {
                            int a = cmd.ExecuteNonQuery();
                            if (a > 0)
                            {
                                MessageBox.Show("Listo! \nProducto actualizado");
                                TablaEProd();
                            }
                            else
                                MessageBox.Show("Error: Ocurrio un problema inesperado \n Intentelo de nuevo");
                        }
                        else
                            MessageBox.Show("El producto no se actualizo");
                    }
                    if (rdbProvee.Checked == true && es == Opciones.Cambio)
                    {
                        cont = 0;
                        SqlCommand cmd = new SqlCommand("spACProv", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = txtIDprov.Text;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = txtNomProv.Text;
                        cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = txtDesProvee.Text;
                        cmd.Parameters.Add("@Tel", SqlDbType.VarChar, 10).Value = txtTelProv.Text;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 200).Value = txtCorreoProv.Text;
                        cmd.Parameters.Add("@Accion", SqlDbType.Int).Value = 2;
                        cmd.Parameters.Add("@Res", SqlDbType.Int).Value = 1;

                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("se realizaron los cambios con exito");

                            TablaProv();

                        }
                        else
                            MessageBox.Show("Error: Ocurrio un problema inesperado \n Intentelo de nuevo");
                    }
                    
                }
                else
                    MessageBox.Show("Error de conexion. \n Vuelve a intentarlo mas tarde");
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x);
            }
		}
        //=======================================================================================
        
        //==========================================================================
        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        //MOSTRAR
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            panelProtector.Visible = true;
            panelProc2.Visible = true;
            panelProc2.BringToFront();
            panelProtector.BringToFront();
            panelMotivo.Visible = false;
        }

        //RADIO BUTTON

        private void rdbProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbProductos.Checked == true)
            {

                this.Refresh();
                TablaEProd();
                //panel
                panelProtector.Visible = false;
                PanelFoto.Visible = false;
                panelProductos.Visible = true;
                panelProductos.BringToFront();
               
                PanelEmpleado.Visible = false;
                //tabla
                panelProc2.Visible = false;
                TablaProd.Visible = true;
                TablaClientes.Visible = false;
                TablaEmpleado.Visible = false;

                TablaProvee.Visible = false;
                PanelProvee.Visible = false;
            }
        }

        private void rdbEmpleados_CheckedChanged(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
               
                
                if (rdbEmpleados.Checked == true)
                {
                    this.Refresh();
                    TablaEmp();
                    //panel
                    PanelFoto.Visible = true;

                    
                    panelProtector.Visible = false;

                    PanelEmpleado.Visible = true;
                    PanelEmpleado.BringToFront();
                   
                    panelProductos.Visible = false;
                    //tabla
                    panelProc2.Visible = false;

                    TablaEmpleado.Visible = true;
                    TablaProd.Visible = false;
                    TablaProd.Visible = false;

                    TablaProvee.Visible = false;
                    PanelProvee.Visible = false;

                }
            }
            else
                rdbEmpleados.Enabled = false;
          
        }

        private void rdbProvee_CheckedChanged(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
              
                this.Refresh();
                TablaProv();
                //panel
                panelProtector.Visible = false;
                PanelFoto.Visible = false;
                PanelEmpleado.Visible = false;
               
                panelProductos.Visible = false;
                //tabla
                panelProc2.Visible = false;

                TablaEmpleado.Visible = false;
                TablaProd.Visible = false;
                TablaProd.Visible = false;

                TablaProvee.Visible = true;
                PanelProvee.Visible = true;
                PanelProvee.BringToFront();
            }
            else
                rdbProvee.Enabled = false;
            
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void TexCli(int c)
        {
        }
        //Inventario
        private void dgvProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int cod = (int)dgvProd.CurrentRow.Cells["IDprod"].Value;
            //TexProd(cod);
        }
        private void TexProd(int c)
        {
            try
            {
                SqlConnection con = Conexion.cadena();
                if (con != null)
                {
                    SqlCommand com = new SqlCommand("select * from Inventario where IDprod=" + c, con);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        txtidprod.Text = dr.GetInt32(0).ToString();
                        txtNombre.Text = dr.GetString(1);
                        txtDes.Text = dr.GetString(2);
                        txtCate.Text = dr.GetString(3);
                        txtFepro.Text = dr.GetDateTime(4).ToString("yyyy/MM/dd");
                        txtCan.Text = dr.GetInt32(5).ToString();
                        txtprecio.Text = dr.GetSqlMoney(6).ToString();
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
            

        }
        //Empleados
        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                //int co = (int)dgvEmp.CurrentRow.Cells["ID_Emp"].Value;
                
                //TexEmp(co);
        }
        private void TexEmp(int c)
        {
            try
            {
                SqlConnection con = Conexion.cadena();
                if (con != null)
                {
                    SqlCommand com = new SqlCommand("select * from Empleado where ID_Emp=" + c, con);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        txtIDEMP.Text = dr.GetInt32(0).ToString();
                        txtNomEmp.Text = dr.GetString(1);
                        txtApPatEmp.Text = dr.GetString(2);
                        txtApMaEmp.Text = dr.GetString(3);
                        if (dr.GetString(4) == null)
                        {
                            txtTipo.Text = dr.GetInt16(5).ToString();
                            txtContra.Text = dr.GetString(6);
                            txtRFCEmp.Text = dr.GetString(7);
                        }
                        else
                        {
                            PcBEmp.Image = Image.FromFile(Application.StartupPath + "\\Usuario" + dr.GetString(4));
                            txtTipo.Text = dr.GetInt16(5).ToString();
                            txtContra.Text = dr.GetString(6);
                            txtRFCEmp.Text = dr.GetString(7);
                        }

                    }
                }
            }
            catch (Exception)
            {
                return;
            }
            
        }
        //Proveedores
        private void dgvprov_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int co = (int)dgvprov.CurrentRow.Cells["IDPro"].Value;

            //TexPro(co);
        }
        private void TexPro(int c)
        {
            try
            {
                SqlConnection con = Conexion.cadena();
                if (con != null)
                {
                    SqlCommand com = new SqlCommand("select * from Proveedores where IDPro=" + c, con);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        txtIDprov.Text = dr.GetInt32(0).ToString();
                        txtNomProv.Text = dr.GetString(1);
                        txtDesProvee.Text = dr.GetString(2);
                        txtTelProv.Text = dr.GetString(3);
                        txtCorreoProv.Text = dr.GetString(4);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
            
        }


        //Radiobutton de altas,bajas,Cambios
        private void rdbAlta_CheckedChanged(object sender, EventArgs e)
        {
            es = Opciones.Alta;
            if (es == Opciones.Alta)
            {
                if (rdbEmpleados.Checked == true)
                {
                   
                    cont = 1;
                    txtIDEMP.Enabled = false;
                    txtNomEmp.Enabled = true;
                    txtApPatEmp.Enabled = true;
                    txtApMaEmp.Enabled = true;

                    txtRFCEmp.Enabled = true;
                    txtTipo.Enabled = true;
                    txtContra.Enabled = true;
                    panelMotivo.Visible = false;


                }
               
                if (rdbProductos.Checked == true)
                {
                    cont = 1;
                    txtidprod.Enabled = false;
                    txtNombre.Enabled = true;
                    txtDes.Enabled = true;
                    txtCan.Enabled = true;
                    txtFepro.Enabled = true;
                    txtCate.Enabled = true;
                    txtprecio.Enabled = true;
                    panelMotivo.Visible = false;

                }
                if (rdbProvee.Checked == true)
                {
                    cont = 1;
                    txtIDprov.Enabled = false;
                    txtNomProv.Enabled = true;
                    txtDesProvee.Enabled = true;
                    txtTelProv.Enabled = true;
                    txtCorreoProv.Enabled = true;
                    panelMotivo.Visible = false;

                }
            }
        }

        private void rdbBaja_CheckedChanged(object sender, EventArgs e)
        {
            es = Opciones.Baja;
            if (es == Opciones.Baja)
            {
                if (rdbEmpleados.Checked == true)
                {

                    cont = 2;
                    txtIDEMP.Enabled = true;
                    txtNomEmp.Enabled = false;
                    txtApPatEmp.Enabled = false;
                    txtApMaEmp.Enabled = false;

                    txtRFCEmp.Enabled = false;
                    txtTipo.Enabled = false;
                    txtContra.Enabled = false;

                    panelMotivo.Visible = true;
                }
                
                if (rdbProductos.Checked == true)
                {


                    cont = 2;
                    txtidprod.Enabled = true;
                    txtNombre.Enabled = false;
                    txtDes.Enabled = false;
                    txtCan.Enabled = false;
                    txtFepro.Enabled = false;
                    txtCate.Enabled = false;
                    txtprecio.Enabled = false;
                    panelMotivo.Visible = true;

                }
                if (rdbProvee.Checked == true)
                {
                    cont = 2;
                    txtIDprov.Enabled = true;
                    txtNomProv.Enabled = false;
                    txtDesProvee.Enabled = false;
                    txtTelProv.Enabled = false;
                    txtCorreoProv.Enabled = false;
                    panelMotivo.Visible = true;
                }
            }
        }

        private void rdbCambio_CheckedChanged(object sender, EventArgs e)
        {
            es = Opciones.Cambio;
            if (es == Opciones.Cambio)
            {
                if (rdbEmpleados.Checked == true)
                {

                    cont = 3;
                    txtIDEMP.Enabled = true;
                    txtNomEmp.Enabled = true;
                    txtApPatEmp.Enabled = true;
                    txtApMaEmp.Enabled = true;

                    txtRFCEmp.Enabled = true;
                    txtTipo.Enabled = true;
                    txtContra.Enabled = false;
                    panelMotivo.Visible = true;

                }
                
                if (rdbProductos.Checked == true)
                {

                    cont = 3;
                    txtidprod.Enabled = true;
                    txtNombre.Enabled = true;
                    txtDes.Enabled = true;
                    txtCan.Enabled = true;
                    txtFepro.Enabled = true;
                    txtCate.Enabled = true;
                    txtprecio.Enabled = true;
                    panelMotivo.Visible = true;

                }
                if (rdbProvee.Checked == true)
                {
                    cont = 3;
                    txtIDprov.Enabled = true;
                    txtNomProv.Enabled = true;
                    txtDesProvee.Enabled = true;
                    txtTelProv.Enabled = true;
                    txtCorreoProv.Enabled = true;
                    panelMotivo.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string __path = @"C:\Users\angel\Desktop\Escuela\misi\Misi 3.0\WindowsFormsApplication1\Json\Inventario.json";
            SqlConnection conexion = Conexion.cadena();
            using (conexion)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter sw = new StringWriter(sb);
                    Conexion.cadena();
                    string query = "Select * from Inventario";
                    SqlCommand Comando = new SqlCommand(query, conexion);
                    SqlDataReader reader = Comando.ExecuteReader();
                    using (JsonWriter jsonWriter = new JsonTextWriter(sw))
                    {
                        jsonWriter.Formatting = Newtonsoft.Json.Formatting.Indented;
                        jsonWriter.WriteStartArray();
                        while (reader.Read())
                        {
                            jsonWriter.WriteStartObject();
                            int fields = reader.FieldCount;
                            for (int i = 0; i < fields; i++)
                            {
                                jsonWriter.WritePropertyName(reader.GetName(i));
                                jsonWriter.WriteValue(reader[i]);
                            }
                            jsonWriter.WriteEndObject();

                        }
                        jsonWriter.WriteEndArray();
                        using (StreamWriter streamWriterw = new StreamWriter(__path))
                        {
                            streamWriterw.Write(sb.ToString());
                        }

                    }
                    MessageBox.Show("Archivo json generado");
                    conexion.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error" + x);
                    conexion.Close();
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Seleccionar imagen
        private void btnSelec_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ruta = openFileDialog1.FileName;
                    PcBEmp.Image = Image.FromFile(ruta);
                    PcBEmp.Image.Save(Application.StartupPath + ("\\Usuario\\") + txtNomEmp.Text +"_"+txtIDEMP.Text+".jpg", ImageFormat.Jpeg);
                    this.ruta = openFileDialog1.FileName;
                }
            }
            catch (Exception)
            {
                return;
            }
            
        }
    }
}
