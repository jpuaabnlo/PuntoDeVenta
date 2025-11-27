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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            Conexion conexion = new Conexion();
            Empleado empleado = conexion.FindUser(username, password);
            if (empleado != null)
            {
                if (empleado.isActivo())
                {
                    frmMenu menu = new frmMenu();
                    menu.Show();
                }
                else
                {
                    lblLogError.Text = "El usuario no está activo.";
                    lblLogError.Visible = true;
                }
            }
            else
            {
                lblLogError.Text = "Usuario o contraseña incorrectos.";
                lblLogError.Visible = true;
            }
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if(lblLogError.Visible == true)
            {
                lblLogError.Visible = false;
            }
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblLogError.Visible == true)
            {
                lblLogError.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnLogIn_Click(sender, e);
            }
        }

        private void btnLogIn_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogIn_Click(sender, e);
            }
        }
    }
}
