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
            btnOrdenVenta = new Button();
            btnVentas = new Button();
            pnlContenedorForm = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(49, 66, 82);
            panel1.Controls.Add(btnOrdenVenta);
            panel1.Controls.Add(btnVentas);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 71);
            panel1.TabIndex = 4;
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
            btnOrdenVenta.Location = new Point(172, -3);
            btnOrdenVenta.Margin = new Padding(3, 2, 3, 2);
            btnOrdenVenta.Name = "btnOrdenVenta";
            btnOrdenVenta.Size = new Size(176, 71);
            btnOrdenVenta.TabIndex = 17;
            btnOrdenVenta.Text = "Orden de venta";
            btnOrdenVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOrdenVenta.UseVisualStyleBackColor = false;
            btnOrdenVenta.Click += btnOrdenVenta_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.FromArgb(49, 66, 82);
            btnVentas.Cursor = Cursors.Hand;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnVentas.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            btnVentas.ForeColor = Color.Transparent;
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(2, -1);
            btnVentas.Margin = new Padding(3, 2, 3, 2);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(176, 71);
            btnVentas.TabIndex = 16;
            btnVentas.Text = "Ventas";
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
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
        private Button btnOrdenVenta;
        private Button btnVentas;
        private Panel pnlContenedorForm;
    }
}