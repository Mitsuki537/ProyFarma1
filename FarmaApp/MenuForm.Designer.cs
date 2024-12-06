namespace FarmaApp
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            btnReportes = new Button();
            btnRegistroUsuarioForm = new Button();
            pnlDashboard = new Panel();
            btnUsuario = new Button();
            btnCompras = new Button();
            btnMenu = new Button();
            btnProductos = new Button();
            btnEmpleados = new Button();
            btnClientes = new Button();
            btnVentas = new Button();
            pnlSubReportes = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            panel3 = new Panel();
            btnRtpMovimientos = new Button();
            btnRptInventario = new Button();
            pnlContenedorForm = new Panel();
            tmExpandirMenu = new System.Windows.Forms.Timer(components);
            tmContraerMenu = new System.Windows.Forms.Timer(components);
            pnlDashboard.SuspendLayout();
            pnlSubReportes.SuspendLayout();
            SuspendLayout();
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.FromArgb(26, 32, 40);
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 12F);
            btnReportes.ForeColor = Color.Transparent;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(0, 362);
            btnReportes.Margin = new Padding(3, 2, 3, 2);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(200, 35);
            btnReportes.TabIndex = 9;
            btnReportes.Text = "Reportes";
            btnReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnRegistroUsuarioForm
            // 
            btnRegistroUsuarioForm.BackColor = Color.FromArgb(26, 32, 40);
            btnRegistroUsuarioForm.Cursor = Cursors.Hand;
            btnRegistroUsuarioForm.FlatAppearance.BorderSize = 0;
            btnRegistroUsuarioForm.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRegistroUsuarioForm.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnRegistroUsuarioForm.FlatStyle = FlatStyle.Flat;
            btnRegistroUsuarioForm.Font = new Font("Segoe UI", 12F);
            btnRegistroUsuarioForm.ForeColor = Color.Transparent;
            btnRegistroUsuarioForm.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistroUsuarioForm.Location = new Point(-1, 180);
            btnRegistroUsuarioForm.Margin = new Padding(3, 2, 3, 2);
            btnRegistroUsuarioForm.Name = "btnRegistroUsuarioForm";
            btnRegistroUsuarioForm.Size = new Size(200, 35);
            btnRegistroUsuarioForm.TabIndex = 8;
            btnRegistroUsuarioForm.Text = "Proveedores";
            btnRegistroUsuarioForm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegistroUsuarioForm.UseVisualStyleBackColor = false;
            btnRegistroUsuarioForm.Click += btnRegistroUsuarioForm_Click;
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.FromArgb(26, 32, 40);
            pnlDashboard.Controls.Add(btnUsuario);
            pnlDashboard.Controls.Add(btnCompras);
            pnlDashboard.Controls.Add(btnMenu);
            pnlDashboard.Controls.Add(btnProductos);
            pnlDashboard.Controls.Add(btnEmpleados);
            pnlDashboard.Controls.Add(btnClientes);
            pnlDashboard.Controls.Add(btnVentas);
            pnlDashboard.Controls.Add(btnRegistroUsuarioForm);
            pnlDashboard.Controls.Add(pnlSubReportes);
            pnlDashboard.Controls.Add(btnReportes);
            pnlDashboard.Dock = DockStyle.Left;
            pnlDashboard.ForeColor = SystemColors.ActiveCaption;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(200, 610);
            pnlDashboard.TabIndex = 1;
            // 
            // btnUsuario
            // 
            btnUsuario.BackColor = Color.FromArgb(26, 32, 40);
            btnUsuario.Cursor = Cursors.Hand;
            btnUsuario.FlatAppearance.BorderSize = 0;
            btnUsuario.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnUsuario.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnUsuario.FlatStyle = FlatStyle.Flat;
            btnUsuario.Font = new Font("Segoe UI", 12F);
            btnUsuario.ForeColor = Color.Transparent;
            btnUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuario.Location = new Point(0, 50);
            btnUsuario.Margin = new Padding(3, 2, 3, 2);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Size = new Size(200, 35);
            btnUsuario.TabIndex = 14;
            btnUsuario.Text = "Usuario";
            btnUsuario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuario.UseVisualStyleBackColor = false;
            btnUsuario.Click += btnUsuario_Click_1;
            // 
            // btnCompras
            // 
            btnCompras.BackColor = Color.FromArgb(26, 32, 40);
            btnCompras.Cursor = Cursors.Hand;
            btnCompras.FlatAppearance.BorderSize = 0;
            btnCompras.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnCompras.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnCompras.FlatStyle = FlatStyle.Flat;
            btnCompras.Font = new Font("Segoe UI", 12F);
            btnCompras.ForeColor = Color.Transparent;
            btnCompras.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras.Location = new Point(-1, 134);
            btnCompras.Margin = new Padding(3, 2, 3, 2);
            btnCompras.Name = "btnCompras";
            btnCompras.Size = new Size(200, 35);
            btnCompras.TabIndex = 13;
            btnCompras.Text = "Compras";
            btnCompras.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCompras.UseVisualStyleBackColor = false;
            btnCompras.Click += btnCompras_Click;
            // 
            // btnMenu
            // 
            btnMenu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Image = (Image)resources.GetObject("btnMenu.Image");
            btnMenu.Location = new Point(145, 1);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(54, 47);
            btnMenu.TabIndex = 3;
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.FromArgb(26, 32, 40);
            btnProductos.Cursor = Cursors.Hand;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnProductos.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 12F);
            btnProductos.ForeColor = Color.Transparent;
            btnProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProductos.Location = new Point(-1, 90);
            btnProductos.Margin = new Padding(3, 2, 3, 2);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(200, 35);
            btnProductos.TabIndex = 12;
            btnProductos.Text = "Productos";
            btnProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnEmpleados
            // 
            btnEmpleados.BackColor = Color.FromArgb(26, 32, 40);
            btnEmpleados.Cursor = Cursors.Hand;
            btnEmpleados.FlatAppearance.BorderSize = 0;
            btnEmpleados.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnEmpleados.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnEmpleados.FlatStyle = FlatStyle.Flat;
            btnEmpleados.Font = new Font("Segoe UI", 12F);
            btnEmpleados.ForeColor = Color.Transparent;
            btnEmpleados.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmpleados.Location = new Point(-3, 317);
            btnEmpleados.Margin = new Padding(3, 2, 3, 2);
            btnEmpleados.Name = "btnEmpleados";
            btnEmpleados.Size = new Size(200, 35);
            btnEmpleados.TabIndex = 11;
            btnEmpleados.Text = "Empleados";
            btnEmpleados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmpleados.UseVisualStyleBackColor = false;
            btnEmpleados.Click += btnEmpleados_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(26, 32, 40);
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 12F);
            btnClientes.ForeColor = Color.Transparent;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(-1, 272);
            btnClientes.Margin = new Padding(3, 2, 3, 2);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(200, 35);
            btnClientes.TabIndex = 10;
            btnClientes.Text = "Clientes";
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.FromArgb(26, 32, 40);
            btnVentas.Cursor = Cursors.Hand;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnVentas.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 12F);
            btnVentas.ForeColor = Color.Transparent;
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(-3, 226);
            btnVentas.Margin = new Padding(3, 2, 3, 2);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(200, 35);
            btnVentas.TabIndex = 9;
            btnVentas.Text = "Ventas";
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // pnlSubReportes
            // 
            pnlSubReportes.BackColor = Color.FromArgb(26, 32, 40);
            pnlSubReportes.Controls.Add(panel6);
            pnlSubReportes.Controls.Add(panel5);
            pnlSubReportes.Controls.Add(panel4);
            pnlSubReportes.Controls.Add(panel2);
            pnlSubReportes.Controls.Add(panel1);
            pnlSubReportes.Controls.Add(panel3);
            pnlSubReportes.Controls.Add(btnRtpMovimientos);
            pnlSubReportes.Controls.Add(btnRptInventario);
            pnlSubReportes.Location = new Point(44, 400);
            pnlSubReportes.Name = "pnlSubReportes";
            pnlSubReportes.Size = new Size(155, 74);
            pnlSubReportes.TabIndex = 0;
            pnlSubReportes.Visible = false;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(0, 80, 200);
            panel6.Location = new Point(1, 1);
            panel6.Name = "panel6";
            panel6.Size = new Size(5, 35);
            panel6.TabIndex = 16;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(0, 80, 200);
            panel5.Location = new Point(1, 36);
            panel5.Name = "panel5";
            panel5.Size = new Size(5, 35);
            panel5.TabIndex = 15;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 80, 200);
            panel4.Location = new Point(1, 71);
            panel4.Name = "panel4";
            panel4.Size = new Size(5, 35);
            panel4.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 80, 200);
            panel2.Location = new Point(1, 138);
            panel2.Name = "panel2";
            panel2.Size = new Size(5, 35);
            panel2.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 80, 200);
            panel1.Location = new Point(1, 172);
            panel1.Name = "panel1";
            panel1.Size = new Size(5, 35);
            panel1.TabIndex = 13;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 80, 200);
            panel3.Location = new Point(1, 104);
            panel3.Name = "panel3";
            panel3.Size = new Size(5, 35);
            panel3.TabIndex = 15;
            // 
            // btnRtpMovimientos
            // 
            btnRtpMovimientos.BackColor = Color.FromArgb(26, 32, 40);
            btnRtpMovimientos.Cursor = Cursors.Hand;
            btnRtpMovimientos.FlatAppearance.BorderSize = 0;
            btnRtpMovimientos.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRtpMovimientos.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnRtpMovimientos.FlatStyle = FlatStyle.Flat;
            btnRtpMovimientos.Font = new Font("Segoe UI", 12F);
            btnRtpMovimientos.ForeColor = Color.Transparent;
            btnRtpMovimientos.ImageAlign = ContentAlignment.MiddleLeft;
            btnRtpMovimientos.Location = new Point(6, 36);
            btnRtpMovimientos.Margin = new Padding(3, 2, 3, 2);
            btnRtpMovimientos.Name = "btnRtpMovimientos";
            btnRtpMovimientos.Size = new Size(195, 35);
            btnRtpMovimientos.TabIndex = 11;
            btnRtpMovimientos.Text = "Movimientos";
            btnRtpMovimientos.TextAlign = ContentAlignment.MiddleLeft;
            btnRtpMovimientos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRtpMovimientos.UseVisualStyleBackColor = false;
            btnRtpMovimientos.Click += btnRtpMovimientos_Click;
            // 
            // btnRptInventario
            // 
            btnRptInventario.BackColor = Color.FromArgb(26, 32, 40);
            btnRptInventario.Cursor = Cursors.Hand;
            btnRptInventario.FlatAppearance.BorderSize = 0;
            btnRptInventario.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRptInventario.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnRptInventario.FlatStyle = FlatStyle.Flat;
            btnRptInventario.Font = new Font("Segoe UI", 12F);
            btnRptInventario.ForeColor = Color.Transparent;
            btnRptInventario.ImageAlign = ContentAlignment.MiddleLeft;
            btnRptInventario.Location = new Point(6, 0);
            btnRptInventario.Margin = new Padding(3, 2, 3, 2);
            btnRptInventario.Name = "btnRptInventario";
            btnRptInventario.Size = new Size(195, 35);
            btnRptInventario.TabIndex = 11;
            btnRptInventario.Text = "Inventario";
            btnRptInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnRptInventario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRptInventario.UseVisualStyleBackColor = false;
            btnRptInventario.Click += btnRptInventario_Click;
            // 
            // pnlContenedorForm
            // 
            pnlContenedorForm.BackColor = Color.FromArgb(49, 66, 82);
            pnlContenedorForm.Dock = DockStyle.Fill;
            pnlContenedorForm.Location = new Point(200, 0);
            pnlContenedorForm.Name = "pnlContenedorForm";
            pnlContenedorForm.Size = new Size(1100, 610);
            pnlContenedorForm.TabIndex = 2;
            // 
            // tmExpandirMenu
            // 
            tmExpandirMenu.Tick += tmExpandirMenu_Tick;
            // 
            // tmContraerMenu
            // 
            tmContraerMenu.Tick += tmContraerMenu_Tick;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 610);
            Controls.Add(pnlContenedorForm);
            Controls.Add(pnlDashboard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            Text = "MenuForm";
            pnlDashboard.ResumeLayout(false);
            pnlSubReportes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlDashboard;
        private Panel pnlContenedorForm;
        private System.Windows.Forms.Timer tmExpandirMenu;
        private System.Windows.Forms.Timer tmContraerMenu;
        private Button btnRegistroUsuarioForm;
        private Button btnReportes;
        private Panel pnlSubReportes;
        private Button btnRptInventario;
        private Button btnRptVentas;
        private Button btnRptProveedores;
        private Button btnRtpMovimientos;
        private Button btnRptProductos;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel6;
        private Button btnVentas;
        private Button btnClientes;
        private Button btnProductos;
        private Button btnEmpleados;
        private Button btnMenu;
        private Button btnCompras;
        private Button btnUsuario;
    }
}