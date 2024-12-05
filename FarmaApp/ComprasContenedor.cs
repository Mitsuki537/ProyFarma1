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
    public partial class ComprasContenedor : Form
    {
        private readonly ApiClientFarma _apiClient;

        public ComprasContenedor(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private void btnOrdenCompra_Click(object sender, EventArgs e)
        {
            OrdenCompraForm frm = new OrdenCompraForm(_apiClient);
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(OrdenCompraForm frm)
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

        private void btnDetalleOrdenCompra_Click(object sender, EventArgs e)
        {
            DetalleCompraForm frm = new DetalleCompraForm();
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(DetalleCompraForm frm)
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
