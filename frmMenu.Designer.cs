namespace PuntoDeVenta
{
    partial class frmMenu
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.flpOpcionesMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.flpOpcionesMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.flpOpcionesMenu);
            this.pnlMenu.Location = new System.Drawing.Point(0, 125);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(150, 300);
            this.pnlMenu.TabIndex = 0;
            // 
            // flpOpcionesMenu
            // 
            this.flpOpcionesMenu.BackColor = System.Drawing.Color.Transparent;
            this.flpOpcionesMenu.Controls.Add(this.btnVentas);
            this.flpOpcionesMenu.Controls.Add(this.btnReportes);
            this.flpOpcionesMenu.Controls.Add(this.btnProductos);
            this.flpOpcionesMenu.Controls.Add(this.btnEmpleados);
            this.flpOpcionesMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOpcionesMenu.Location = new System.Drawing.Point(0, 0);
            this.flpOpcionesMenu.Name = "flpOpcionesMenu";
            this.flpOpcionesMenu.Size = new System.Drawing.Size(150, 300);
            this.flpOpcionesMenu.TabIndex = 0;
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(3, 3);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(75, 23);
            this.btnVentas.TabIndex = 0;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(3, 32);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(75, 23);
            this.btnReportes.TabIndex = 2;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(3, 61);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(75, 23);
            this.btnProductos.TabIndex = 3;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Location = new System.Drawing.Point(3, 90);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(75, 23);
            this.btnEmpleados.TabIndex = 4;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainer.Location = new System.Drawing.Point(175, 5);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1000, 540);
            this.pnlContainer.TabIndex = 1;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlMenu);
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.pnlMenu.ResumeLayout(false);
            this.flpOpcionesMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.FlowLayoutPanel flpOpcionesMenu;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnEmpleados;
    }
}