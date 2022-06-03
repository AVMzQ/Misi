namespace WindowsFormsApplication1
{
    partial class BitacoraEmpleado
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
            this.dgvBita = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBita)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBita
            // 
            this.dgvBita.AllowUserToAddRows = false;
            this.dgvBita.AllowUserToDeleteRows = false;
            this.dgvBita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBita.Location = new System.Drawing.Point(12, 12);
            this.dgvBita.Name = "dgvBita";
            this.dgvBita.ReadOnly = true;
            this.dgvBita.Size = new System.Drawing.Size(514, 255);
            this.dgvBita.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(338, 274);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Regresar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BitacoraEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(538, 309);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dgvBita);
            this.Name = "BitacoraEmpleado";
            this.Text = "Bitacora de Empleados";
            this.Load += new System.EventHandler(this.BitacoraEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBita)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBita;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
    }
}