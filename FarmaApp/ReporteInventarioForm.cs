using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaApp
{
    public partial class ReporteInventarioForm : Form
    {
        private string connectionString = "Server=.;Database=BD_FarmaControl;Trusted_Connection=True;TrustServerCertificate=True;";
        public ReporteInventarioForm()
        {
            InitializeComponent();
        }

        private void btnTopSellingProducts_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTop.Text) || !int.TryParse(txtTop.Text, out int topValue) || topValue <= 0)
                {
                    MessageBox.Show("Por favor, ingresa un número válido para el Top.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ExecuteProcedureWithTop("sp_GetTopSellingProducts", topValue, dgvResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLowStockProducts_Click(object sender, EventArgs e)
        {
            try
            {
                ExecuteProcedure("sp_GetLowStockProducts", dgvResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExpiringProducts_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDias.Text) || !int.TryParse(txtDias.Text, out int dias) || dias <= 0)
                {
                    MessageBox.Show("Por favor, ingresa un número válido para los días.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ExecuteProcedureWithDias("sp_ProductosProximosAExpirar", dias, dgvResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ExecuteProcedure(string procedureName, DataGridView dgv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
        }

        private void ExecuteProcedureWithTop(string procedureName, int topValue, DataGridView dgv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartDate", new DateTime(2024, 1, 1));
                    cmd.Parameters.AddWithValue("@EndDate", new DateTime(2024, 12, 31));
                    cmd.Parameters.AddWithValue("@Top", topValue);

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
        }
        private void ExecuteProcedureWithDias(string procedureName, int dias, DataGridView dgv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dias", dias);

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
        }

        private void btnGetAllInventory_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM [Inventory].[Inventories]";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvResults.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
