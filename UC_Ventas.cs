using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta
{
    public partial class UC_Ventas : UserControl
    {
        decimal totalVenta = 0;

        public int IdEmpleado { get; set; }

        public UC_Ventas()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            ConfigurarCarrito();
        }

        // ============================================================
        // CONFIGURAR GRID
        // ============================================================
        private void ConfigurarCarrito()
        {
            dgvCarrito.AutoGenerateColumns = false;

            dgvCarrito.Columns.Add("ISBN", "ISBN");
            dgvCarrito.Columns.Add("Nombre", "Nombre");
            dgvCarrito.Columns.Add("Precio", "Precio");
            dgvCarrito.Columns.Add("Cantidad", "Cantidad");
            dgvCarrito.Columns.Add("Importe", "Importe");

            dgvCarrito.ReadOnly = true;
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ============================================================
        // BUSCAR LIBRO
        // ============================================================
        private void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Ingresa un ISBN válido.");
                return;
            }

            string sql = "SELECT NOMBRE, PRECIO, STOCK FROM LIBROS WHERE ISBN = @isbn";

            using (MySqlConnection cn = Conexion.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@isbn", txtISBN.Text.Trim());

                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblNombreLibro.Text = dr.GetString("NOMBRE");
                    lblPrecioLibro.Text = dr.GetDecimal("PRECIO").ToString("0.00");
                    lblStockLibro.Text = dr.GetInt32("STOCK").ToString();
                }
                else
                {
                    MessageBox.Show("Libro no encontrado.");
                    LimpiarInfoLibro();
                }
            }
        }

        private void LimpiarInfoLibro()
        {
            lblNombreLibro.Text = "";
            lblPrecioLibro.Text = "";
            lblStockLibro.Text = "";
        }

        // ============================================================
        // AGREGAR AL CARRITO
        // ============================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNombreLibro.Text))
            {
                MessageBox.Show("Primero busca un libro.");
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("Ingresa una cantidad mayor a cero.");
                return;
            }

            decimal precio = decimal.Parse(lblPrecioLibro.Text);
            int stock = int.Parse(lblStockLibro.Text);
            string isbn = txtISBN.Text.Trim();
            string nombre = lblNombreLibro.Text;

            if (cantidad > stock)
            {
                MessageBox.Show("No hay suficiente stock disponible.");
                return;
            }

            // Buscar si el libro ya está en el carrito
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.Cells["ISBN"].Value != null &&
                    row.Cells["ISBN"].Value.ToString() == isbn)
                {
                    int cantActual = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    int nuevaCantidad = cantActual + cantidad;

                    if (nuevaCantidad > stock)
                    {
                        MessageBox.Show("La cantidad supera el stock disponible.");
                        return;
                    }

                    row.Cells["Cantidad"].Value = nuevaCantidad;
                    row.Cells["Importe"].Value = nuevaCantidad * precio;

                    totalVenta += cantidad * precio;
                    lblTotal.Text = totalVenta.ToString("0.00");

                    lblStockLibro.Text = (stock - nuevaCantidad).ToString();
                    return;
                }
            }

            // Agregar nueva fila
            dgvCarrito.Rows.Add(isbn, nombre, precio, cantidad, cantidad * precio);

            totalVenta += precio * cantidad;
            lblTotal.Text = totalVenta.ToString("0.00");

            lblStockLibro.Text = (stock - cantidad).ToString();
        }


        // ============================================================
        // GUARDAR VENTA
        // ============================================================
        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en el carrito.");
                return;
            }

            if (IdEmpleado <= 0)
            {
                MessageBox.Show("Empleado no válido.");
                return;
            }

            try
            {
                int idVenta = Conexion.CrearVenta(IdEmpleado);

                foreach (DataGridViewRow row in dgvCarrito.Rows)
                {
                    string isbn = row.Cells["ISBN"].Value.ToString();
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                    Conexion.AgregarDetalle(idVenta, isbn, cantidad);
                }

                MessageBox.Show($"Venta registrada correctamente. ID: {idVenta}");

                LimpiarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar venta: " + ex.Message);
            }
        }

        private void LimpiarTodo()
        {
            dgvCarrito.Rows.Clear();
            totalVenta = 0;
            lblTotal.Text = "0.00";

            txtISBN.Clear();
            nudCantidad.Value = 0;

            LimpiarInfoLibro();
        }
    }
}



