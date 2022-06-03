namespace WindowsFormsApplication1
{
    partial class PanelControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnBitaEmpl = new System.Windows.Forms.Button();
            this.btnABC = new System.Windows.Forms.Button();
            this.btnRegVentas = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.GVistas = new System.Windows.Forms.GroupBox();
            this.btnInventario = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelDefaul = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lb21a = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PcbFoto = new System.Windows.Forms.PictureBox();
            this.FechaHora = new System.Windows.Forms.Timer(this.components);
            this.RutaDeGuardado = new System.Windows.Forms.SaveFileDialog();
            this.PanelPedido = new System.Windows.Forms.Panel();
            this.txtTotalMed = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.txtCodProv = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.GVistas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDefaul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PcbFoto)).BeginInit();
            this.PanelPedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBitaEmpl
            // 
            this.btnBitaEmpl.Location = new System.Drawing.Point(6, 21);
            this.btnBitaEmpl.Name = "btnBitaEmpl";
            this.btnBitaEmpl.Size = new System.Drawing.Size(179, 32);
            this.btnBitaEmpl.TabIndex = 3;
            this.btnBitaEmpl.Text = "Bitacora de Empleados";
            this.btnBitaEmpl.UseVisualStyleBackColor = true;
            this.btnBitaEmpl.Click += new System.EventHandler(this.btnBitaEmpl_Click);
            // 
            // btnABC
            // 
            this.btnABC.Location = new System.Drawing.Point(6, 19);
            this.btnABC.Name = "btnABC";
            this.btnABC.Size = new System.Drawing.Size(179, 32);
            this.btnABC.TabIndex = 5;
            this.btnABC.Text = "ABC";
            this.btnABC.UseVisualStyleBackColor = true;
            this.btnABC.Click += new System.EventHandler(this.btnABC_Click);
            // 
            // btnRegVentas
            // 
            this.btnRegVentas.Location = new System.Drawing.Point(6, 62);
            this.btnRegVentas.Name = "btnRegVentas";
            this.btnRegVentas.Size = new System.Drawing.Size(179, 32);
            this.btnRegVentas.TabIndex = 6;
            this.btnRegVentas.Text = "Ventas";
            this.btnRegVentas.UseVisualStyleBackColor = true;
            this.btnRegVentas.Click += new System.EventHandler(this.btnRegVentas_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(15, 409);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(179, 32);
            this.btnRegresar.TabIndex = 7;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.btnABC);
            this.groupBox2.Location = new System.Drawing.Point(3, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 102);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Movimientos";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(179, 32);
            this.button4.TabIndex = 6;
            this.button4.Text = "Realizar pedido";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // GVistas
            // 
            this.GVistas.Controls.Add(this.btnInventario);
            this.GVistas.Controls.Add(this.button3);
            this.GVistas.Controls.Add(this.button2);
            this.GVistas.Controls.Add(this.button1);
            this.GVistas.Controls.Add(this.btnRegVentas);
            this.GVistas.Controls.Add(this.btnBitaEmpl);
            this.GVistas.Location = new System.Drawing.Point(3, 129);
            this.GVistas.Name = "GVistas";
            this.GVistas.Size = new System.Drawing.Size(191, 257);
            this.GVistas.TabIndex = 11;
            this.GVistas.TabStop = false;
            this.GVistas.Text = "Vistas";
            // 
            // btnInventario
            // 
            this.btnInventario.Location = new System.Drawing.Point(6, 217);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(179, 32);
            this.btnInventario.TabIndex = 13;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 179);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 32);
            this.button3.TabIndex = 12;
            this.button3.Text = "Proveedores";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 32);
            this.button2.TabIndex = 11;
            this.button2.Text = "Entrega de producto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 32);
            this.button1.TabIndex = 10;
            this.button1.Text = "Compra de proveedores";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.GVistas);
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 453);
            this.panel1.TabIndex = 9;
            // 
            // panelDefaul
            // 
            this.panelDefaul.AutoScroll = true;
            this.panelDefaul.Controls.Add(this.lblFecha);
            this.panelDefaul.Controls.Add(this.lblHora);
            this.panelDefaul.Controls.Add(this.lb21a);
            this.panelDefaul.Controls.Add(this.lblCodigo);
            this.panelDefaul.Controls.Add(this.lblStatus);
            this.panelDefaul.Controls.Add(this.lblNombre);
            this.panelDefaul.Controls.Add(this.label3);
            this.panelDefaul.Controls.Add(this.label2);
            this.panelDefaul.Controls.Add(this.label1);
            this.panelDefaul.Controls.Add(this.PcbFoto);
            this.panelDefaul.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDefaul.Location = new System.Drawing.Point(221, 0);
            this.panelDefaul.Name = "panelDefaul";
            this.panelDefaul.Size = new System.Drawing.Size(361, 453);
            this.panelDefaul.TabIndex = 10;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFecha.Location = new System.Drawing.Point(190, 59);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 12;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHora.Location = new System.Drawing.Point(190, 34);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(0, 13);
            this.lblHora.TabIndex = 10;
            // 
            // lb21a
            // 
            this.lb21a.AutoSize = true;
            this.lb21a.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb21a.Location = new System.Drawing.Point(190, 9);
            this.lb21a.Name = "lb21a";
            this.lb21a.Size = new System.Drawing.Size(30, 13);
            this.lb21a.TabIndex = 9;
            this.lb21a.Text = "Hora";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(120, 265);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 23);
            this.lblCodigo.TabIndex = 6;
            this.lblCodigo.Text = "label4";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(120, 226);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 23);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "label4";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(120, 187);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 23);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // PcbFoto
            // 
            this.PcbFoto.Location = new System.Drawing.Point(6, 3);
            this.PcbFoto.Name = "PcbFoto";
            this.PcbFoto.Size = new System.Drawing.Size(167, 153);
            this.PcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PcbFoto.TabIndex = 0;
            this.PcbFoto.TabStop = false;
            // 
            // FechaHora
            // 
            this.FechaHora.Enabled = true;
            this.FechaHora.Tick += new System.EventHandler(this.FechaHora_Tick);
            // 
            // RutaDeGuardado
            // 
            this.RutaDeGuardado.Filter = "Archivo bak(*.bak)|*.bak";
            // 
            // PanelPedido
            // 
            this.PanelPedido.Controls.Add(this.txtTotalMed);
            this.PanelPedido.Controls.Add(this.label17);
            this.PanelPedido.Controls.Add(this.txtNombre);
            this.PanelPedido.Controls.Add(this.label15);
            this.PanelPedido.Controls.Add(this.txtMontoTotal);
            this.PanelPedido.Controls.Add(this.label16);
            this.PanelPedido.Controls.Add(this.label14);
            this.PanelPedido.Controls.Add(this.btnTerminar);
            this.PanelPedido.Controls.Add(this.txtCodProv);
            this.PanelPedido.Controls.Add(this.label11);
            this.PanelPedido.Location = new System.Drawing.Point(221, 0);
            this.PanelPedido.Name = "PanelPedido";
            this.PanelPedido.Size = new System.Drawing.Size(361, 453);
            this.PanelPedido.TabIndex = 11;
            // 
            // txtTotalMed
            // 
            this.txtTotalMed.Location = new System.Drawing.Point(164, 165);
            this.txtTotalMed.Name = "txtTotalMed";
            this.txtTotalMed.Size = new System.Drawing.Size(123, 20);
            this.txtTotalMed.TabIndex = 41;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(28, 170);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Total de medicamentos";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(31, 265);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(256, 75);
            this.txtNombre.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(119, 234);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Medicamento";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Location = new System.Drawing.Point(165, 198);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.Size = new System.Drawing.Size(123, 20);
            this.txtMontoTotal.TabIndex = 37;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(30, 205);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Monto total";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(103, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Realizar pedido";
            // 
            // btnTerminar
            // 
            this.btnTerminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTerminar.Location = new System.Drawing.Point(44, 346);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(232, 23);
            this.btnTerminar.TabIndex = 31;
            this.btnTerminar.Text = "Realizar pedido";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // txtCodProv
            // 
            this.txtCodProv.Location = new System.Drawing.Point(165, 129);
            this.txtCodProv.Name = "txtCodProv";
            this.txtCodProv.Size = new System.Drawing.Size(123, 20);
            this.txtCodProv.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(29, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Codigo del proveedor";
            // 
            // PanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.PanelPedido);
            this.Controls.Add(this.panelDefaul);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PanelControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de control";
            this.Load += new System.EventHandler(this.PanelControl_Load);
            this.groupBox2.ResumeLayout(false);
            this.GVistas.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelDefaul.ResumeLayout(false);
            this.panelDefaul.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PcbFoto)).EndInit();
            this.PanelPedido.ResumeLayout(false);
            this.PanelPedido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBitaEmpl;
        private System.Windows.Forms.Button btnABC;
        private System.Windows.Forms.Button btnRegVentas;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox GVistas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelDefaul;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PcbFoto;
        private System.Windows.Forms.Timer FechaHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lb21a;
        private System.Windows.Forms.SaveFileDialog RutaDeGuardado;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel PanelPedido;
        private System.Windows.Forms.TextBox txtTotalMed;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.TextBox txtCodProv;
        private System.Windows.Forms.Label label11;
    }
}