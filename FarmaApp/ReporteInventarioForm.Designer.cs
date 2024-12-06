namespace FarmaApp
{
    partial class ReporteInventarioForm
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
            dgvResults = new DataGridView();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            panel2 = new Panel();
            btnExpiringProducts = new Button();
            btnTopSellingProducts = new Button();
            btnLowStockProducts = new Button();
            btnGetAllInventory = new Button();
            label2 = new Label();
            label3 = new Label();
            txtDias = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtTop = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            panel2.SuspendLayout();
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
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 25);
            label1.Name = "label1";
            label1.Size = new Size(222, 30);
            label1.TabIndex = 0;
            label1.Text = "Reporte de Inventarios";
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(134, 158);
            dgvResults.Name = "dgvResults";
            dgvResults.Size = new Size(643, 208);
            dgvResults.TabIndex = 1;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 12F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(283, 452);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(160, 29);
            dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 12F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(620, 452);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(160, 29);
            dtpEndDate.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(49, 66, 82);
            panel2.Controls.Add(btnExpiringProducts);
            panel2.Controls.Add(btnTopSellingProducts);
            panel2.Controls.Add(btnLowStockProducts);
            panel2.Controls.Add(btnGetAllInventory);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(915, 79);
            panel2.Name = "panel2";
            panel2.Size = new Size(185, 536);
            panel2.TabIndex = 43;
            // 
            // btnExpiringProducts
            // 
            btnExpiringProducts.Cursor = Cursors.Hand;
            btnExpiringProducts.FlatAppearance.BorderSize = 0;
            btnExpiringProducts.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnExpiringProducts.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnExpiringProducts.FlatStyle = FlatStyle.Flat;
            btnExpiringProducts.Font = new Font("Segoe UI", 12F);
            btnExpiringProducts.ForeColor = SystemColors.Window;
            btnExpiringProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnExpiringProducts.Location = new Point(3, 155);
            btnExpiringProducts.Margin = new Padding(3, 2, 3, 2);
            btnExpiringProducts.Name = "btnExpiringProducts";
            btnExpiringProducts.Size = new Size(182, 46);
            btnExpiringProducts.TabIndex = 43;
            btnExpiringProducts.Text = "Próximos a expiración";
            btnExpiringProducts.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExpiringProducts.UseVisualStyleBackColor = true;
            btnExpiringProducts.Click += btnExpiringProducts_Click;
            // 
            // btnTopSellingProducts
            // 
            btnTopSellingProducts.Cursor = Cursors.Hand;
            btnTopSellingProducts.FlatAppearance.BorderSize = 0;
            btnTopSellingProducts.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnTopSellingProducts.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnTopSellingProducts.FlatStyle = FlatStyle.Flat;
            btnTopSellingProducts.Font = new Font("Segoe UI", 12F);
            btnTopSellingProducts.ForeColor = SystemColors.Window;
            btnTopSellingProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnTopSellingProducts.Location = new Point(0, 105);
            btnTopSellingProducts.Margin = new Padding(3, 2, 3, 2);
            btnTopSellingProducts.Name = "btnTopSellingProducts";
            btnTopSellingProducts.Size = new Size(185, 46);
            btnTopSellingProducts.TabIndex = 41;
            btnTopSellingProducts.Text = "Mayor rotación";
            btnTopSellingProducts.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTopSellingProducts.UseVisualStyleBackColor = true;
            btnTopSellingProducts.Click += btnTopSellingProducts_Click;
            // 
            // btnLowStockProducts
            // 
            btnLowStockProducts.Cursor = Cursors.Hand;
            btnLowStockProducts.FlatAppearance.BorderSize = 0;
            btnLowStockProducts.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnLowStockProducts.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnLowStockProducts.FlatStyle = FlatStyle.Flat;
            btnLowStockProducts.Font = new Font("Segoe UI", 12F);
            btnLowStockProducts.ForeColor = SystemColors.Window;
            btnLowStockProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnLowStockProducts.Location = new Point(0, 55);
            btnLowStockProducts.Margin = new Padding(3, 2, 3, 2);
            btnLowStockProducts.Name = "btnLowStockProducts";
            btnLowStockProducts.Size = new Size(185, 46);
            btnLowStockProducts.TabIndex = 42;
            btnLowStockProducts.Text = "Bajo stock";
            btnLowStockProducts.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLowStockProducts.UseVisualStyleBackColor = true;
            btnLowStockProducts.Click += btnLowStockProducts_Click;
            // 
            // btnGetAllInventory
            // 
            btnGetAllInventory.Cursor = Cursors.Hand;
            btnGetAllInventory.FlatAppearance.BorderSize = 0;
            btnGetAllInventory.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnGetAllInventory.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnGetAllInventory.FlatStyle = FlatStyle.Flat;
            btnGetAllInventory.Font = new Font("Segoe UI", 12F);
            btnGetAllInventory.ForeColor = SystemColors.Window;
            btnGetAllInventory.ImageAlign = ContentAlignment.MiddleLeft;
            btnGetAllInventory.Location = new Point(0, 5);
            btnGetAllInventory.Margin = new Padding(3, 2, 3, 2);
            btnGetAllInventory.Name = "btnGetAllInventory";
            btnGetAllInventory.Size = new Size(185, 46);
            btnGetAllInventory.TabIndex = 40;
            btnGetAllInventory.Text = "Todos los registros";
            btnGetAllInventory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGetAllInventory.UseVisualStyleBackColor = true;
            btnGetAllInventory.Click += btnGetAllInventory_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(134, 458);
            label2.Name = "label2";
            label2.Size = new Size(128, 21);
            label2.TabIndex = 44;
            label2.Text = "Fecha de entrada";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(500, 458);
            label3.Name = "label3";
            label3.Size = new Size(114, 21);
            label3.TabIndex = 45;
            label3.Text = "Fecha de cierre";
            // 
            // txtDias
            // 
            txtDias.Font = new Font("Segoe UI", 12F);
            txtDias.Location = new Point(283, 505);
            txtDias.Name = "txtDias";
            txtDias.Size = new Size(160, 29);
            txtDias.TabIndex = 46;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(134, 508);
            label4.Name = "label4";
            label4.Size = new Size(40, 21);
            label4.TabIndex = 47;
            label4.Text = "Dias";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(134, 403);
            label5.Name = "label5";
            label5.Size = new Size(108, 21);
            label5.TabIndex = 48;
            label5.Text = "Top Productos";
            // 
            // txtTop
            // 
            txtTop.Font = new Font("Segoe UI", 12F);
            txtTop.Location = new Point(283, 403);
            txtTop.Name = "txtTop";
            txtTop.Size = new Size(160, 29);
            txtTop.TabIndex = 49;
            // 
            // ReporteInventarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 615);
            Controls.Add(txtTop);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtDias);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(dtpEndDate);
            Controls.Add(dgvResults);
            Controls.Add(panel1);
            Controls.Add(dtpStartDate);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReporteInventarioForm";
            Text = "ReporteInventarioForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvResults;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label label1;
        private Panel panel2;
        private Button btnTopSellingProducts;
        private Button btnLowStockProducts;
        private Button btnGetAllInventory;
        private Label label2;
        private Label label3;
        private TextBox txtDias;
        private Label label4;
        private Button btnExpiringProducts;
        private Label label5;
        private TextBox txtTop;
    }
}