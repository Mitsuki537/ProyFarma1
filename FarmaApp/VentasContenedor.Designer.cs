namespace FarmaApp
{
    partial class VentasContenedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnDetalleOrdenVenta = new Button();
            btnOrdenVenta = new Button();
            pnlContenedorForm = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(49, 66, 82);
            panel1.Controls.Add(btnDetalleOrdenVenta);
            panel1.Controls.Add(btnOrdenVenta);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 71);
            panel1.TabIndex = 4;
            // 
            // btnDetalleOrdenVenta
            // 
            btnDetalleOrdenVenta.BackColor = Color.FromArgb(49, 66, 82);
            btnDetalleOrdenVenta.Cursor = Cursors.Hand;
            btnDetalleOrdenVenta.FlatAppearance.BorderSize = 0;
            btnDetalleOrdenVenta.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnDetalleOrdenVenta.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnDetalleOrdenVenta.FlatStyle = FlatStyle.Flat;
            btnDetalleOrdenVenta.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            btnDetalleOrdenVenta.ForeColor = Color.Transparent;
            btnDetalleOrdenVenta.ImageAlign = ContentAlignment.MiddleLeft;
            btnDetalleOrdenVenta.Location = new Point(172, -1);
            btnDetalleOrdenVenta.Margin = new Padding(3, 2, 3, 2);
            btnDetalleOrdenVenta.Name = "btnDetalleOrdenVenta";
            btnDetalleOrdenVenta.Size = new Size(207, 69);
            btnDetalleOrdenVenta.TabIndex = 17;
            btnDetalleOrdenVenta.Text = "Detalle de Orden Venta";
            btnDetalleOrdenVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDetalleOrdenVenta.UseVisualStyleBackColor = false;
            btnDetalleOrdenVenta.Click += btnOrdenVenta_Click;
            // 
            // btnOrdenVenta
            // 
            btnOrdenVenta.BackColor = Color.FromArgb(49, 66, 82);
            btnOrdenVenta.Cursor = Cursors.Hand;
            btnOrdenVenta.FlatAppearance.BorderSize = 0;
            btnOrdenVenta.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnOrdenVenta.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnOrdenVenta.FlatStyle = FlatStyle.Flat;
            btnOrdenVenta.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            btnOrdenVenta.ForeColor = Color.Transparent;
            btnOrdenVenta.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrdenVenta.Location = new Point(2, -1);
            btnOrdenVenta.Margin = new Padding(3, 2, 3, 2);
            btnOrdenVenta.Name = "btnOrdenVenta";
            btnOrdenVenta.Size = new Size(176, 71);
            btnOrdenVenta.TabIndex = 16;
            btnOrdenVenta.Text = "Orden de Venta";
            btnOrdenVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOrdenVenta.UseVisualStyleBackColor = false;
            btnOrdenVenta.Click += btnVentas_Click;
            // 
            // pnlContenedorForm
            // 
            pnlContenedorForm.Dock = DockStyle.Fill;
            pnlContenedorForm.Location = new Point(0, 71);
            pnlContenedorForm.Name = "pnlContenedorForm";
            pnlContenedorForm.Size = new Size(1100, 544);
            pnlContenedorForm.TabIndex = 5;
            // 
            // VentasContenedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 615);
            Controls.Add(pnlContenedorForm);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VentasContenedor";
            Text = "VentasContenedor";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnDetalleOrdenVenta;
        private Button btnOrdenVenta;
        private Panel pnlContenedorForm;
    }
}