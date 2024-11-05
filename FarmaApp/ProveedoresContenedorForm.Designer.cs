namespace FarmaApp
{
    partial class ProveedoresContenedorForm
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
            btnDetalleCompra = new Button();
            btnOrdenCompra = new Button();
            btnProveedores = new Button();
            pnlContenedorForm = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(49, 66, 82);
            panel1.Controls.Add(btnDetalleCompra);
            panel1.Controls.Add(btnOrdenCompra);
            panel1.Controls.Add(btnProveedores);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 71);
            panel1.TabIndex = 2;
            // 
            // btnDetalleCompra
            // 
            btnDetalleCompra.BackColor = Color.FromArgb(49, 66, 82);
            btnDetalleCompra.Cursor = Cursors.Hand;
            btnDetalleCompra.FlatAppearance.BorderSize = 0;
            btnDetalleCompra.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnDetalleCompra.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnDetalleCompra.FlatStyle = FlatStyle.Flat;
            btnDetalleCompra.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            btnDetalleCompra.ForeColor = Color.Transparent;
            btnDetalleCompra.ImageAlign = ContentAlignment.MiddleLeft;
            btnDetalleCompra.Location = new Point(366, 1);
            btnDetalleCompra.Margin = new Padding(3, 2, 3, 2);
            btnDetalleCompra.Name = "btnDetalleCompra";
            btnDetalleCompra.Size = new Size(176, 67);
            btnDetalleCompra.TabIndex = 17;
            btnDetalleCompra.Text = "Detalle de compra";
            btnDetalleCompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDetalleCompra.UseVisualStyleBackColor = false;
            btnDetalleCompra.Click += btnDetalleCompra_Click;
            // 
            // btnOrdenCompra
            // 
            btnOrdenCompra.BackColor = Color.FromArgb(49, 66, 82);
            btnOrdenCompra.Cursor = Cursors.Hand;
            btnOrdenCompra.FlatAppearance.BorderSize = 0;
            btnOrdenCompra.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnOrdenCompra.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnOrdenCompra.FlatStyle = FlatStyle.Flat;
            btnOrdenCompra.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            btnOrdenCompra.ForeColor = Color.Transparent;
            btnOrdenCompra.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrdenCompra.Location = new Point(184, 1);
            btnOrdenCompra.Margin = new Padding(3, 2, 3, 2);
            btnOrdenCompra.Name = "btnOrdenCompra";
            btnOrdenCompra.Size = new Size(176, 67);
            btnOrdenCompra.TabIndex = 16;
            btnOrdenCompra.Text = "Orden de compra";
            btnOrdenCompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOrdenCompra.UseVisualStyleBackColor = false;
            btnOrdenCompra.Click += btnOrdenCompra_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.BackColor = Color.FromArgb(49, 66, 82);
            btnProveedores.Cursor = Cursors.Hand;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnProveedores.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            btnProveedores.ForeColor = Color.Transparent;
            btnProveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btnProveedores.Location = new Point(2, 1);
            btnProveedores.Margin = new Padding(3, 2, 3, 2);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(176, 67);
            btnProveedores.TabIndex = 15;
            btnProveedores.Text = "Proveedores";
            btnProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // pnlContenedorForm
            // 
            pnlContenedorForm.Dock = DockStyle.Fill;
            pnlContenedorForm.Location = new Point(0, 71);
            pnlContenedorForm.Name = "pnlContenedorForm";
            pnlContenedorForm.Size = new Size(1100, 544);
            pnlContenedorForm.TabIndex = 3;
            // 
            // ProveedoresContenedorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 615);
            Controls.Add(pnlContenedorForm);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProveedoresContenedorForm";
            Text = "ProveedoresContenedor";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnOrdenCompra;
        private Button btnProveedores;
        private Button btnDetalleCompra;
        private Panel pnlContenedorForm;
    }
}