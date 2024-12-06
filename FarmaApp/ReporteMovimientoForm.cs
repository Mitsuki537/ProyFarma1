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
    public partial class ReporteMovimientoForm : Form
    {
        private string connectionString = "Server=.;Database=BD_FarmaControl;Trusted_Connection=True;TrustServerCertificate=True;";

        public ReporteMovimientoForm()
        {
            InitializeComponent();
            LoadInventoryIds();
        }
        private void LoadInventoryIds()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT DISTINCT Id_Inventory FROM [Inventory].[InventoryMovements]"; // Cargar solo IDs de inventario únicos
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cboInventoryId.Items.Add(reader["Id_Inventory"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los IDs de inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterByInventory_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboInventoryId.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un ID de inventario para filtrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int inventoryId = Convert.ToInt32(cboInventoryId.SelectedItem);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM [Inventory].[InventoryMovements] WHERE Id_Inventory = @Id_Inventory";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id_Inventory", inventoryId);
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvMovements.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowAllMovements_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM [Inventory].[InventoryMovements]";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvMovements.DataSource = dt; 
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
