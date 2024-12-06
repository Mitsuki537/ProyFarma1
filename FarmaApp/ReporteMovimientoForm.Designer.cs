namespace FarmaApp
{
    partial class ReporteMovimientoForm
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
            label1 = new Label();
            panel2 = new Panel();
            btnFilterByInventory = new Button();
            btnShowAllMovements = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dgvMovements = new DataGridView();
            cboInventoryId = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(49, 66, 82);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 79);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 25);
            label1.Name = "label1";
            label1.Size = new Size(240, 30);
            label1.TabIndex = 0;
            label1.Text = "Reporte de Movimientos";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(49, 66, 82);
            panel2.Controls.Add(btnFilterByInventory);
            panel2.Controls.Add(btnShowAllMovements);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(915, 79);
            panel2.Name = "panel2";
            panel2.Size = new Size(185, 536);
            panel2.TabIndex = 44;
            // 
            // btnFilterByInventory
            // 
            btnFilterByInventory.Cursor = Cursors.Hand;
            btnFilterByInventory.FlatAppearance.BorderSize = 0;
            btnFilterByInventory.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnFilterByInventory.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnFilterByInventory.FlatStyle = FlatStyle.Flat;
            btnFilterByInventory.Font = new Font("Segoe UI", 12F);
            btnFilterByInventory.ForeColor = SystemColors.Window;
            btnFilterByInventory.ImageAlign = ContentAlignment.MiddleLeft;
            btnFilterByInventory.Location = new Point(0, 55);
            btnFilterByInventory.Margin = new Padding(3, 2, 3, 2);
            btnFilterByInventory.Name = "btnFilterByInventory";
            btnFilterByInventory.Size = new Size(185, 46);
            btnFilterByInventory.TabIndex = 42;
            btnFilterByInventory.Text = "Filtrar Datos";
            btnFilterByInventory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFilterByInventory.UseVisualStyleBackColor = true;
            btnFilterByInventory.Click += btnFilterByInventory_Click;
            // 
            // btnShowAllMovements
            // 
            btnShowAllMovements.Cursor = Cursors.Hand;
            btnShowAllMovements.FlatAppearance.BorderSize = 0;
            btnShowAllMovements.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnShowAllMovements.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnShowAllMovements.FlatStyle = FlatStyle.Flat;
            btnShowAllMovements.Font = new Font("Segoe UI", 12F);
            btnShowAllMovements.ForeColor = SystemColors.Window;
            btnShowAllMovements.ImageAlign = ContentAlignment.MiddleLeft;
            btnShowAllMovements.Location = new Point(0, 5);
            btnShowAllMovements.Margin = new Padding(3, 2, 3, 2);
            btnShowAllMovements.Name = "btnShowAllMovements";
            btnShowAllMovements.Size = new Size(185, 46);
            btnShowAllMovements.TabIndex = 40;
            btnShowAllMovements.Text = "Todos los registros";
            btnShowAllMovements.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnShowAllMovements.UseVisualStyleBackColor = true;
            btnShowAllMovements.Click += btnShowAllMovements_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dgvMovements
            // 
            dgvMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovements.Location = new Point(132, 223);
            dgvMovements.Name = "dgvMovements";
            dgvMovements.Size = new Size(643, 208);
            dgvMovements.TabIndex = 45;
            // 
            // cboInventoryId
            // 
            cboInventoryId.FormattingEnabled = true;
            cboInventoryId.Location = new Point(132, 466);
            cboInventoryId.Name = "cboInventoryId";
            cboInventoryId.Size = new Size(121, 23);
            cboInventoryId.TabIndex = 46;
            // 
            // ReporteMovimientoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 615);
            Controls.Add(cboInventoryId);
            Controls.Add(dgvMovements);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReporteMovimientoForm";
            Text = "ReporteMovimientoForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovements).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnFilterByInventory;
        private Button btnShowAllMovements;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DataGridView dgvMovements;
        private ComboBox cboInventoryId;
    }
}