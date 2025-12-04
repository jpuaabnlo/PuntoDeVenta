using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class UC_Productos : UserControl
    {
        public UC_Productos()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Cargar datos iniciales de los productos en el DataGridView
            DatosIniciales();

            // Configurar visibilidad y estado de los botones según el rol del usuario
            btnActualizar.Visible = Sesion.EmpleadoActual.SuperUser;
            btnBorrar.Visible = Sesion.EmpleadoActual.SuperUser;
            btnActualizar.Enabled = false;
            btnBorrar.Enabled = false;
        }

        private void DatosIniciales()
        {
            Conexion conexion = new Conexion();
            List<Libro> libros = conexion.GetLibros();
            LlenarGrid(libros);
            txtBuscar.Text = "";
        }

        private void LlenarGrid(List<Libro> libros)
        {
            // Lógica para llenar el DataGridView con datos de libros
            dgvLibros.Rows.Clear();
            if (libros == null)
                return;
            foreach (Libro libro in libros)
            {
                dgvLibros.Rows.Add(
                    libro.ISBN,
                    libro.Nombre,
                    libro.Autor,
                    libro.Precio.ToString("C2"),
                    libro.Stock,
                    libro.Descripcion,
                    libro.Activo ? "Disponible" : "Descontinuado"
                );
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if(lblErrorLibro.Visible)
            {
                lblErrorLibro.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = txtBuscar.Text.Trim();

                if (keyword == "")
                {
                    dgvLibros.Rows.Clear();
                    DatosIniciales();
                    return;
                }

                // Buscar libros
                Conexion conexion = new Conexion();
                List<Libro> libros = conexion.FindLibro(keyword);
                
                // Mostrar mensaje si no se encuentran libros
                if (libros == null || libros.Count == 0)
                {
                    dgvLibros.Rows.Clear();
                    lblErrorLibro.Text = "No se encontraron libros con el término \"" + keyword + "\"";
                    lblErrorLibro.Visible = true;
                }

                // Llenar el DataGridView con los libros encontrados
                LlenarGrid(libros);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar_KeyUp(sender, new KeyEventArgs(Keys.Enter));
        }

        private void dgvLibros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count > 0)
            {
                if (Sesion.EmpleadoActual.SuperUser)
                {
                    btnActualizar.Enabled = true;
                    btnBorrar.Enabled = dgvLibros.SelectedRows[0].Cells["colActivo"].Value?.ToString() == "Disponible";
                }
            }
            else
            {
                btnActualizar.Enabled = false;
                btnBorrar.Enabled = false;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de detalle de libro en modo creación
            using (frmDetalleLibro frm = new frmDetalleLibro())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    DatosIniciales();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de detalle de libro con los datos del libro seleccionado
            using (frmDetalleLibro frm = new frmDetalleLibro(
                new Libro
                (
                    dgvLibros.SelectedRows[0].Cells["colISBN"].Value.ToString(),
                    dgvLibros.SelectedRows[0].Cells["colTitulo"].Value.ToString(),
                    dgvLibros.SelectedRows[0].Cells["colAutor"].Value.ToString(),
                    dgvLibros.SelectedRows[0].Cells["colDescripcion"].Value.ToString(),
                    decimal.Parse(dgvLibros.SelectedRows[0].Cells["colPrecio"].Value.ToString(), NumberStyles.Currency),
                    Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["colStock"].Value),
                    dgvLibros.SelectedRows[0].Cells["colActivo"].Value.ToString() == "Disponible"
                )
            ))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DatosIniciales();
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Eliminar el libro seleccionado en el DataGridView
            string isbn = dgvLibros.SelectedRows[0].Cells["colISBN"].Value.ToString();
            Conexion conexion = new Conexion();
            conexion.EliminarLibro(isbn);
            DatosIniciales();
        }

        private void dgvLibros_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizar_Click(sender, e);
        }
    }
}
