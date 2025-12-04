using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta
{
    public partial class frmVentas : Form
    {
        decimal totalVenta = 0;

        public int IdEmpleado { get; set; } 

        public frmVentas()
        {
            InitializeComponent();

            // Configurar columnas del DataGridView
            dgvCarrito.Columns.Add("ISBN", "ISBN");
            dgvCarrito.Columns.Add("Nombre", "Nombre");
            dgvCarrito.Columns.Add("Precio", "Precio");
            dgvCarrito.Columns.Add("Cantidad", "Cantidad");
            dgvCarrito.Columns.Add("Importe", "Importe");
        }

        private void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            string sql = "SELECT NOMBRE, PRECIO, STOCK FROM LIBROS WHERE ISBN = @isbn";

            using (MySqlConnection cn = Conexion.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@isbn", txtISBN.Text);

                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblNombreLibro.Text = dr.GetString("NOMBRE");
                    lblPrecioLibro.Text = dr.GetDecimal("PRECIO").ToString();
                    lblStockLibro.Text = dr.GetInt32("STOCK").ToString();
                }
                else
                {
                    MessageBox.Show("Libro no encontrado");
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string isbn = txtISBN.Text;
            string nombre = lblNombreLibro.Text;
            int cantidad = (int)nudCantidad.Value;
            decimal precio = decimal.Parse(lblPrecioLibro.Text);
            int stock = int.Parse(lblStockLibro.Text);

            if (cantidad > stock)
            {
                MessageBox.Show("No hay suficiente stock");
                return;
            }

            decimal importe = cantidad * precio;

            dgvCarrito.Rows.Add(isbn, nombre, precio, cantidad, importe);

            totalVenta += importe;
            lblTotal.Text = totalVenta.ToString("0.00");
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en la venta");
                return;
            }

            using (MySqlConnection cn = Conexion.GetConnection())
            {
                cn.Open();
                MySqlTransaction trans = cn.BeginTransaction();

                try
                {
                    // INSERT en tabla VENTAS
                    string sqlVenta = "INSERT INTO VENTAS (ID_EMPLEADO, FECHA, TOTAL) VALUES (@emp, NOW(), @tot)";
                    MySqlCommand cmdVenta = new MySqlCommand(sqlVenta, cn, trans);
                    cmdVenta.Parameters.AddWithValue("@emp", IdEmpleado);
                    cmdVenta.Parameters.AddWithValue("@tot", totalVenta);
                    cmdVenta.ExecuteNonQuery();

                    long idVenta = cmdVenta.LastInsertedId;

                    // INSERT en tabla DETALLE_VENTA
                    foreach (DataGridViewRow row in dgvCarrito.Rows)
                    {
                        string sqlDetalle = "INSERT INTO DETALLE_VENTA (ID_VENTA, ISBN, CANTIDAD, PRECIO, IMPORTE) VALUES (@id, @isbn, @can, @pre, @imp)";
                        MySqlCommand cmdDet = new MySqlCommand(sqlDetalle, cn, trans);

                        cmdDet.Parameters.AddWithValue("@id", idVenta);
                        cmdDet.Parameters.AddWithValue("@isbn", row.Cells["ISBN"].Value);
                        cmdDet.Parameters.AddWithValue("@can", row.Cells["Cantidad"].Value);
                        cmdDet.Parameters.AddWithValue("@pre", row.Cells["Precio"].Value);
                        cmdDet.Parameters.AddWithValue("@imp", row.Cells["Importe"].Value);
                        cmdDet.ExecuteNonQuery();

                        // Actualizar stock
                        string sqlStock = "UPDATE LIBROS SET STOCK = STOCK - @can WHERE ISBN = @isbn";
                        MySqlCommand cmdStock = new MySqlCommand(sqlStock, cn, trans);
                        cmdStock.Parameters.AddWithValue("@can", row.Cells["Cantidad"].Value);
                        cmdStock.Parameters.AddWithValue("@isbn", row.Cells["ISBN"].Value);
                        cmdStock.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Venta guardada correctamente");

                    dgvCarrito.Rows.Clear();
                    totalVenta = 0;
                    lblTotal.Text = "0.00";
                }
                catch
                {
                    trans.Rollback();
                    MessageBox.Show("Error al guardar la venta");
                }
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

        }
    }
}

