using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;   // ← IMPORTANTE

namespace PuntoDeVenta
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();

            // Opcional: formato inicial del DataGrid
            ConfigurarTabla();
        }

        private void ConfigurarTabla()
        {
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToResizeRows = false;

            dgvReporte.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cn = Conexion.GetConnection())
                {
                    cn.Open();

                    string query = @"SELECT 
                                        e.clave AS 'Clave',
                                        e.nombre AS 'Nombre',
                                        SUM(v.total) AS 'Monto Vendido'
                                     FROM empleados e
                                     INNER JOIN ventas v ON v.clave_empleado = e.clave
                                     WHERE v.fecha BETWEEN @inicio AND @fin
                                     GROUP BY e.clave, e.nombre
                                     ORDER BY `Monto Vendido` DESC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);

                    // Parámetros
                    cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@fin", dtpFin.Value.ToString("yyyy-MM-dd"));

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReporte.DataSource = dt;

                    // Formato de moneda
                    if (dgvReporte.Columns.Contains("Monto Vendido"))
                    {
                        dgvReporte.Columns["Monto Vendido"].DefaultCellStyle.Format = "C2";
                        dgvReporte.Columns["Monto Vendido"].DefaultCellStyle.Alignment =
                            DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

