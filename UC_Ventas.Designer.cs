namespace PuntoDeVenta
{
    partial class UC_Ventas
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
            this.lblNombreLibro = new System.Windows.Forms.Label();
            this.lblPrecioLibro = new System.Windows.Forms.Label();
            this.lblStockLibro = new System.Windows.Forms.Label();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.ColCarritoISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCarritoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCarritoPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCarritoCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCarritoImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblErrorLibro = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCantidadTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.colISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCantidadMas = new System.Windows.Forms.Button();
            this.btnCantidadMenos = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreLibro
            // 
            this.lblNombreLibro.AutoSize = true;
            this.lblNombreLibro.Location = new System.Drawing.Point(203, 123);
            this.lblNombreLibro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreLibro.Name = "lblNombreLibro";
            this.lblNombreLibro.Size = new System.Drawing.Size(0, 16);
            this.lblNombreLibro.TabIndex = 4;
            // 
            // lblPrecioLibro
            // 
            this.lblPrecioLibro.AutoSize = true;
            this.lblPrecioLibro.Location = new System.Drawing.Point(207, 161);
            this.lblPrecioLibro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecioLibro.Name = "lblPrecioLibro";
            this.lblPrecioLibro.Size = new System.Drawing.Size(0, 16);
            this.lblPrecioLibro.TabIndex = 6;
            // 
            // lblStockLibro
            // 
            this.lblStockLibro.AutoSize = true;
            this.lblStockLibro.Location = new System.Drawing.Point(203, 202);
            this.lblStockLibro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockLibro.Name = "lblStockLibro";
            this.lblStockLibro.Size = new System.Drawing.Size(0, 16);
            this.lblStockLibro.TabIndex = 8;
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCarritoISBN,
            this.ColCarritoNombre,
            this.ColCarritoPrecio,
            this.ColCarritoCantidad,
            this.ColCarritoImporte});
            this.dgvCarrito.Location = new System.Drawing.Point(7, 202);
            this.dgvCarrito.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCarrito.MultiSelect = false;
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new System.Drawing.Size(939, 261);
            this.dgvCarrito.TabIndex = 12;
            this.dgvCarrito.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCarrito_RowsAdded);
            this.dgvCarrito.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCarrito_RowsRemoved);
            this.dgvCarrito.SelectionChanged += new System.EventHandler(this.dgvCarrito_SelectionChanged);
            // 
            // ColCarritoISBN
            // 
            this.ColCarritoISBN.HeaderText = "ISBN";
            this.ColCarritoISBN.MinimumWidth = 6;
            this.ColCarritoISBN.Name = "ColCarritoISBN";
            this.ColCarritoISBN.ReadOnly = true;
            this.ColCarritoISBN.Width = 125;
            // 
            // ColCarritoNombre
            // 
            this.ColCarritoNombre.HeaderText = "Titulo";
            this.ColCarritoNombre.MinimumWidth = 6;
            this.ColCarritoNombre.Name = "ColCarritoNombre";
            this.ColCarritoNombre.ReadOnly = true;
            this.ColCarritoNombre.Width = 125;
            // 
            // ColCarritoPrecio
            // 
            this.ColCarritoPrecio.HeaderText = "Precio";
            this.ColCarritoPrecio.MinimumWidth = 6;
            this.ColCarritoPrecio.Name = "ColCarritoPrecio";
            this.ColCarritoPrecio.ReadOnly = true;
            this.ColCarritoPrecio.Width = 125;
            // 
            // ColCarritoCantidad
            // 
            this.ColCarritoCantidad.HeaderText = "Cantidad";
            this.ColCarritoCantidad.MinimumWidth = 6;
            this.ColCarritoCantidad.Name = "ColCarritoCantidad";
            this.ColCarritoCantidad.ReadOnly = true;
            this.ColCarritoCantidad.Width = 125;
            // 
            // ColCarritoImporte
            // 
            this.ColCarritoImporte.HeaderText = "Importe";
            this.ColCarritoImporte.MinimumWidth = 6;
            this.ColCarritoImporte.Name = "ColCarritoImporte";
            this.ColCarritoImporte.ReadOnly = true;
            this.ColCarritoImporte.Width = 125;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.lblErrorLibro);
            this.pnlTop.Controls.Add(this.btnBuscar);
            this.pnlTop.Controls.Add(this.lblBuscar);
            this.pnlTop.Controls.Add(this.txtBuscar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(950, 50);
            this.pnlTop.TabIndex = 16;
            // 
            // lblErrorLibro
            // 
            this.lblErrorLibro.AutoSize = true;
            this.lblErrorLibro.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorLibro.ForeColor = System.Drawing.Color.IndianRed;
            this.lblErrorLibro.Location = new System.Drawing.Point(477, 14);
            this.lblErrorLibro.Name = "lblErrorLibro";
            this.lblErrorLibro.Size = new System.Drawing.Size(164, 22);
            this.lblErrorLibro.TabIndex = 10;
            this.lblErrorLibro.Text = "Libro no encontrado.";
            this.lblErrorLibro.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Honeydew;
            this.btnBuscar.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(747, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(200, 40);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Sylfaen", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.LightGray;
            this.lblBuscar.Location = new System.Drawing.Point(3, 13);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(133, 23);
            this.lblBuscar.TabIndex = 7;
            this.lblBuscar.Text = "Buscar Libro(s): ";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(185, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(275, 30);
            this.txtBuscar.TabIndex = 8;
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.lblCantidadTotal);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnCrear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 470);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 50);
            this.panel1.TabIndex = 17;
            // 
            // lblCantidadTotal
            // 
            this.lblCantidadTotal.AutoSize = true;
            this.lblCantidadTotal.Font = new System.Drawing.Font("Sylfaen", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadTotal.Location = new System.Drawing.Point(619, 15);
            this.lblCantidadTotal.Name = "lblCantidadTotal";
            this.lblCantidadTotal.Size = new System.Drawing.Size(42, 23);
            this.lblCantidadTotal.TabIndex = 6;
            this.lblCantidadTotal.Text = "0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Sylfaen", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(545, 15);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(68, 23);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total: $";
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCrear.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Location = new System.Drawing.Point(747, 7);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(200, 40);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Generar Venta";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // dgvLibros
            // 
            this.dgvLibros.AllowUserToAddRows = false;
            this.dgvLibros.AllowUserToDeleteRows = false;
            this.dgvLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colISBN,
            this.colTitulo,
            this.colAutor,
            this.colPrecio,
            this.colStock});
            this.dgvLibros.Location = new System.Drawing.Point(8, 66);
            this.dgvLibros.MultiSelect = false;
            this.dgvLibros.Name = "dgvLibros";
            this.dgvLibros.ReadOnly = true;
            this.dgvLibros.RowHeadersWidth = 51;
            this.dgvLibros.RowTemplate.Height = 24;
            this.dgvLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLibros.Size = new System.Drawing.Size(813, 129);
            this.dgvLibros.TabIndex = 18;
            this.dgvLibros.SelectionChanged += new System.EventHandler(this.dgvLibros_SelectionChanged);
            // 
            // colISBN
            // 
            this.colISBN.HeaderText = "ISBN";
            this.colISBN.MinimumWidth = 6;
            this.colISBN.Name = "colISBN";
            this.colISBN.ReadOnly = true;
            this.colISBN.Width = 125;
            // 
            // colTitulo
            // 
            this.colTitulo.HeaderText = "Titulo";
            this.colTitulo.MinimumWidth = 6;
            this.colTitulo.Name = "colTitulo";
            this.colTitulo.ReadOnly = true;
            this.colTitulo.Width = 150;
            // 
            // colAutor
            // 
            this.colAutor.HeaderText = "Autor";
            this.colAutor.MinimumWidth = 6;
            this.colAutor.Name = "colAutor";
            this.colAutor.ReadOnly = true;
            this.colAutor.Width = 150;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.MinimumWidth = 6;
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 75;
            // 
            // colStock
            // 
            this.colStock.HeaderText = "Stock";
            this.colStock.MinimumWidth = 6;
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 75;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.GreenYellow;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(827, 148);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 40);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCantidadMas
            // 
            this.btnCantidadMas.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCantidadMas.Location = new System.Drawing.Point(827, 65);
            this.btnCantidadMas.Name = "btnCantidadMas";
            this.btnCantidadMas.Size = new System.Drawing.Size(30, 30);
            this.btnCantidadMas.TabIndex = 20;
            this.btnCantidadMas.Text = "+";
            this.btnCantidadMas.UseVisualStyleBackColor = true;
            this.btnCantidadMas.Click += new System.EventHandler(this.btnCantidadMas_Click);
            // 
            // btnCantidadMenos
            // 
            this.btnCantidadMenos.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCantidadMenos.Location = new System.Drawing.Point(917, 66);
            this.btnCantidadMenos.Name = "btnCantidadMenos";
            this.btnCantidadMenos.Size = new System.Drawing.Size(30, 30);
            this.btnCantidadMenos.TabIndex = 21;
            this.btnCantidadMenos.Text = "-";
            this.btnCantidadMenos.UseVisualStyleBackColor = true;
            this.btnCantidadMenos.Click += new System.EventHandler(this.btnCantidadMenos_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(863, 66);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(48, 30);
            this.txtCantidad.TabIndex = 22;
            this.txtCantidad.Text = "1";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.IndianRed;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(827, 102);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 40);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Font = new System.Drawing.Font("Sylfaen", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(8, 7);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(200, 40);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar Venta";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // UC_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnCantidadMenos);
            this.Controls.Add(this.btnCantidadMas);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvLibros);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.lblStockLibro);
            this.Controls.Add(this.lblPrecioLibro);
            this.Controls.Add(this.lblNombreLibro);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Ventas";
            this.Size = new System.Drawing.Size(950, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNombreLibro;
        private System.Windows.Forms.Label lblPrecioLibro;
        private System.Windows.Forms.Label lblStockLibro;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblErrorLibro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCantidadMas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.Button btnCantidadMenos;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCantidadTotal;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCarritoISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCarritoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCarritoPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCarritoCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCarritoImporte;
        private System.Windows.Forms.Button btnCancelar;
    }
}
