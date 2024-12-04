namespace FarmaApp
{
    partial class EmpleadosForm
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
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            dtpFechaModificacion = new DateTimePicker();
            txtDepartamento = new TextBox();
            txtCorreo = new TextBox();
            label12 = new Label();
            txtTitulo = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            dgvEmpleados = new DataGridView();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            colorDialog1 = new ColorDialog();
            cboReportadoA = new ComboBox();
            dtpFechaContratacion = new DateTimePicker();
            dtpFechaNacimiento = new DateTimePicker();
            mtbTelefono = new MaskedTextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(49, 66, 82);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 71);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(49, 66, 82);
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(63, 23);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 0;
            label1.Text = "Empleados";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(49, 66, 82);
            panel2.Controls.Add(btnEliminar);
            panel2.Controls.Add(btnActualizar);
            panel2.Controls.Add(btnGuardar);
            panel2.Controls.Add(btnNuevo);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(970, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(130, 544);
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
            dtpFechaModificacion.Location = new Point(728, 346);
            dtpFechaModificacion.Name = "dtpFechaModificacion";
            dtpFechaModificacion.Size = new Size(165, 25);
            dtpFechaModificacion.TabIndex = 47;
            // 
            // txtDepartamento
            // 
            txtDepartamento.Font = new Font("Segoe UI", 9.75F);
            txtDepartamento.Location = new Point(728, 233);
            txtDepartamento.Name = "txtDepartamento";
            txtDepartamento.Size = new Size(165, 25);
            txtDepartamento.TabIndex = 45;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Segoe UI", 9.75F);
            txtCorreo.Location = new Point(728, 115);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(165, 25);
            txtCorreo.TabIndex = 43;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9.75F);
            label12.Location = new Point(340, 371);
            label12.Name = "label12";
            label12.Size = new Size(0, 16);
            label12.TabIndex = 41;
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtTitulo.Location = new Point(261, 240);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(165, 22);
            txtTitulo.TabIndex = 39;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(261, 180);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(165, 22);
            txtApellido.TabIndex = 38;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtNombre.Location = new Point(261, 118);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(165, 22);
            txtNombre.TabIndex = 37;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new Point(63, 412);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.Size = new Size(830, 166);
            dgvEmpleados.TabIndex = 36;
            dgvEmpleados.SelectionChanged += dgvEmpleados_SelectionChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(542, 349);
            label11.Name = "label11";
            label11.Size = new Size(164, 21);
            label11.TabIndex = 35;
            label11.Text = "Fecha de modificación";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(542, 299);
            label10.Name = "label10";
            label10.Size = new Size(95, 21);
            label10.TabIndex = 34;
            label10.Text = "Reportado a";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(542, 237);
            label9.Name = "label9";
            label9.Size = new Size(110, 21);
            label9.TabIndex = 33;
            label9.Text = "Departamento";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(542, 179);
            label8.Name = "label8";
            label8.Size = new Size(68, 21);
            label8.TabIndex = 32;
            label8.Text = "Teléfono";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(542, 119);
            label7.Name = "label7";
            label7.Size = new Size(58, 21);
            label7.TabIndex = 31;
            label7.Text = "Correo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(63, 346);
            label6.Name = "label6";
            label6.Size = new Size(152, 21);
            label6.TabIndex = 30;
            label6.Text = "Fecha de nacimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(63, 295);
            label5.Name = "label5";
            label5.Size = new Size(161, 21);
            label5.TabIndex = 29;
            label5.Text = "Fecha de contratación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(63, 239);
            label4.Name = "label4";
            label4.Size = new Size(49, 21);
            label4.TabIndex = 28;
            label4.Text = "Título";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(63, 179);
            label3.Name = "label3";
            label3.Size = new Size(67, 21);
            label3.TabIndex = 27;
            label3.Text = "Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(63, 117);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 26;
            label2.Text = "Nombre";
            // 
            // cboReportadoA
            // 
            cboReportadoA.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboReportadoA.FormattingEnabled = true;
            cboReportadoA.Location = new Point(728, 295);
            cboReportadoA.Name = "cboReportadoA";
            cboReportadoA.Size = new Size(165, 25);
            cboReportadoA.TabIndex = 50;
            // 
            // dtpFechaContratacion
            // 
            dtpFechaContratacion.Font = new Font("Segoe UI", 9.75F);
            dtpFechaContratacion.Format = DateTimePickerFormat.Short;
            dtpFechaContratacion.Location = new Point(261, 292);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(165, 25);
            dtpFechaContratacion.TabIndex = 51;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Font = new Font("Segoe UI", 9.75F);
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(261, 345);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(165, 25);
            dtpFechaNacimiento.TabIndex = 52;
            // 
            // mtbTelefono
            // 
            mtbTelefono.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mtbTelefono.Location = new Point(728, 178);
            mtbTelefono.Mask = "(505)0000-0000";
            mtbTelefono.Name = "mtbTelefono";
            mtbTelefono.Size = new Size(165, 22);
            mtbTelefono.TabIndex = 53;
            // 
            // EmpleadosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 615);
            Controls.Add(mtbTelefono);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(dtpFechaContratacion);
            Controls.Add(cboReportadoA);
            Controls.Add(dtpFechaModificacion);
            Controls.Add(txtDepartamento);
            Controls.Add(txtCorreo);
            Controls.Add(label12);
            Controls.Add(txtTitulo);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(dgvEmpleados);
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
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmpleadosForm";
            Text = "EmpleadosForm";
            Load += EmpleadosForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
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
        private TextBox txtDepartamento;
        private TextBox txtCorreo;
        private Label label12;
        private TextBox txtTitulo;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private DataGridView dgvEmpleados;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ColorDialog colorDialog1;
        private ComboBox cboReportadoA;
        private DateTimePicker dtpFechaContratacion;
        private DateTimePicker dtpFechaNacimiento;
        private MaskedTextBox mtbTelefono;
    }
}