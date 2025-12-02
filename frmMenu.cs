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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Opacity = 0;
            string nombre = Sesion.EmpleadoActual.Nombre;
            string apellido = Sesion.EmpleadoActual.Apellidos;
            string username = Sesion.EmpleadoActual.Username;
            lblRol.Text += " " + (Sesion.EmpleadoActual.SuperUser == true ? "Administrador" : "Vendedor");
            lblUsername.Text = lblUsername.Text + "\n" + username;
            lblNombre.Text = lblNombre.Text + "\n" + nombre + "\n" + apellido;

        }


        private void frmMenu_Shown(object sender, EventArgs e)
        {
            btnVentas.PerformClick();
            this.Opacity = 1;
        }

        private void Pantalla(UserControl pantalla)
        {
            pnlContainer.Controls.Clear();
            pantalla.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(pantalla);
        }
        private void PantallaActual(string pantalla)
        {
            if(pantalla == "Ventas")
            {
                btnVentas.Image = Properties.Resources.imgVentaSel;
                if(btnReportes.Image != Properties.Resources.imgReporte)
                    btnReportes.Image = Properties.Resources.imgReporte;
                if (btnProductos.Image != Properties.Resources.imgLibro)
                    btnProductos.Image = Properties.Resources.imgLibro;
                if (btnEmpleados.Image != Properties.Resources.imgEmpleado)
                    btnEmpleados.Image = Properties.Resources.imgEmpleado;
                btnVentas.Enabled = false;
                btnReportes.Enabled = true;
                btnProductos.Enabled = true;
                btnEmpleados.Enabled = true;
            }
            else if(pantalla == "Reportes")
            {
                btnReportes.Image = Properties.Resources.imgReporteSel;
                if (btnVentas.Image != Properties.Resources.imgVenta)
                    btnReportes.Image = Properties.Resources.imgReporte;
                if (btnProductos.Image != Properties.Resources.imgLibro)
                    btnProductos.Image = Properties.Resources.imgLibro;
                if (btnEmpleados.Image != Properties.Resources.imgEmpleado)
                    btnEmpleados.Image = Properties.Resources.imgEmpleado;
                btnVentas.Enabled = true;
                btnReportes.Enabled = false;
                btnProductos.Enabled = true;
                btnEmpleados.Enabled = true;
            }
            else if (pantalla == "Productos")
            {
                btnProductos.Image = Properties.Resources.imgLibroSel;
                if (btnVentas.Image != Properties.Resources.imgVenta)
                    btnVentas.Image = Properties.Resources.imgVenta;
                if (btnReportes.Image != Properties.Resources.imgReporte)
                    btnReportes.Image = Properties.Resources.imgReporte;
                if (btnEmpleados.Image != Properties.Resources.imgEmpleado)
                    btnEmpleados.Image = Properties.Resources.imgEmpleado;
                btnVentas.Enabled = true;
                btnReportes.Enabled = true;
                btnProductos.Enabled = false;
                btnEmpleados.Enabled = true;
            }
            else if (pantalla == "Empleados")
            {
                btnEmpleados.Image = Properties.Resources.imgEmpleadoSel;
                if (btnVentas.Image != Properties.Resources.imgVenta)
                    btnVentas.Image = Properties.Resources.imgVenta;
                if (btnReportes.Image != Properties.Resources.imgReporte)
                    btnReportes.Image = Properties.Resources.imgReporte;
                if (btnProductos.Image != Properties.Resources.imgLibro)
                    btnProductos.Image = Properties.Resources.imgLibro;
                btnVentas.Enabled = true;
                btnReportes.Enabled = true;
                btnProductos.Enabled = true;
                btnEmpleados.Enabled = false;
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
             PantallaActual("Ventas");
            UC_Ventas pantalla = new UC_Ventas();
            Pantalla(pantalla);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            PantallaActual("Productos");
            UC_Productos pantalla = new UC_Productos();
            Pantalla(pantalla);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            PantallaActual("Empleados");
            UC_Empleados pantalla = new UC_Empleados();
            Pantalla(pantalla);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
