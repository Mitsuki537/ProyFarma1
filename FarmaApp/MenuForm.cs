﻿using System;
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
        private Color originalColor;
        public MenuForm()
        {
            InitializeComponent();
            tmExpandirMenu.Interval = 15;
            tmExpandirMenu.Tick += new EventHandler(tmExpandirMenu_Tick);

            tmContraerMenu.Interval = 15;
            tmContraerMenu.Tick += new EventHandler(tmContraerMenu_Tick);
            originalColor = btnReportes.BackColor;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

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
            ProductosCategoriasForm frm = new ProductosCategoriasForm();
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(ProductosCategoriasForm frm)
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
            ProveedoresContenedorForm frm = new ProveedoresContenedorForm();
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(ProveedoresContenedorForm frm)
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

        private void btnVentas_Click(object sender, EventArgs e)
        {
            VentasContenedor frm = new VentasContenedor();
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(VentasContenedor frm)
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

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            EmpleadosForm frm = new EmpleadosForm();
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(EmpleadosForm frm)
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

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            UsuarioForm frm = new UsuarioForm();
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(UsuarioForm frm)
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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ClientesClasificacionForm frm = new ClientesClasificacionForm();
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(ClientesClasificacionForm frm)
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
    }
}
