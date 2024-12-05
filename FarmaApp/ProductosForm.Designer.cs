namespace FarmaApp
{
    partial class ProductosForm
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
            btnCategorias = new Button();
            label1 = new Label();
            panel2 = new Panel();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            dtpFechaModificacion = new DateTimePicker();
            txtReabastecimiento = new TextBox();
            label12 = new Label();
            txtProducto = new TextBox();
            dgvProductos = new DataGridView();
            label11 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cboProveedor = new ComboBox();
            cboCategoria = new ComboBox();
            txtPrecioUnitario = new TextBox();
            txtNumeroLote = new TextBox();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(49, 66, 82);
            panel1.Controls.Add(btnCategorias);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 0);
            panel1.TabIndex = 2;
            // 
            // btnCategorias
            // 
            btnCategorias.BackColor = Color.FromArgb(49, 66, 82);
            btnCategorias.Cursor = Cursors.Hand;
            btnCategorias.FlatAppearance.BorderSize = 0;
            btnCategorias.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnCategorias.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Segoe UI", 14.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            btnCategorias.ForeColor = Color.Transparent;
            btnCategorias.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategorias.Location = new Point(218, -2);
            btnCategorias.Margin = new Padding(3, 2, 3, 2);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(176, 71);
            btnCategorias.TabIndex = 13;
            btnCategorias.Text = "Categorias";
            btnCategorias.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategorias.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(49, 66, 82);
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(63, 23);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 0;
            label1.Text = "Productos";
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
            dtpFechaModificacion.Location = new Point(717, 154);
            dtpFechaModificacion.Name = "dtpFechaModificacion";
            dtpFechaModificacion.Size = new Size(165, 25);
            dtpFechaModificacion.TabIndex = 47;
            // 
            // txtReabastecimiento
            // 
            txtReabastecimiento.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReabastecimiento.Location = new Point(717, 37);
            txtReabastecimiento.Name = "txtReabastecimiento";
            txtReabastecimiento.Size = new Size(165, 22);
            txtReabastecimiento.TabIndex = 42;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9.75F);
            label12.Location = new Point(338, 278);
            label12.Name = "label12";
            label12.Size = new Size(0, 16);
            label12.TabIndex = 41;
            // 
            // txtProducto
            // 
            txtProducto.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtProducto.Location = new Point(258, 33);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(165, 22);
            txtProducto.TabIndex = 37;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(63, 267);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(830, 187);
            dgvProductos.TabIndex = 36;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(519, 154);
            label11.Name = "label11";
            label11.Size = new Size(164, 21);
            label11.TabIndex = 35;
            label11.Text = "Fecha de modificación";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(519, 36);
            label6.Name = "label6";
            label6.Size = new Size(133, 21);
            label6.TabIndex = 30;
            label6.Text = "Reabastecimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(60, 209);
            label5.Name = "label5";
            label5.Size = new Size(111, 21);
            label5.TabIndex = 29;
            label5.Text = "Precio unitario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(60, 154);
            label4.Name = "label4";
            label4.Size = new Size(77, 21);
            label4.TabIndex = 28;
            label4.Text = "Categoria";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(60, 96);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 27;
            label3.Text = "Proveedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(60, 32);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 26;
            label2.Text = "Nombre";
            // 
            // cboProveedor
            // 
            cboProveedor.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new Point(258, 96);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new Size(165, 25);
            cboProveedor.TabIndex = 48;
            // 
            // cboCategoria
            // 
            cboCategoria.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(258, 154);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(165, 25);
            cboCategoria.TabIndex = 49;
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioUnitario.Location = new Point(258, 210);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.Size = new Size(165, 22);
            txtPrecioUnitario.TabIndex = 50;
            // 
            // txtNumeroLote
            // 
            txtNumeroLote.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNumeroLote.Location = new Point(717, 95);
            txtNumeroLote.Name = "txtNumeroLote";
            txtNumeroLote.Size = new Size(165, 22);
            txtNumeroLote.TabIndex = 51;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(525, 91);
            label7.Name = "label7";
            label7.Size = new Size(59, 21);
            label7.TabIndex = 52;
            label7.Text = "N. Lote";
            // 
            // ProductosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 505);
            Controls.Add(label7);
            Controls.Add(txtNumeroLote);
            Controls.Add(txtPrecioUnitario);
            Controls.Add(cboCategoria);
            Controls.Add(cboProveedor);
            Controls.Add(dtpFechaModificacion);
            Controls.Add(txtReabastecimiento);
            Controls.Add(label12);
            Controls.Add(txtProducto);
            Controls.Add(dgvProductos);
            Controls.Add(label11);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductosForm";
            Text = "ProductosForm";
            Load += ProductosForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnGuardar;
        private Button btnNuevo;
        private DateTimePicker dtpFechaModificacion;
        private TextBox txtReabastecimiento;
        private Label label12;
        private TextBox txtProducto;
        private DataGridView dgvProductos;
        private Label label11;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cboProveedor;
        private Button btnCategorias;
        private ComboBox cboCategoria;
        private TextBox txtPrecioUnitario;
        private TextBox txtNumeroLote;
        private Label label7;
    }
}