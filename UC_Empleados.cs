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
            llenarGrid();
        }
        /// <summary>
        /// Metodo para llenar el DataGridView con los empleados
        /// </summary>
        private void llenarGrid()
        {
            // Lógica para llenar el DataGridView con datos de empleados

        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }
    }
}
