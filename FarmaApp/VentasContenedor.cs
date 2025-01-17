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
    public partial class VentasContenedor : Form
    {
        private readonly ApiClientFarma _apiClient;
        public VentasContenedor(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient; 
        }

        private void btnOrdenVenta_Click(object sender, EventArgs e)
        {
            DetalleOrdenVentaForm frm = new DetalleOrdenVentaForm(_apiClient);
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

        private void btnVentas_Click(object sender, EventArgs e)
        {
            OrdenVentaForm frm = new OrdenVentaForm(_apiClient);
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(OrdenVentaForm frm)
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
