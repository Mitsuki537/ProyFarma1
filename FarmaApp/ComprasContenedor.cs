﻿using System;
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
        public ComprasContenedor()
        {
            InitializeComponent();
        }

        private void btnOrdenCompra_Click(object sender, EventArgs e)
        {
            DetalleOrdenVentaForm frm = new DetalleOrdenVentaForm();
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(DetalleOrdenVentaForm frm)
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