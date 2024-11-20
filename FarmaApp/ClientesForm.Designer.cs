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
            textBox1 = new TextBox();
            label4 = new Label();
            dataGridView2 = new DataGridView();
            dateTimePicker3 = new DateTimePicker();
            textBox6 = new TextBox();
            textBox8 = new TextBox();
            label13 = new Label();
            panel2 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            btnNuevo = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(644, 165);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(165, 25);
            textBox1.TabIndex = 57;
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
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(148, 309);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(661, 165);
            dataGridView2.TabIndex = 12;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker3.Format = DateTimePickerFormat.Short;
            dateTimePicker3.Location = new Point(644, 217);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(165, 27);
            dateTimePicker3.TabIndex = 10;
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox6.Location = new Point(254, 220);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(165, 25);
            textBox6.TabIndex = 6;
            // 
            // textBox8
            // 
            textBox8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox8.Location = new Point(254, 164);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(165, 25);
            textBox8.TabIndex = 5;
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
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(btnNuevo);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(970, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(130, 544);
            panel2.TabIndex = 82;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F);
            button3.ForeColor = SystemColors.Window;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 210);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(130, 46);
            button3.TabIndex = 41;
            button3.Text = "Eliminar";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F);
            button2.ForeColor = SystemColors.Window;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 142);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(130, 46);
            button2.TabIndex = 42;
            button2.Text = "Actualizar";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = SystemColors.Window;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 69);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(130, 46);
            button1.TabIndex = 40;
            button1.Text = "Guardar";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
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
            // 
            // ClientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1100, 615);
            Controls.Add(panel2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label12);
            Controls.Add(dataGridView2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label13);
            Controls.Add(dateTimePicker3);
            Controls.Add(textBox8);
            Controls.Add(textBox6);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClientesForm";
            Text = "ClientesForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private DataGridView dataGridView2;
        private DateTimePicker dateTimePicker3;
        private TextBox textBox6;
        private TextBox textBox8;
        private Label label13;
        private TextBox textBox1;
        private Panel panel2;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button btnNuevo;
    }
}