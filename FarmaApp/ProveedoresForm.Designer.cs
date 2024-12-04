namespace FarmaApp
{
    partial class ProveedoresForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            dgvProveedores = new DataGridView();
            txtNombreContacto = new TextBox();
            txtTitulo = new TextBox();
            mtbTelefono = new MaskedTextBox();
            label12 = new Label();
            txtCorreo = new TextBox();
            txtDireccion = new TextBox();
            txtCiudad = new TextBox();
            txtPais = new TextBox();
            txtCodigoPostal = new TextBox();
            dtpFechaModificacion = new DateTimePicker();
            panel2 = new Panel();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            txtProveedor = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(68, 117);
            label2.Name = "label2";
            label2.Size = new Size(72, 21);
            label2.TabIndex = 2;
            label2.Text = "Nombre ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(68, 181);
            label3.Name = "label3";
            label3.Size = new Size(152, 21);
            label3.TabIndex = 3;
            label3.Text = "Nombre de contacto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(68, 239);
            label4.Name = "label4";
            label4.Size = new Size(133, 21);
            label4.TabIndex = 4;
            label4.Text = "Título de contacto";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(68, 295);
            label5.Name = "label5";
            label5.Size = new Size(68, 21);
            label5.TabIndex = 5;
            label5.Text = "Teléfono";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(68, 348);
            label6.Name = "label6";
            label6.Size = new Size(58, 21);
            label6.TabIndex = 6;
            label6.Text = "Correo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(547, 119);
            label7.Name = "label7";
            label7.Size = new Size(75, 21);
            label7.TabIndex = 7;
            label7.Text = "Dirección";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(545, 185);
            label8.Name = "label8";
            label8.Size = new Size(59, 21);
            label8.TabIndex = 8;
            label8.Text = "Ciudad";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(547, 237);
            label9.Name = "label9";
            label9.Size = new Size(37, 21);
            label9.TabIndex = 9;
            label9.Text = "País";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(547, 299);
            label10.Name = "label10";
            label10.Size = new Size(106, 21);
            label10.TabIndex = 10;
            label10.Text = "Código postal";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(547, 351);
            label11.Name = "label11";
            label11.Size = new Size(164, 21);
            label11.TabIndex = 11;
            label11.Text = "Fecha de modificación";
            // 
            // dgvProveedores
            // 
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(68, 420);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.Size = new Size(830, 166);
            dgvProveedores.TabIndex = 12;
            dgvProveedores.SelectionChanged += dgvProveedores_SelectionChanged;
            // 
            // txtNombreContacto
            // 
            txtNombreContacto.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreContacto.Location = new Point(266, 182);
            txtNombreContacto.Name = "txtNombreContacto";
            txtNombreContacto.Size = new Size(165, 22);
            txtNombreContacto.TabIndex = 14;
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtTitulo.Location = new Point(266, 240);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(165, 22);
            txtTitulo.TabIndex = 15;
            // 
            // mtbTelefono
            // 
            mtbTelefono.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mtbTelefono.Location = new Point(266, 296);
            mtbTelefono.Mask = "(505)000-0000";
            mtbTelefono.Name = "mtbTelefono";
            mtbTelefono.Size = new Size(165, 22);
            mtbTelefono.TabIndex = 16;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9.75F);
            label12.Location = new Point(345, 372);
            label12.Name = "label12";
            label12.Size = new Size(0, 16);
            label12.TabIndex = 17;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(266, 349);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(165, 22);
            txtCorreo.TabIndex = 18;
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Segoe UI", 9.75F);
            txtDireccion.Location = new Point(733, 115);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(165, 25);
            txtDireccion.TabIndex = 19;
            // 
            // txtCiudad
            // 
            txtCiudad.Font = new Font("Segoe UI", 9.75F);
            txtCiudad.Location = new Point(733, 183);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(165, 25);
            txtCiudad.TabIndex = 20;
            // 
            // txtPais
            // 
            txtPais.Font = new Font("Segoe UI", 9.75F);
            txtPais.Location = new Point(733, 237);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(165, 25);
            txtPais.TabIndex = 21;
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Font = new Font("Segoe UI", 9.75F);
            txtCodigoPostal.Location = new Point(733, 292);
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(165, 25);
            txtCodigoPostal.TabIndex = 22;
            // 
            // dtpFechaModificacion
            // 
            dtpFechaModificacion.Font = new Font("Segoe UI", 9.75F);
            dtpFechaModificacion.Format = DateTimePickerFormat.Short;
            dtpFechaModificacion.Location = new Point(733, 348);
            dtpFechaModificacion.Name = "dtpFechaModificacion";
            dtpFechaModificacion.Size = new Size(165, 25);
            dtpFechaModificacion.TabIndex = 23;
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
            panel2.Size = new Size(130, 615);
            panel2.TabIndex = 24;
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
            // txtProveedor
            // 
            txtProveedor.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtProveedor.Location = new Point(266, 118);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(165, 22);
            txtProveedor.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(49, 66, 82);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(970, 71);
            panel1.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(49, 66, 82);
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(54, 23);
            label1.Name = "label1";
            label1.Size = new Size(117, 25);
            label1.TabIndex = 0;
            label1.Text = "Proveedores";
            // 
            // ProveedoresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 615);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(dtpFechaModificacion);
            Controls.Add(txtCodigoPostal);
            Controls.Add(txtPais);
            Controls.Add(txtCiudad);
            Controls.Add(txtDireccion);
            Controls.Add(txtCorreo);
            Controls.Add(label12);
            Controls.Add(mtbTelefono);
            Controls.Add(txtTitulo);
            Controls.Add(txtNombreContacto);
            Controls.Add(txtProveedor);
            Controls.Add(dgvProveedores);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProveedoresForm";
            Text = "ProveedoresForm";
            Load += ProveedoresForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private DataGridView dgvProveedores;
        private TextBox txtNombreContacto;
        private TextBox txtTitulo;
        private MaskedTextBox mtbTelefono;
        private Label label12;
        private TextBox txtCorreo;
        private TextBox txtDireccion;
        private TextBox txtCiudad;
        private TextBox txtPais;
        private TextBox txtCodigoPostal;
        private DateTimePicker dtpFechaModificacion;
        private Panel panel2;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnGuardar;
        private Button btnNuevo;
        private TextBox txtProveedor;
        private Panel panel1;
        private Label label1;
    }
}