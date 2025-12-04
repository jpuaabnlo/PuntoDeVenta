using MySql.Data.MySqlClient;
using Mysqlx.Resultset;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class UC_Ventas : UserControl
    {
        public UC_Ventas()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            DatosIncialesCarrito();
            DatosInicialesLibros();
        }

        private void DatosIncialesCarrito()
        {
            btnCancelar.Enabled = false;
            btnCrear.Enabled = false;
            dgvCarrito.Rows.Clear();
            lblCantidadTotal.Text = "0.00";
        }

        private void DatosInicialesLibros()
        {
            Conexion conexion = new Conexion();
            List<Libro> libros = conexion.GetLibros();
            LlenarGridLibros(libros);
            txtBuscar.Text = "";
        }

        private void LlenarGridLibros(List<Libro> libros)
        {
            dgvLibros.Rows.Clear();
            if (libros == null)
                return;
            foreach (Libro libro in libros)
            {
                if (libro.Activo == false || libro.Stock <= 0)
                    continue;
                dgvLibros.Rows.Add(
                    libro.ISBN,
                    libro.Nombre,
                    libro.Autor,
                    libro.Precio.ToString("C2"),
                    libro.Stock
                );
            }
            if (dgvLibros.Rows.Count == 0)
            {
                lblErrorLibro.Text = "No hay libros disponibles en el inventario.";
                lblErrorLibro.Visible = true;
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar_KeyUp(sender, new KeyEventArgs(Keys.Enter));
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblErrorLibro.Visible)
            {
                lblErrorLibro.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = txtBuscar.Text.Trim();
                if (keyword == "")
                {
                    dgvLibros.Rows.Clear();
                    DatosInicialesLibros();
                    return;
                }
                Conexion conexion = new Conexion();
                List<Libro> libros = conexion.FindLibro(keyword);
                if (libros == null || libros.Count == 0)
                {
                    dgvLibros.Rows.Clear();
                    lblErrorLibro.Text = "No se encontraron libros con el término \"" + keyword + "\"";
                    lblErrorLibro.Visible = true;
                }
                LlenarGridLibros(libros);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int stockActual = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["colStock"].Value);
            int cantidadAgregada = Convert.ToInt32(txtCantidad.Text);
            string isbnAgregado = dgvLibros.SelectedRows[0].Cells["colISBN"].Value.ToString();

            // Verificar si el libro ya está en el carrito y actualizar la cantidad e importe
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if(isbnAgregado == row.Cells["colCarritoISBN"].Value.ToString())
                {
                    int cantidadExistente = Convert.ToInt32(row.Cells["colCarritoCantidad"].Value);
                    Decimal precioUnitario = Convert.ToDecimal(dgvLibros.SelectedRows[0].Cells["colPrecio"].Value.ToString().Replace("$", ""));
                    Decimal nuevoImporte = precioUnitario * (cantidadExistente + cantidadAgregada);

                    row.Cells["colCarritoCantidad"].Value = cantidadExistente + cantidadAgregada;
                    row.Cells["colCarritoImporte"].Value = nuevoImporte.ToString("C2");

                    // Actualizar el stock en el grid de libros
                    dgvLibros.SelectedRows[0].Cells["colStock"].Value = stockActual - cantidadAgregada;
                    
                    if (Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["colStock"].Value) == 0)
                    {
                        // para deshabilitar la fila si el stock es 0
                        dgvLibros.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGray;
                        dgvLibros.SelectedRows[0].DefaultCellStyle.ForeColor = Color.DarkGray;
                        dgvLibros.ClearSelection();
                    }

                    if (btnCancelar.Enabled == false)
                        btnCancelar.Enabled = true;

                    if(btnCrear.Enabled == false)
                        btnCrear.Enabled = true;

                    CalcularTotal();
                    return;
                }
            }

            // Agregar nueva fila al carrito
            Decimal importe = Convert.ToDecimal(dgvLibros.SelectedRows[0].Cells["colPrecio"].Value.ToString().Replace("$", "")) * cantidadAgregada;
            dgvCarrito.Rows.Add(
                dgvLibros.SelectedRows[0].Cells["colISBN"].Value,
                dgvLibros.SelectedRows[0].Cells["colTitulo"].Value,
                dgvLibros.SelectedRows[0].Cells["colPrecio"].Value,
                txtCantidad.Text.ToString(),
                importe.ToString("C2")
            );

            // Actualizar el stock en el DataGridView de libros
            dgvLibros.SelectedRows[0].Cells["colStock"].Value = stockActual - cantidadAgregada;
            
            if (Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["colStock"].Value) == 0)
            {
                // para deshabilitar la fila si el stock es 0
                dgvLibros.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGray;
                dgvLibros.SelectedRows[0].DefaultCellStyle.ForeColor = Color.DarkGray;
                dgvLibros.ClearSelection();
            }
            if (btnCancelar.Enabled == false)
                btnCancelar.Enabled = true;

            if (btnCrear.Enabled == false)
                btnCrear.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string isbnEliminado = dgvCarrito.SelectedRows[0].Cells["colCarritoISBN"].Value.ToString();
            int cantidadEliminada = Convert.ToInt32(dgvCarrito.SelectedRows[0].Cells["colCarritoCantidad"].Value);

            // Actualizar el stock en el DataGridView de libros
            foreach (DataGridViewRow row in dgvLibros.Rows)
            {
                if (row.Cells["colISBN"].Value.ToString() == isbnEliminado)
                {
                    int stockActual = Convert.ToInt32(row.Cells["colStock"].Value);

                    row.Cells["colStock"].Value = stockActual + cantidadEliminada;

                    // Verificar si se debe habilitar la fila nuevamente
                    if (Convert.ToInt32(row.Cells["colStock"].Value) > 0)
                    {
                        // para habilitar la fila si el stock es mayor a 0
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    break;
                }
            }
            // Eliminar la fila del carrito
            dgvCarrito.Rows.RemoveAt(dgvCarrito.SelectedRows[0].Index);

            // Deshabilitar el botón Cancelar y Crear si el carrito está vacío
            if (dgvCarrito.Rows.Count == 0)
            {
                btnCancelar.Enabled = false;
                btnCrear.Enabled = false;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            List<(string, int)> libros = new List<(string, int)>();

            // Recolectar los libros y sus cantidades del carrito
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                libros.Add(
                    (
                        row.Cells["colCarritoISBN"].Value.ToString(),
                        Convert.ToInt32(row.Cells["colCarritoCantidad"].Value)
                    )
                );
            }

            Conexion conexion = new Conexion();
            int idEmpleado = Sesion.EmpleadoActual.Id;
            if(conexion.CrearVentaCompleta(idEmpleado, libros))
            {
                MessageBox.Show("Venta creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DatosIncialesCarrito();
                DatosInicialesLibros();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al crear la venta. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DatosIncialesCarrito();
            DatosInicialesLibros();
        }

        private void btnCantidadMas_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0)
                return;

            int cantidadLibro = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["colStock"].Value);
            int cantidadActual = Convert.ToInt32(txtCantidad.Text);

            // Habilitar el botón de menos si estaba deshabilitado
            if (btnCantidadMenos.Enabled == false)
                btnCantidadMenos.Enabled = true;

            // Verificar si se alcanza el stock máximo
            if (cantidadActual >= cantidadLibro - 1)
            {
                if (cantidadLibro < 1)
                    cantidadLibro = 1;
                txtCantidad.Text = cantidadLibro.ToString();
                btnCantidadMas.Enabled = false;
            }
            else
            {
                txtCantidad.Text = (cantidadActual + 1).ToString();
            }
        }

        private void btnCantidadMenos_Click(object sender, EventArgs e)
        {
            int cantidadActual = Convert.ToInt32(txtCantidad.Text);

            // Habilitar el botón de más si estaba deshabilitado
            if (btnCantidadMas.Enabled == false)
                btnCantidadMas.Enabled = true;

            // Verificar si se alcanza el mínimo de 1
            if (cantidadActual <= 2)
            {
                txtCantidad.Text = "1";
                btnCantidadMenos.Enabled = false;
            }
            else
            {
                txtCantidad.Text = (cantidadActual - 1).ToString();
            }
        }

        private void dgvLibros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0)
            {
                btnAgregar.Enabled = false;
                return;
            }
            int stockDisponible = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["colStock"].Value);
            if (stockDisponible == 0)
            {
                btnAgregar.Enabled = false;
                return;
            }
            btnAgregar.Enabled = dgvLibros.SelectedRows.Count > 0;
        }

        private void dgvCarrito_SelectionChanged(object sender, EventArgs e)
        {
            btnEliminar.Enabled = dgvCarrito.SelectedRows.Count > 0;
        }

        private void dgvCarrito_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcularTotal();
        }

        private void dgvCarrito_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            Decimal total = 0;

            // Calcular el total del carrito
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                total += Convert.ToDecimal(row.Cells["colCarritoImporte"].Value);
            }
            lblCantidadTotal.Text = total.ToString("C2");
        }
    }
}



