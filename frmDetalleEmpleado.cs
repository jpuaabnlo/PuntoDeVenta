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
    /// <summary>
    /// Represents a form for creating or updating employee details.
    /// </summary>
    /// <remarks>This form allows users to input and modify employee information, including name, username, 
    /// password, and status. It supports both creating new employees and updating existing ones. The form validates
    /// input fields, such as ensuring passwords match and checking for duplicate usernames.</remarks>
    public partial class frmDetalleEmpleado : Form
    {
        private int? idEmpleado = null;
        
        public frmDetalleEmpleado()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmDetalleEmpleado"/> class with the specified employee
        /// details.
        /// </summary>
        /// <remarks>This constructor initializes the form, makes the status checkbox visible, and
        /// populates the form fields with the values from the provided <paramref name="empleado"/> object. The
        /// employee's ID is also stored for further use.</remarks>
        /// <param name="empleado">The <see cref="Empleado"/> object containing the details of the employee to display.</param>
        public frmDetalleEmpleado(Empleado empleado)
        {
            InitializeComponent();
            chkStatus.Visible = true;
            LlenarValores(empleado);
            this.idEmpleado = empleado.Id;
        }


        public void LlenarValores(Empleado empleado)
        {
            // Lógica para llenar los valores del empleado en el formulario
            txtNombre.Text = empleado.Nombre;
            txtApellidos.Text = empleado.Apellidos;
            txtUsername.Text = empleado.Username;
            chkSuperUser.Checked = empleado.SuperUser;
            chkStatus.Checked = empleado.Activo;
            btnGuardar.Text = "Actualizar";
            btnGuardar.BackColor = Color.GreenYellow;
        }

        private bool Verificar()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            if (username == "")
            {
                txtUsername.BackColor = Color.Red;
                lblError.Text = "El campo Usuario es obligatorio.";
                lblError.Visible = true;
                return false;
            }
            if(txtNombre.Text.Trim() == "")
            {
                txtNombre.BackColor = Color.Red;
                lblError.Text = "El campo Nombre es obligatorio.";
                lblError.Visible = true;
                return false;
            }
            if (txtApellidos.Text.Trim() == "")
            {
                txtApellidos.BackColor = Color.Red;
                lblError.Text = "El campo Apellidos es obligatorio.";
                lblError.Visible = true;
                return false;
            }
            if (password != confirmPassword)
            {
                txtPassword.BackColor = Color.Red;
                txtConfirmPassword.BackColor = Color.Red;
                lblError.Text = "Las contraseñas no coinciden.";
                lblError.Visible = true;
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Verificar()) 
                return;
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            if(idEmpleado.HasValue)
            {
                // Lógica para actualizar empleado existente
                Conexion conexion = new Conexion();
                conexion.ActualizarEmpleado(
                    new Empleado(
                        idEmpleado.Value,
                        txtNombre.Text.Trim(),
                        txtApellidos.Text.Trim(),
                        txtUsername.Text.Trim(),
                        password,
                        chkSuperUser.Checked,
                        chkStatus.Checked
                    )
                );
                MessageBox.Show("Empleado actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Lógica para crear nuevo empleado
                string username = txtUsername.Text.Trim();
                Conexion conexion = new Conexion();
                if (conexion.VerificarUsername(username))
                {
                    txtUsername.BackColor = Color.Red;
                    lblError.Visible = true;
                    return;
                }
                conexion.CrearEmpleado(
                    new Empleado(
                        0,
                        txtNombre.Text.Trim(),
                        txtApellidos.Text.Trim(),
                        username,
                        password,
                        chkSuperUser.Checked,
                        chkStatus.Checked
                    )
                );
                MessageBox.Show("Empleado creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }



        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible == true)
            {
                lblError.Visible = false;
                if (txtNombre.BackColor == Color.Red)
                {
                    txtNombre.BackColor = SystemColors.Window;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtApellidos.Focus();
            }
        }
        private void txtApellidos_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible == true)
            {
                lblError.Visible = false;
                if (txtApellidos.BackColor == Color.Red)
                {
                    txtApellidos.BackColor = SystemColors.Window;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtUsername.Focus();
            }
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible == true)
            {
                lblError.Visible = false;
                if (txtUsername.BackColor == Color.Red)
                {
                    txtUsername.BackColor = SystemColors.Window;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible == true)
            {
                lblError.Visible = false;
                if (txtPassword.BackColor == Color.Red)
                {
                    txtPassword.BackColor = SystemColors.Window;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtConfirmPassword.Focus();
            }
        }

        private void txtConfirmPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblError.Visible == true)
            {
                lblError.Visible = false;
                if (txtConfirmPassword.BackColor == Color.Red)
                {
                    txtConfirmPassword.BackColor = SystemColors.Window;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                chkSuperUser.Focus();
            }
        }

        private void chkSuperUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.Focus();
            }
        }

        private void btnGuardar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.PerformClick();
            }
        }

    }
}
