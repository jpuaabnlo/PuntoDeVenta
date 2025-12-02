using System;
using System.Data;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class UC_Reportes : UserControl
    {
        public UC_Reportes()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtpInicio.Value.Date;
            DateTime fin = dtpFin.Value.Date;

            if (inicio > fin)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final.",
                    "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Conexion conexion = new Conexion();
            DataTable tabla = conexion.GenerarReporteVentas(inicio, fin);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron ventas en ese periodo.",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvReportes.DataSource = tabla;
        }
    }
}
