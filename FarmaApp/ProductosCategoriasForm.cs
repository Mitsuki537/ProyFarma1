using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaApp
{
    public partial class ProductosCategoriasForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        public ProductosCategoriasForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ProductosForm frm = new ProductosForm(_apiClient);
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(ProductosForm frm)
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

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            CategoriasForm frm = new CategoriasForm(_apiClient);
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(CategoriasForm frm)
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
