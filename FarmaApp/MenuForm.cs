using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace FarmaApp
{
    public partial class MenuForm : Form
    {
        public string Token { get; set; }
        private Color originalColor;
        private readonly ApiClientFarma _apiClient;
        public MenuForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            tmExpandirMenu.Interval = 15;
            tmExpandirMenu.Tick += new EventHandler(tmExpandirMenu_Tick);

            tmContraerMenu.Interval = 15;
            tmContraerMenu.Tick += new EventHandler(tmContraerMenu_Tick);
            originalColor = btnReportes.BackColor;
            _apiClient = apiClient;
        }

        private void tmExpandirMenu_Tick(object sender, EventArgs e)
        {
            if (pnlDashboard.Width >= 200)
                tmExpandirMenu.Stop();
            else
                pnlDashboard.Width += 5;
        }

        private void tmContraerMenu_Tick(object sender, EventArgs e)
        {
            if (pnlDashboard.Width <= 55)
                tmContraerMenu.Stop();
            else
                pnlDashboard.Width -= 5;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            pnlSubReportes.Visible = !pnlSubReportes.Visible;
            if (pnlSubReportes.Visible)
            {
                btnReportes.BackColor = Color.FromArgb(0, 80, 200);
            }
            else
            {
                btnReportes.BackColor = originalColor;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (pnlDashboard.Width == 200)
                tmContraerMenu.Start();
            else if (pnlDashboard.Width == 55)
                tmExpandirMenu.Start();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ProductosCategoriasForm frm = new ProductosCategoriasForm(_apiClient);
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(Form frm)
        {
            if (pnlContenedorForm.Controls.Count > 0)
                pnlContenedorForm.Controls.RemoveAt(0);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContenedorForm.Controls.Add(frm);
            pnlContenedorForm.Tag = frm;
            frm.Show();
        }

        private void btnRegistroUsuarioForm_Click(object sender, EventArgs e)
        {
            ProveedoresForm frm = new ProveedoresForm(_apiClient);
            AbrirFormEnPanel(frm);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            VentasContenedor frm = new VentasContenedor();
            AbrirFormEnPanel(frm);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            EmpleadosForm frm = new EmpleadosForm(_apiClient);
            AbrirFormEnPanel(frm);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ClientesForm frm = new ClientesForm();
            AbrirFormEnPanel(frm);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            ComprasContenedor frm = new ComprasContenedor();
            AbrirFormEnPanel(frm);
        }

        private void btnUsuario_Click_1(object sender, EventArgs e)
        {
            UsuarioForm frm = new UsuarioForm(_apiClient);
            AbrirFormEnPanel(frm);
        }
    }
}

