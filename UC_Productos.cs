using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            DatosIniciales();
        }

        private void DatosIniciales()
        {
            Conexion conexion = new Conexion();
            List<Libro> libros = conexion.GetLibros();
            LlenarGrid(libros);
        }

        private void LlenarGrid(List<Libro> libros)
        {
            dgvLibros.Rows.Clear();
            if (libros == null)
                return;
            foreach (Libro libro in libros)
            {
                dgvLibros.Rows.Add(
                    libro.ISBN,
                    libro.Nombre,
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
                Conexion conexion = new Conexion();
                List<Libro> libros = conexion.FindLibro(keyword);
                if (libros == null || libros.Count == 0)
                {
                    dgvLibros.Rows.Clear();
                    lblErrorLibro.Text = "No se encontraron libros con el término \"" + keyword + "\"";
                    lblErrorLibro.Visible = true;
                }
                LlenarGrid(libros);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar_KeyUp(sender, new KeyEventArgs(Keys.Enter));
        }
    }
}
