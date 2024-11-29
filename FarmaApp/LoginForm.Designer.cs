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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panelContainer = new Panel();
            panel3 = new Panel();
            pbHidePassword = new PictureBox();
            pbShowPassword = new PictureBox();
            lblStatus = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtEmail = new TextBox();
            btnLogin = new Button();
            txtPassword = new TextBox();
            btnMaximizar = new Button();
            panelLogin = new Panel();
            btnCerrar = new Button();
            btnNormal = new Button();
            btnMinimizar = new Button();
            errorProvider2 = new ErrorProvider(components);
            timer1 = new System.Windows.Forms.Timer(components);
            panelContainer.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbHidePassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbShowPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.FromArgb(49, 66, 82);
            panelContainer.Controls.Add(panel3);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 40);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1300, 610);
            panelContainer.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(26, 32, 40);
            panel3.Controls.Add(pbHidePassword);
            panel3.Controls.Add(pbShowPassword);
            panel3.Controls.Add(lblStatus);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtEmail);
            panel3.Controls.Add(btnLogin);
            panel3.Controls.Add(txtPassword);
            panel3.Location = new Point(405, 97);
            panel3.Name = "panel3";
            panel3.Size = new Size(525, 438);
            panel3.TabIndex = 37;
            // 
            // pbHidePassword
            // 
            pbHidePassword.Image = (Image)resources.GetObject("pbHidePassword.Image");
            pbHidePassword.Location = new Point(399, 259);
            pbHidePassword.Name = "pbHidePassword";
            pbHidePassword.Size = new Size(32, 23);
            pbHidePassword.SizeMode = PictureBoxSizeMode.Zoom;
            pbHidePassword.TabIndex = 42;
            pbHidePassword.TabStop = false;
            // 
            // pbShowPassword
            // 
            pbShowPassword.Image = (Image)resources.GetObject("pbShowPassword.Image");
            pbShowPassword.Location = new Point(399, 259);
            pbShowPassword.Name = "pbShowPassword";
            pbShowPassword.Size = new Size(32, 23);
            pbShowPassword.SizeMode = PictureBoxSizeMode.Zoom;
            pbShowPassword.TabIndex = 41;
            pbShowPassword.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(146, 312);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 21);
            lblStatus.TabIndex = 40;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(218, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(112, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 39;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(146, 165);
            label1.Name = "label1";
            label1.Size = new Size(100, 21);
            label1.TabIndex = 37;
            label1.Text = "Iniciar sesión";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.Control;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = SystemColors.WindowFrame;
            txtEmail.Location = new Point(146, 199);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 33);
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
            btnLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(146, 360);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(230, 38);
            btnLogin.TabIndex = 36;
            btnLogin.Text = "Acceder";
            btnLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.Control;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = SystemColors.WindowFrame;
            txtPassword.Location = new Point(146, 255);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(230, 33);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Contraseña";
            // 
            // btnMaximizar
            // 
            btnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximizar.BackColor = Color.Transparent;
            btnMaximizar.Cursor = Cursors.Hand;
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 32, 40);
            btnMaximizar.FlatStyle = FlatStyle.Flat;
            btnMaximizar.Image = (Image)resources.GetObject("btnMaximizar.Image");
            btnMaximizar.Location = new Point(1200, 0);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(50, 40);
            btnMaximizar.TabIndex = 40;
            btnMaximizar.UseVisualStyleBackColor = true;
            btnMaximizar.Click += btnMaximizar_Click_1;
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.FromArgb(0, 80, 200);
            panelLogin.Controls.Add(btnMaximizar);
            panelLogin.Controls.Add(btnCerrar);
            panelLogin.Controls.Add(btnNormal);
            panelLogin.Controls.Add(btnMinimizar);
            panelLogin.Dock = DockStyle.Top;
            panelLogin.Location = new Point(0, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(1300, 40);
            panelLogin.TabIndex = 42;
            panelLogin.MouseDown += panel2_MouseDown;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.Red;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(1250, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(50, 40);
            btnCerrar.TabIndex = 39;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnNormal
            // 
            btnNormal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNormal.BackColor = Color.FromArgb(0, 80, 200);
            btnNormal.Cursor = Cursors.Hand;
            btnNormal.FlatAppearance.BorderSize = 0;
            btnNormal.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 32, 40);
            btnNormal.FlatStyle = FlatStyle.Flat;
            btnNormal.Image = (Image)resources.GetObject("btnNormal.Image");
            btnNormal.Location = new Point(1197, 0);
            btnNormal.Name = "btnNormal";
            btnNormal.Size = new Size(50, 40);
            btnNormal.TabIndex = 41;
            btnNormal.UseVisualStyleBackColor = false;
            btnNormal.Click += btnNormal_Click_1;
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
            btnMinimizar.Location = new Point(1146, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(50, 40);
            btnMinimizar.TabIndex = 38;
            btnMinimizar.UseVisualStyleBackColor = true;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // errorProvider2
            // 
            errorProvider2.ContainerControl = this;
            // 
            // timer1
            // 
            timer1.Tick += LockoutTimer_Tick;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 650);
            Controls.Add(panelContainer);
            Controls.Add(panelLogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "LoginForm";
            panelContainer.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbHidePassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbShowPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContainer;
        private Panel panel3;
        private TextBox txtEmail;
        private Button btnLogin;
        private TextBox txtPassword;
        private Label label1;
        private PictureBox pictureBox1;
        private ErrorProvider errorProvider1;
        private Label lblStatus;
        private System.Windows.Forms.Timer timer;
        private ErrorProvider errorProvider2;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pbHidePassword;
        private PictureBox pbShowPassword;
        private Button btnMinimizar;
        private Button btnCerrar;
        private Button btnMaximizar;
        private Button btnNormal;
        private Panel panelLogin;
    }
}