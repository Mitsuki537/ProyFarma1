namespace FarmaApp
{
    partial class DetalleCompraForm
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
            txtPrecioUnitario = new TextBox();
            label12 = new Label();
            txtCantidad = new MaskedTextBox();
            dgvDetalleOrdenCompra = new DataGridView();
            label11 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            cboNumeroOrden = new ComboBox();
            label1 = new Label();
            dtpFechaExpiracion = new DateTimePicker();
            label6 = new Label();
            dtpLimiteDevolucion = new DateTimePicker();
            cboProducto = new ComboBox();
            label7 = new Label();
            cboIdOrdenCompra = new ComboBox();
            label2 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleOrdenCompra).BeginInit();
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
            panel2.TabIndex = 26;
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
            dtpFechaModificacion.Location = new Point(733, 120);
            dtpFechaModificacion.Name = "dtpFechaModificacion";
            dtpFechaModificacion.Size = new Size(165, 25);
            dtpFechaModificacion.TabIndex = 63;
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioUnitario.Location = new Point(733, 66);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.Size = new Size(165, 22);
            txtPrecioUnitario.TabIndex = 62;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9.75F);
            label12.Location = new Point(812, 157);
            label12.Name = "label12";
            label12.Size = new Size(0, 16);
            label12.TabIndex = 61;
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCantidad.Location = new Point(270, 178);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(165, 22);
            txtCantidad.TabIndex = 60;
            // 
            // dgvDetalleOrdenCompra
            // 
            dgvDetalleOrdenCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleOrdenCompra.Location = new Point(68, 280);
            dgvDetalleOrdenCompra.Name = "dgvDetalleOrdenCompra";
            dgvDetalleOrdenCompra.Size = new Size(830, 184);
            dgvDetalleOrdenCompra.TabIndex = 59;
            dgvDetalleOrdenCompra.SelectionChanged += dgvDetalleOrdenCompra_SelectionChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(535, 123);
            label11.Name = "label11";
            label11.Size = new Size(164, 21);
            label11.TabIndex = 58;
            label11.Text = "Fecha de modificación";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(535, 66);
            label5.Name = "label5";
            label5.Size = new Size(111, 21);
            label5.TabIndex = 56;
            label5.Text = "Precio unitario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(68, 182);
            label4.Name = "label4";
            label4.Size = new Size(72, 21);
            label4.TabIndex = 55;
            label4.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(68, 124);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 54;
            label3.Text = "Nº Orden";
            // 
            // cboNumeroOrden
            // 
            cboNumeroOrden.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboNumeroOrden.FormattingEnabled = true;
            cboNumeroOrden.Location = new Point(270, 120);
            cboNumeroOrden.Name = "cboNumeroOrden";
            cboNumeroOrden.Size = new Size(165, 25);
            cboNumeroOrden.TabIndex = 67;
            cboNumeroOrden.SelectedIndexChanged += cboNumeroOrden_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(535, 182);
            label1.Name = "label1";
            label1.Size = new Size(150, 21);
            label1.TabIndex = 68;
            label1.Text = "Fecha de  expiración";
            // 
            // dtpFechaExpiracion
            // 
            dtpFechaExpiracion.Font = new Font("Segoe UI", 9.75F);
            dtpFechaExpiracion.Format = DateTimePickerFormat.Short;
            dtpFechaExpiracion.Location = new Point(733, 178);
            dtpFechaExpiracion.Name = "dtpFechaExpiracion";
            dtpFechaExpiracion.Size = new Size(165, 25);
            dtpFechaExpiracion.TabIndex = 69;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(68, 234);
            label6.Name = "label6";
            label6.Size = new Size(154, 21);
            label6.TabIndex = 70;
            label6.Text = "Límite de devolución";
            // 
            // dtpLimiteDevolucion
            // 
            dtpLimiteDevolucion.Font = new Font("Segoe UI", 9.75F);
            dtpLimiteDevolucion.Format = DateTimePickerFormat.Short;
            dtpLimiteDevolucion.Location = new Point(270, 229);
            dtpLimiteDevolucion.Name = "dtpLimiteDevolucion";
            dtpLimiteDevolucion.Size = new Size(165, 25);
            dtpLimiteDevolucion.TabIndex = 71;
            // 
            // cboProducto
            // 
            cboProducto.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboProducto.FormattingEnabled = true;
            cboProducto.Location = new Point(733, 234);
            cboProducto.Name = "cboProducto";
            cboProducto.Size = new Size(165, 25);
            cboProducto.TabIndex = 72;
            cboProducto.SelectedIndexChanged += cboProducto_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(535, 238);
            label7.Name = "label7";
            label7.Size = new Size(73, 21);
            label7.TabIndex = 73;
            label7.Text = "Producto";
            // 
            // cboIdOrdenCompra
            // 
            cboIdOrdenCompra.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboIdOrdenCompra.FormattingEnabled = true;
            cboIdOrdenCompra.Location = new Point(270, 65);
            cboIdOrdenCompra.Name = "cboIdOrdenCompra";
            cboIdOrdenCompra.Size = new Size(165, 25);
            cboIdOrdenCompra.TabIndex = 74;
            cboIdOrdenCompra.SelectedIndexChanged += cboIdOrdenCompra_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(68, 69);
            label2.Name = "label2";
            label2.Size = new Size(135, 21);
            label2.TabIndex = 75;
            label2.Text = "Orden de Compra";
            // 
            // DetalleCompraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 505);
            Controls.Add(label2);
            Controls.Add(cboIdOrdenCompra);
            Controls.Add(label7);
            Controls.Add(cboProducto);
            Controls.Add(dtpLimiteDevolucion);
            Controls.Add(label6);
            Controls.Add(dtpFechaExpiracion);
            Controls.Add(label1);
            Controls.Add(cboNumeroOrden);
            Controls.Add(dtpFechaModificacion);
            Controls.Add(txtPrecioUnitario);
            Controls.Add(label12);
            Controls.Add(txtCantidad);
            Controls.Add(dgvDetalleOrdenCompra);
            Controls.Add(label11);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DetalleCompraForm";
            Text = "DetalleCompraForm";
            Load += DetalleCompraForm_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalleOrdenCompra).EndInit();
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
        private TextBox txtPrecioUnitario;
        private Label label12;
        private MaskedTextBox txtCantidad;
        private DataGridView dgvDetalleOrdenCompra;
        private Label label11;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox cboNumeroOrden;
        private Label label1;
        private DateTimePicker dtpFechaExpiracion;
        private Label label6;
        private DateTimePicker dtpLimiteDevolucion;
        private ComboBox cboProducto;
        private Label label7;
        private ComboBox cboIdOrdenCompra;
        private Label label2;
    }
}