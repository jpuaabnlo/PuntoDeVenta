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

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            string tipoReporte = "";
            DateTime ini = dtpInicio.Value;
            DateTime fin = dtpFin.Value;

            
            if (ini.Date > fin.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha fin.", "Error de fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Asigna el tipo de Reporte a generar
            if(chkLibros.Checked)
            {
                tipoReporte = "LibrosVendidos";
            }
            else if (chkEmpleados.Checked)
            {
                tipoReporte = "EmpleadosRanking";
            }
            else
            {
                MessageBox.Show("Seleccione un tipo de reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Se genera la tabla del tipo y se regresa como párametro
            Conexion conexion = new Conexion();
            DataTable reporteVentas = conexion.GenerarReporteVentas(ini, fin, tipoReporte);

            if(reporteVentas.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos para el rango de fechas seleccionado.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dgvReporte.DataSource = reporteVentas;
                dgvReporte.AutoResizeColumns();
            }
        }
    }
}
