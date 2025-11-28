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
        }
        private void Pantalla(UserControl pantalla)
        {
            pnlContainer.Controls.Clear();
            pantalla.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(pantalla);

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            UC_Productos pantalla = new UC_Productos();
            Pantalla(pantalla);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            UC_Empleados pantalla = new UC_Empleados();
            Pantalla(pantalla);
        }
    }
}
