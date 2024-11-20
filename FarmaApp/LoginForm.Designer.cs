namespace FarmaApp
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            btnCrearCuenta = new Button();
            label1 = new Label();
            txtEmail = new TextBox();
            btnLogin = new Button();
            txtPassword = new TextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 32, 40);
            panel1.Controls.Add(btnMinimizar);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 485);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimizar.BackColor = Color.Transparent;
            btnMinimizar.Cursor = Cursors.Hand;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 32, 40);
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.ForeColor = SystemColors.ControlText;
            btnMinimizar.Image = (Image)resources.GetObject("btnMinimizar.Image");
            btnMinimizar.Location = new Point(678, -5);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(51, 40);
            btnMinimizar.TabIndex = 39;
            btnMinimizar.UseVisualStyleBackColor = true;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 32, 40);
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(735, -2);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(45, 35);
            btnCerrar.TabIndex = 38;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(224, 224, 224);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(btnCrearCuenta);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtEmail);
            panel3.Controls.Add(btnLogin);
            panel3.Controls.Add(txtPassword);
            panel3.Location = new Point(214, 35);
            panel3.Name = "panel3";
            panel3.Size = new Size(359, 421);
            panel3.TabIndex = 37;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(132, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(101, 97);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 39;
            pictureBox1.TabStop = false;
            // 
            // btnCrearCuenta
            // 
            btnCrearCuenta.BackColor = Color.FromArgb(224, 224, 224);
            btnCrearCuenta.Cursor = Cursors.Hand;
            btnCrearCuenta.Dock = DockStyle.Bottom;
            btnCrearCuenta.FlatAppearance.BorderSize = 0;
            btnCrearCuenta.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnCrearCuenta.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btnCrearCuenta.FlatStyle = FlatStyle.Flat;
            btnCrearCuenta.Font = new Font("Segoe UI", 12F);
            btnCrearCuenta.ForeColor = Color.FromArgb(26, 32, 40);
            btnCrearCuenta.ImageAlign = ContentAlignment.MiddleLeft;
            btnCrearCuenta.Location = new Point(0, 386);
            btnCrearCuenta.Margin = new Padding(3, 2, 3, 2);
            btnCrearCuenta.Name = "btnCrearCuenta";
            btnCrearCuenta.Size = new Size(359, 35);
            btnCrearCuenta.TabIndex = 38;
            btnCrearCuenta.Text = "Crear cuenta";
            btnCrearCuenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCrearCuenta.UseVisualStyleBackColor = false;
            btnCrearCuenta.MouseEnter += btnProductos_MouseEnter;
            btnCrearCuenta.MouseLeave += btnCrearCuenta_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(26, 32, 40);
            label1.Location = new Point(56, 135);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 37;
            label1.Text = "Iniciar sesión";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.Control;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = SystemColors.WindowFrame;
            txtEmail.Location = new Point(56, 172);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 29);
            txtEmail.TabIndex = 1;
            txtEmail.Text = "Usuario";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 80, 200);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F);
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(56, 296);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(230, 38);
            btnLogin.TabIndex = 36;
            btnLogin.Text = "Acceder";
            btnLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.Control;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = SystemColors.WindowFrame;
            txtPassword.Location = new Point(56, 233);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(230, 29);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Contraseña";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 485);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private TextBox txtEmail;
        private Button btnLogin;
        private TextBox txtPassword;
        private Label label1;
        private Button btnCrearCuenta;
        private PictureBox pictureBox1;
        private Button btnCerrar;
        private Button btnMinimizar;
    }
}