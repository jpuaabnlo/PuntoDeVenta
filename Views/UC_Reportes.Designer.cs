namespace PuntoDeVenta
{
    partial class UC_Reportes
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.chkEmpleados = new System.Windows.Forms.RadioButton();
            this.chkLibros = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(182, 16);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(265, 22);
            this.dtpInicio.TabIndex = 2;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(681, 15);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(265, 22);
            this.dtpFin.TabIndex = 3;
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(7, 57);
            this.dgvReporte.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.Size = new System.Drawing.Size(939, 406);
            this.dgvReporte.TabIndex = 4;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.lblFin);
            this.pnlTop.Controls.Add(this.lblInicio);
            this.pnlTop.Controls.Add(this.dtpInicio);
            this.pnlTop.Controls.Add(this.dtpFin);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(950, 50);
            this.pnlTop.TabIndex = 17;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Sylfaen", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.Color.LightGray;
            this.lblInicio.Location = new System.Drawing.Point(3, 13);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(125, 23);
            this.lblInicio.TabIndex = 7;
            this.lblInicio.Text = "Fecha de Inicio:";
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Font = new System.Drawing.Font("Sylfaen", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFin.ForeColor = System.Drawing.Color.LightGray;
            this.lblFin.Location = new System.Drawing.Point(519, 15);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(120, 23);
            this.lblFin.TabIndex = 10;
            this.lblFin.Text = "Fecha de Final:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.chkLibros);
            this.panel1.Controls.Add(this.chkEmpleados);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 470);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 50);
            this.panel1.TabIndex = 18;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnGenerar.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(747, 7);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(200, 40);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click_1);
            // 
            // chkEmpleados
            // 
            this.chkEmpleados.AutoSize = true;
            this.chkEmpleados.Checked = true;
            this.chkEmpleados.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmpleados.Location = new System.Drawing.Point(7, 14);
            this.chkEmpleados.Name = "chkEmpleados";
            this.chkEmpleados.Size = new System.Drawing.Size(185, 26);
            this.chkEmpleados.TabIndex = 5;
            this.chkEmpleados.TabStop = true;
            this.chkEmpleados.Text = "Ventas de Empleados";
            this.chkEmpleados.UseVisualStyleBackColor = true;
            // 
            // chkLibros
            // 
            this.chkLibros.AutoSize = true;
            this.chkLibros.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLibros.Location = new System.Drawing.Point(198, 14);
            this.chkLibros.Name = "chkLibros";
            this.chkLibros.Size = new System.Drawing.Size(145, 26);
            this.chkLibros.TabIndex = 6;
            this.chkLibros.Text = "Libros vendidos";
            this.chkLibros.UseVisualStyleBackColor = true;
            // 
            // UC_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvReporte);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Reportes";
            this.Size = new System.Drawing.Size(950, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.RadioButton chkLibros;
        private System.Windows.Forms.RadioButton chkEmpleados;
    }
}
