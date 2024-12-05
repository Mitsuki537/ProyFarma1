namespace FarmaApp
{
    partial class OrdenCompraForm
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
            panel2 = new Panel();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            dtpFechaModificacion = new DateTimePicker();
            label12 = new Label();
            dgvOrdenCompra = new DataGridView();
            label11 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            dtpFechaOrden = new DateTimePicker();
            cboEstado = new ComboBox();
            cboProveedor = new ComboBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenCompra).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(49, 66, 82);
            panel2.Controls.Add(btnEliminar);
            panel2.Controls.Add(btnActualizar);
            panel2.Controls.Add(btnGuardar);
            panel2.Controls.Add(btnNuevo);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(970, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(130, 505);
            panel2.TabIndex = 25;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnEliminar.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.ForeColor = SystemColors.Window;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(0, 210);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 46);
            btnEliminar.TabIndex = 41;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnActualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 12F);
            btnActualizar.ForeColor = SystemColors.Window;
            btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnActualizar.Location = new Point(0, 142);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(130, 46);
            btnActualizar.TabIndex = 42;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.ForeColor = SystemColors.Window;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(0, 69);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(130, 46);
            btnGuardar.TabIndex = 40;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnNuevo.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 12F);
            btnNuevo.ForeColor = SystemColors.Window;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(0, 1);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(130, 46);
            btnNuevo.TabIndex = 39;
            btnNuevo.Text = "Nuevo";
            btnNuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dtpFechaModificacion
            // 
            dtpFechaModificacion.Font = new Font("Segoe UI", 9.75F);
            dtpFechaModificacion.Format = DateTimePickerFormat.Short;
            dtpFechaModificacion.Location = new Point(703, 175);
            dtpFechaModificacion.Name = "dtpFechaModificacion";
            dtpFechaModificacion.Size = new Size(165, 25);
            dtpFechaModificacion.TabIndex = 47;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9.75F);
            label12.Location = new Point(782, 133);
            label12.Name = "label12";
            label12.Size = new Size(0, 16);
            label12.TabIndex = 41;
            // 
            // dgvOrdenCompra
            // 
            dgvOrdenCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenCompra.Location = new Point(64, 279);
            dgvOrdenCompra.Name = "dgvOrdenCompra";
            dgvOrdenCompra.Size = new Size(830, 184);
            dgvOrdenCompra.TabIndex = 36;
            dgvOrdenCompra.SelectionChanged += dgvOrdenCompra_SelectionChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(505, 178);
            label11.Name = "label11";
            label11.Size = new Size(164, 21);
            label11.TabIndex = 35;
            label11.Text = "Fecha de modificación";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(505, 109);
            label6.Name = "label6";
            label6.Size = new Size(56, 21);
            label6.TabIndex = 30;
            label6.Text = "Estado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(76, 173);
            label3.Name = "label3";
            label3.Size = new Size(116, 21);
            label3.TabIndex = 27;
            label3.Text = "Fecha de orden";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(76, 109);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 26;
            label2.Text = "Proveedor";
            // 
            // dtpFechaOrden
            // 
            dtpFechaOrden.Font = new Font("Segoe UI", 9.75F);
            dtpFechaOrden.Format = DateTimePickerFormat.Short;
            dtpFechaOrden.Location = new Point(274, 175);
            dtpFechaOrden.Name = "dtpFechaOrden";
            dtpFechaOrden.Size = new Size(165, 25);
            dtpFechaOrden.TabIndex = 51;
            // 
            // cboEstado
            // 
            cboEstado.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(703, 110);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(165, 25);
            cboEstado.TabIndex = 52;
            // 
            // cboProveedor
            // 
            cboProveedor.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new Point(274, 109);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new Size(165, 25);
            cboProveedor.TabIndex = 53;
            // 
            // OrdenCompraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 505);
            Controls.Add(cboProveedor);
            Controls.Add(cboEstado);
            Controls.Add(dtpFechaOrden);
            Controls.Add(dtpFechaModificacion);
            Controls.Add(label12);
            Controls.Add(dgvOrdenCompra);
            Controls.Add(label11);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "OrdenCompraForm";
            Text = "OrderCompraForm";
            Load += OrdenCompraForm_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrdenCompra).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnGuardar;
        private Button btnNuevo;
        private DateTimePicker dtpFechaModificacion;
        private TextBox textBox4;
        private Label label12;
        private MaskedTextBox maskedTextBox1;
        private DataGridView dgvOrdenCompra;
        private Label label11;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboBox1;
        private DateTimePicker dtpFechaOrden;
        private ComboBox cboEstado;
        private DateTimePicker dateTimePicker3;
        private ComboBox cboProveedor;
    }
}