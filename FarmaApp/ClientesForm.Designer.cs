namespace FarmaApp
{
    partial class ClientesForm
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
            label12 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            dgvClientes = new DataGridView();
            dtpFechaModificacion = new DateTimePicker();
            txtApellido = new TextBox();
            txtCliente = new TextBox();
            label13 = new Label();
            panel2 = new Panel();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            mtbTelefono = new MaskedTextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9.75F);
            label12.Location = new Point(651, 379);
            label12.Name = "label12";
            label12.Size = new Size(0, 16);
            label12.TabIndex = 68;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(148, 224);
            label3.Name = "label3";
            label3.Size = new Size(67, 21);
            label3.TabIndex = 55;
            label3.Text = "Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(147, 168);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 54;
            label2.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(827, 297);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 79;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(49, 66, 82);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 71);
            panel1.TabIndex = 81;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(49, 66, 82);
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.Window;
            label5.Location = new Point(63, 23);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 0;
            label5.Text = "Clientes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(490, 165);
            label4.Name = "label4";
            label4.Size = new Size(68, 21);
            label4.TabIndex = 56;
            label4.Text = "Teléfono";
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(148, 309);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(661, 165);
            dgvClientes.TabIndex = 12;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            // 
            // dtpFechaModificacion
            // 
            dtpFechaModificacion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaModificacion.Format = DateTimePickerFormat.Short;
            dtpFechaModificacion.Location = new Point(644, 217);
            dtpFechaModificacion.Name = "dtpFechaModificacion";
            dtpFechaModificacion.Size = new Size(165, 27);
            dtpFechaModificacion.TabIndex = 10;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(254, 220);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(165, 25);
            txtApellido.TabIndex = 6;
            // 
            // txtCliente
            // 
            txtCliente.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCliente.Location = new Point(254, 164);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(165, 25);
            txtCliente.TabIndex = 5;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(474, 221);
            label13.Name = "label13";
            label13.Size = new Size(164, 21);
            label13.TabIndex = 4;
            label13.Text = "Fecha de modificación";
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
            panel2.TabIndex = 82;
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
            // mtbTelefono
            // 
            mtbTelefono.Location = new Point(647, 169);
            mtbTelefono.Mask = "(505)000-0000";
            mtbTelefono.Name = "mtbTelefono";
            mtbTelefono.Size = new Size(162, 23);
            mtbTelefono.TabIndex = 83;
            // 
            // ClientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1100, 615);
            Controls.Add(mtbTelefono);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label12);
            Controls.Add(dgvClientes);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label13);
            Controls.Add(dtpFechaModificacion);
            Controls.Add(txtCliente);
            Controls.Add(txtApellido);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClientesForm";
            Text = "ClientesForm";
            Load += ClientesForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox7;
        private TextBox textBox5;
        private Label label12;
        private Label label10;
        private Label label9;
        private Label label7;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private ComboBox comboBox1;
        private Panel panel1;
        private Label label5;
        private DataGridView dgvClientes;
        private DateTimePicker dtpFechaModificacion;
        private TextBox txtApellido;
        private TextBox txtCliente;
        private Label label13;
        private Panel panel2;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnGuardar;
        private Button btnNuevo;
        private MaskedTextBox mtbTelefono;
    }
}