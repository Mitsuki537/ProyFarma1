namespace FarmaApp
{
    partial class ComprasContenedor
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
            btnOrdenCompra = new Button();
            btnDetalleOrdenCompra = new Button();
            pnlContenedorForm = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(49, 66, 82);
            panel1.Controls.Add(btnOrdenCompra);
            panel1.Controls.Add(btnDetalleOrdenCompra);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 71);
            panel1.TabIndex = 4;
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
            btnOrdenCompra.Location = new Point(2, 0);
            btnOrdenCompra.Margin = new Padding(3, 2, 3, 2);
            btnOrdenCompra.Name = "btnOrdenCompra";
            btnOrdenCompra.Size = new Size(176, 71);
            btnOrdenCompra.TabIndex = 14;
            btnOrdenCompra.Text = "Orden de Compra";
            btnOrdenCompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOrdenCompra.UseVisualStyleBackColor = false;
            btnOrdenCompra.Click += btnOrdenCompra_Click;
            // 
            // btnDetalleOrdenCompra
            // 
            btnDetalleOrdenCompra.BackColor = Color.FromArgb(49, 66, 82);
            btnDetalleOrdenCompra.Cursor = Cursors.Hand;
            btnDetalleOrdenCompra.FlatAppearance.BorderSize = 0;
            btnDetalleOrdenCompra.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnDetalleOrdenCompra.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnDetalleOrdenCompra.FlatStyle = FlatStyle.Flat;
            btnDetalleOrdenCompra.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            btnDetalleOrdenCompra.ForeColor = Color.Transparent;
            btnDetalleOrdenCompra.ImageAlign = ContentAlignment.MiddleLeft;
            btnDetalleOrdenCompra.Location = new Point(184, -2);
            btnDetalleOrdenCompra.Margin = new Padding(3, 2, 3, 2);
            btnDetalleOrdenCompra.Name = "btnDetalleOrdenCompra";
            btnDetalleOrdenCompra.Size = new Size(229, 71);
            btnDetalleOrdenCompra.TabIndex = 13;
            btnDetalleOrdenCompra.Text = "Detalle de Orden de Compra";
            btnDetalleOrdenCompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDetalleOrdenCompra.UseVisualStyleBackColor = false;
            btnDetalleOrdenCompra.Click += btnDetalleOrdenCompra_Click;
            // 
            // pnlContenedorForm
            // 
            pnlContenedorForm.Dock = DockStyle.Fill;
            pnlContenedorForm.Location = new Point(0, 71);
            pnlContenedorForm.Name = "pnlContenedorForm";
            pnlContenedorForm.Size = new Size(1100, 544);
            pnlContenedorForm.TabIndex = 5;
            // 
            // ComprasContenedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 615);
            Controls.Add(pnlContenedorForm);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ComprasContenedor";
            Text = "ComprasContenedor";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnOrdenCompra;
        private Button btnDetalleOrdenCompra;
        private Panel pnlContenedorForm;
    }
}