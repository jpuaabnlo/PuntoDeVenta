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
    public partial class frmDetalleLibro : Form
    {

        public frmDetalleLibro()
        {
            InitializeComponent();
            chkActivo.Checked = true;
            chkActivo.Enabled = false;
        }

        public frmDetalleLibro(Libro libro)
        {
            InitializeComponent();
            LlenarValores(libro);
        }

        public void LlenarValores(Libro libro)
        {
            // Lógica para llenar los valores del libro en el formulario
            txtISBN.Text = libro.ISBN;
            txtISBN.Enabled = false; // El ISBN no se puede cambiar
            txtTitulo.Text = libro.Nombre;
            txtAutor.Text = libro.Autor;
            txtPrecio.Text = libro.Precio.ToString();
            txtStock.Text = libro.Stock.ToString();
            txtDescripcion.Text = libro.Descripcion;
            chkActivo.Checked = libro.Activo;
            btnGuardar.Text = "Actualizar";
            btnGuardar.BackColor = Color.GreenYellow;
        }

        public bool Revision()
        {
            lblError.Visible = false;
            string isbn = txtISBN.Text.Trim();
            if (isbn == "")
            {
                txtISBN.BackColor = Color.Red;
                lblError.Text = "El campo ISBN es obligatorio.";
                lblError.Visible = true;
                return false;
            }
            else if (isbn.Length != 13)
            {
                txtISBN.BackColor = Color.Red;
                lblError.Text = "El campo ISBN debe contener 13 caracteres.";
                lblError.Visible = true;
                return false;
            }
            if (txtTitulo.Text.Trim() == "")
            {
                txtTitulo.BackColor = Color.Red;
                lblError.Text = "El campo Título es obligatorio.";
                lblError.Visible = true;
                return false;
            }
            if (txtAutor.Text.Trim() == "")
            {
                txtAutor.BackColor = Color.Red;
                lblError.Text = "El campo Autor es obligatorio.";
                lblError.Visible = true;
                return false;
            }
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0)
            {
                lblPrecio.BackColor = Color.Red;
                lblError.Text = "El campo Precio debe ser un número válido mayor o igual a 0.";
                lblError.Visible = true;
                return false;
            }
            if (!int.TryParse(txtStock.Text.Trim(), out int stock) || stock < 0)
            {
                lblStock.BackColor = Color.Red;
                lblError.Text = "El campo Stock debe ser un número entero mayor o igual a 0.";
                lblError.Visible = true;
                return false;
            }
            return true;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Revision())
            {
                return;
            }
            Conexion conexion = new Conexion();
            //Ver si el texto del boton indica creación o actualización
            if (btnGuardar.Text == "Actualizar")
            {
                conexion.ActualizarLibro(
                    new Libro(
                        txtISBN.Text.Trim(),
                        txtTitulo.Text.Trim(),
                        txtAutor.Text.Trim(),
                        txtDescripcion.Text.Trim(),
                        Convert.ToDecimal(txtPrecio.Text.Trim()),
                        Convert.ToInt32(txtStock.Text.Trim()),
                        chkActivo.Checked
                    )
                );
            }
            else
            {
                string isbn = txtISBN.Text.Trim();
                if (conexion.ExisteISBN(isbn))
                {
                    txtISBN.BackColor = Color.Red;
                    lblError.Text = "Ya existe un libro con este ISBN.";
                    lblError.Visible = true;
                    return;
                }
                conexion.CrearLibro(
                    new Libro(
                        isbn,
                        txtTitulo.Text.Trim(),
                        txtAutor.Text.Trim(),
                        txtDescripcion.Text.Trim(),
                        Convert.ToDecimal(txtPrecio.Text.Trim()),
                        Convert.ToInt32(txtStock.Text.Trim()),
                        chkActivo.Checked
                    )
                );
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtISBN_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible)
            {
                lblError.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtTitulo.Focus();
            }
            if(txtISBN.BackColor == Color.Red)
            {
                txtISBN.BackColor = Color.White;
            }
        }

        private void txtTitulo_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible) {
                lblError.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtAutor.Focus();
            }
            if(txtTitulo.BackColor == Color.Red)
            {
                txtTitulo.BackColor = Color.White;
            }
        }

        private void txtAutor_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible) {
                lblError.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtPrecio.Focus();
            }
            if(txtAutor.BackColor == Color.Red)
            {
                txtAutor.BackColor = Color.White;
            }
        }

        private void txtPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            if(lblError.Visible) {
                lblError.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtStock.Focus();
            }
            if(lblPrecio.BackColor == Color.Red)
            {
                lblPrecio.BackColor = Color.White;
            }
        }

        private void txtStock_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible) {
                lblError.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtDescripcion.Focus();
            }
            if(lblStock.BackColor == Color.Red)
            {
                lblStock.BackColor = Color.White;
            }
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible) {
                lblError.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.Focus();
            }
            if(txtDescripcion.BackColor == Color.Red)
            {
                txtDescripcion.BackColor = Color.White;
            }
        }

        private void btnGuardar_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible) {
                lblError.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.PerformClick();
            }
        }
    }
}
