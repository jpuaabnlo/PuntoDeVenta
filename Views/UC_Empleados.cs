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
    public partial class UC_Empleados : UserControl
    {
        public UC_Empleados()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            DatosIniciales();
            btnActualizar.Visible = Sesion.EmpleadoActual.SuperUser;
            btnBorrar.Visible = Sesion.EmpleadoActual.SuperUser;
            btnActualizar.Enabled = false;
            btnBorrar.Enabled = false;
        }

        

        private void DatosIniciales()
        {
            Conexion conexion = new Conexion();
            List<Empleado> empleados = conexion.GetEmpleadosActivos();
            LlenarGrid(empleados);
        }

        /// <summary>
        /// Metodo para llenar el DataGridView con los empleados
        /// </summary>
        private void LlenarGrid(List<Empleado> empleados)
        {
            // Lógica para llenar el DataGridView con datos de empleados
            dgvEmpleado.Rows.Clear();
            if (empleados == null)
                return;
            foreach (Empleado empleado in empleados)
            {
                dgvEmpleado.Rows.Add(
                    empleado.Id,
                    empleado.Username,
                    empleado.Nombre, 
                    empleado.Apellidos, 
                    empleado.SuperUser==true?"Administrador":"Vendedor", 
                    empleado.Activo==true?"Contratado":"Despedido"
                );
            }
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            using (frmDetalleEmpleado frm = new frmDetalleEmpleado())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    DatosIniciales();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Obtener los detalles del empleado seleccionado en el DataGridView
            Empleado empleado = new Empleado(
                    Convert.ToInt32(dgvEmpleado.SelectedRows[0].Cells["colId"].Value),
                    dgvEmpleado.SelectedRows[0].Cells["colNombre"].Value.ToString(),
                    dgvEmpleado.SelectedRows[0].Cells["colApellidos"].Value.ToString(),
                    dgvEmpleado.SelectedRows[0].Cells["colUsername"].Value.ToString(),
                    dgvEmpleado.SelectedRows[0].Cells["colTipo"].Value.ToString() == "Administrador" ? true : false,
                    dgvEmpleado.SelectedRows[0].Cells["colStatus"].Value.ToString() == "Contratado" ? true : false
                );
            using (frmDetalleEmpleado frm = new frmDetalleEmpleado(empleado))
            {
                if(frm.ShowDialog() == DialogResult.OK)
                    DatosIniciales();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del empleado seleccionado en el DataGridView
            int idSeleccionado = Convert.ToInt32(dgvEmpleado.SelectedRows[0].Cells["colId"].Value);
            Conexion conexion = new Conexion();
            conexion.EliminarEmpleado(idSeleccionado);
            DatosIniciales();
        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //if (lblNoEncontrado.Visible == true)
            //{
            //    lblNoEncontrado.Visible = false;
            //}
            //string keyword = txtBuscar.Text.Trim();
            //if (keyword == "")
            //{
            //    dgvEmpleado.Rows.Clear();
            //    llenarGrid(null);
            //    return;
            //}
            //Conexion conexion = new Conexion();
            //List<Empleado> empleados = conexion.BuscarEmpleados(keyword);
            //if (empleados == null || empleados.Count == 0)
            //{
            //    dgvEmpleado.Rows.Clear();
            //    lblNoEncontrado.Text = "No se encontraron empleados con el término \"" + keyword + "\"";
            //    lblNoEncontrado.Visible = true;
            //    return;
            //}
            //llenarGrid(empleados);

        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if(lblNoEncontrado.Visible == true)
            {
                lblNoEncontrado.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = txtBuscar.Text.Trim();

                if(keyword == "")
                {
                    dgvEmpleado.Rows.Clear();
                    DatosIniciales();
                    return;
                }

                // Buscar empleados
                Conexion conexion = new Conexion();
                List<Empleado> empleados = conexion.BuscarEmpleados(keyword);

                if(empleados == null || empleados.Count == 0)
                {
                    dgvEmpleado.Rows.Clear();
                    lblNoEncontrado.Text = "No se encontraron empleados con el término \"" + keyword + "\"";
                    lblNoEncontrado.Visible = true;
                    return;
                }

                // Llenar el grid con los empleados encontrados
                LlenarGrid(empleados);
            }
        }

        private void dgvEmpleado_SelectionChanged(object sender, EventArgs e)
        {
            // Habilitar o deshabilitar botones según la selección del DataGridView
            if(dgvEmpleado.SelectedRows.Count > 0)
            {
                if (Sesion.EmpleadoActual.SuperUser)
                {
                    btnActualizar.Enabled = true;
                    btnBorrar.Enabled = dgvEmpleado.SelectedRows[0].Cells["colStatus"].Value?.ToString() == "Contratado";
                }
            }
            else
            {
                btnActualizar.Enabled = false;
                btnBorrar.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar_KeyUp(sender, new KeyEventArgs(Keys.Enter));
        }
    }
}
