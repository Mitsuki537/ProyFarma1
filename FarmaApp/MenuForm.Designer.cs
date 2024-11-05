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
            pnlTitulo = new Panel();
            btnUsuario = new Button();
            btnMaximizar = new Button();
            btnNormal = new Button();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            btnReportes = new Button();
            btnRegistroUsuarioForm = new Button();
            pnlDashboard = new Panel();
            btnMenu = new Button();
            btnProductos = new Button();
            btnEmpleados = new Button();
            btnClientes = new Button();
            btnVentas = new Button();
            pnlSubReportes = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            btnRptProveedores = new Button();
            panel2 = new Panel();
            btnRtpClientes = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            btnRptVentas = new Button();
            btnRptEmpleados = new Button();
            btnRptProductos = new Button();
            btnRptInventario = new Button();
            pnlContenedorForm = new Panel();
            tmExpandirMenu = new System.Windows.Forms.Timer(components);
            tmContraerMenu = new System.Windows.Forms.Timer(components);
            pnlTitulo.SuspendLayout();
            pnlDashboard.SuspendLayout();
            pnlSubReportes.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.BackColor = Color.FromArgb(0, 80, 200);
            pnlTitulo.Controls.Add(btnUsuario);
            pnlTitulo.Controls.Add(btnMaximizar);
            pnlTitulo.Controls.Add(btnNormal);
            pnlTitulo.Controls.Add(btnMinimizar);
            pnlTitulo.Controls.Add(btnCerrar);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(1300, 35);
            pnlTitulo.TabIndex = 0;
            pnlTitulo.MouseDown += pnlTitulo_MouseDown;
            // 
            // btnUsuario
            // 
            btnUsuario.Cursor = Cursors.Hand;
            btnUsuario.FlatAppearance.BorderSize = 0;
            btnUsuario.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnUsuario.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 32, 40);
            btnUsuario.FlatStyle = FlatStyle.Flat;
            btnUsuario.Font = new Font("Segoe UI", 12F);
            btnUsuario.ForeColor = Color.White;
            btnUsuario.Image = (Image)resources.GetObject("btnUsuario.Image");
            btnUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuario.Location = new Point(985, 0);
            btnUsuario.Margin = new Padding(3, 2, 3, 2);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Size = new Size(130, 35);
            btnUsuario.TabIndex = 8;
            btnUsuario.Text = "     Usuario";
            btnUsuario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuario.UseVisualStyleBackColor = true;
            btnUsuario.Click += btnUsuario_Click;
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
            btnMaximizar.Location = new Point(1197, 1);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(50, 35);
            btnMaximizar.TabIndex = 3;
            btnMaximizar.UseVisualStyleBackColor = true;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // btnNormal
            // 
            btnNormal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNormal.Cursor = Cursors.Hand;
            btnNormal.FlatAppearance.BorderSize = 0;
            btnNormal.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 32, 40);
            btnNormal.FlatStyle = FlatStyle.Flat;
            btnNormal.Image = (Image)resources.GetObject("btnNormal.Image");
            btnNormal.Location = new Point(1198, 1);
            btnNormal.Name = "btnNormal";
            btnNormal.Size = new Size(45, 35);
            btnNormal.TabIndex = 8;
            btnNormal.UseVisualStyleBackColor = true;
            btnNormal.Click += btnNormal_Click;
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
            btnMinimizar.Location = new Point(1140, -3);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(51, 40);
            btnMinimizar.TabIndex = 7;
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
            btnCerrar.Location = new Point(1250, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(45, 35);
            btnCerrar.TabIndex = 6;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnReportes
            // 
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 12F);
            btnReportes.ForeColor = Color.Transparent;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(0, 358);
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
            btnRegistroUsuarioForm.Location = new Point(-1, 130);
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
            pnlDashboard.Controls.Add(btnMenu);
            pnlDashboard.Controls.Add(btnProductos);
            pnlDashboard.Controls.Add(btnEmpleados);
            pnlDashboard.Controls.Add(btnClientes);
            pnlDashboard.Controls.Add(btnVentas);
            pnlDashboard.Controls.Add(btnRegistroUsuarioForm);
            pnlDashboard.Controls.Add(pnlSubReportes);
            pnlDashboard.Controls.Add(btnReportes);
            pnlDashboard.Dock = DockStyle.Left;
            pnlDashboard.Location = new Point(0, 35);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(200, 615);
            pnlDashboard.TabIndex = 1;
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
            btnProductos.Location = new Point(-1, 71);
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
            btnEmpleados.Location = new Point(1, 302);
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
            btnClientes.Location = new Point(1, 245);
            btnClientes.Margin = new Padding(3, 2, 3, 2);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(196, 35);
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
            btnVentas.Location = new Point(-1, 187);
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
            pnlSubReportes.Controls.Add(btnRptProveedores);
            pnlSubReportes.Controls.Add(panel2);
            pnlSubReportes.Controls.Add(btnRtpClientes);
            pnlSubReportes.Controls.Add(panel1);
            pnlSubReportes.Controls.Add(panel3);
            pnlSubReportes.Controls.Add(btnRptVentas);
            pnlSubReportes.Controls.Add(btnRptEmpleados);
            pnlSubReportes.Controls.Add(btnRptProductos);
            pnlSubReportes.Controls.Add(btnRptInventario);
            pnlSubReportes.Location = new Point(44, 394);
            pnlSubReportes.Name = "pnlSubReportes";
            pnlSubReportes.Size = new Size(155, 209);
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
            // btnRptProveedores
            // 
            btnRptProveedores.BackColor = Color.FromArgb(26, 32, 40);
            btnRptProveedores.Cursor = Cursors.Hand;
            btnRptProveedores.FlatAppearance.BorderSize = 0;
            btnRptProveedores.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRptProveedores.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnRptProveedores.FlatStyle = FlatStyle.Flat;
            btnRptProveedores.Font = new Font("Segoe UI", 12F);
            btnRptProveedores.ForeColor = Color.Transparent;
            btnRptProveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btnRptProveedores.Location = new Point(6, 1);
            btnRptProveedores.Margin = new Padding(3, 2, 3, 2);
            btnRptProveedores.Name = "btnRptProveedores";
            btnRptProveedores.Size = new Size(195, 35);
            btnRptProveedores.TabIndex = 9;
            btnRptProveedores.Text = "Proveedores";
            btnRptProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnRptProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRptProveedores.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 80, 200);
            panel2.Location = new Point(1, 138);
            panel2.Name = "panel2";
            panel2.Size = new Size(5, 35);
            panel2.TabIndex = 14;
            // 
            // btnRtpClientes
            // 
            btnRtpClientes.BackColor = Color.FromArgb(26, 32, 40);
            btnRtpClientes.Cursor = Cursors.Hand;
            btnRtpClientes.FlatAppearance.BorderSize = 0;
            btnRtpClientes.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRtpClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnRtpClientes.FlatStyle = FlatStyle.Flat;
            btnRtpClientes.Font = new Font("Segoe UI", 12F);
            btnRtpClientes.ForeColor = Color.Transparent;
            btnRtpClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnRtpClientes.Location = new Point(6, 172);
            btnRtpClientes.Margin = new Padding(3, 2, 3, 2);
            btnRtpClientes.Name = "btnRtpClientes";
            btnRtpClientes.Size = new Size(195, 35);
            btnRtpClientes.TabIndex = 12;
            btnRtpClientes.Text = "Clientes";
            btnRtpClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnRtpClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRtpClientes.UseVisualStyleBackColor = false;
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
            // btnRptVentas
            // 
            btnRptVentas.BackColor = Color.FromArgb(26, 32, 40);
            btnRptVentas.Cursor = Cursors.Hand;
            btnRptVentas.FlatAppearance.BorderSize = 0;
            btnRptVentas.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRptVentas.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnRptVentas.FlatStyle = FlatStyle.Flat;
            btnRptVentas.Font = new Font("Segoe UI", 12F);
            btnRptVentas.ForeColor = Color.Transparent;
            btnRptVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnRptVentas.Location = new Point(6, 35);
            btnRptVentas.Margin = new Padding(3, 2, 3, 2);
            btnRptVentas.Name = "btnRptVentas";
            btnRptVentas.Size = new Size(195, 35);
            btnRptVentas.TabIndex = 10;
            btnRptVentas.Text = "Ventas";
            btnRptVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnRptVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRptVentas.UseVisualStyleBackColor = false;
            // 
            // btnRptEmpleados
            // 
            btnRptEmpleados.BackColor = Color.FromArgb(26, 32, 40);
            btnRptEmpleados.Cursor = Cursors.Hand;
            btnRptEmpleados.FlatAppearance.BorderSize = 0;
            btnRptEmpleados.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRptEmpleados.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnRptEmpleados.FlatStyle = FlatStyle.Flat;
            btnRptEmpleados.Font = new Font("Segoe UI", 12F);
            btnRptEmpleados.ForeColor = Color.Transparent;
            btnRptEmpleados.ImageAlign = ContentAlignment.MiddleLeft;
            btnRptEmpleados.Location = new Point(6, 139);
            btnRptEmpleados.Margin = new Padding(3, 2, 3, 2);
            btnRptEmpleados.Name = "btnRptEmpleados";
            btnRptEmpleados.Size = new Size(195, 35);
            btnRptEmpleados.TabIndex = 11;
            btnRptEmpleados.Text = "Empleados";
            btnRptEmpleados.TextAlign = ContentAlignment.MiddleLeft;
            btnRptEmpleados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRptEmpleados.UseVisualStyleBackColor = false;
            // 
            // btnRptProductos
            // 
            btnRptProductos.BackColor = Color.FromArgb(26, 32, 40);
            btnRptProductos.Cursor = Cursors.Hand;
            btnRptProductos.FlatAppearance.BorderSize = 0;
            btnRptProductos.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRptProductos.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnRptProductos.FlatStyle = FlatStyle.Flat;
            btnRptProductos.Font = new Font("Segoe UI", 12F);
            btnRptProductos.ForeColor = Color.Transparent;
            btnRptProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnRptProductos.Location = new Point(6, 70);
            btnRptProductos.Margin = new Padding(3, 2, 3, 2);
            btnRptProductos.Name = "btnRptProductos";
            btnRptProductos.Size = new Size(195, 35);
            btnRptProductos.TabIndex = 12;
            btnRptProductos.Text = "Productos";
            btnRptProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnRptProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRptProductos.UseVisualStyleBackColor = false;
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
            btnRptInventario.Location = new Point(6, 104);
            btnRptInventario.Margin = new Padding(3, 2, 3, 2);
            btnRptInventario.Name = "btnRptInventario";
            btnRptInventario.Size = new Size(195, 35);
            btnRptInventario.TabIndex = 11;
            btnRptInventario.Text = "Inventario";
            btnRptInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnRptInventario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRptInventario.UseVisualStyleBackColor = false;
            // 
            // pnlContenedorForm
            // 
            pnlContenedorForm.BackColor = Color.FromArgb(49, 66, 82);
            pnlContenedorForm.Dock = DockStyle.Fill;
            pnlContenedorForm.Location = new Point(200, 35);
            pnlContenedorForm.Name = "pnlContenedorForm";
            pnlContenedorForm.Size = new Size(1100, 615);
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
            ClientSize = new Size(1300, 650);
            Controls.Add(pnlContenedorForm);
            Controls.Add(pnlDashboard);
            Controls.Add(pnlTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            Text = "MenuForm";
            pnlTitulo.ResumeLayout(false);
            pnlDashboard.ResumeLayout(false);
            pnlSubReportes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Panel pnlDashboard;
        private Panel pnlContenedorForm;
        private Button btnCerrar;
        private Button btnMaximizar;
        private Button btnNormal;
        private Button btnMinimizar;
        private System.Windows.Forms.Timer tmExpandirMenu;
        private System.Windows.Forms.Timer tmContraerMenu;
        private Button btnRegistroUsuarioForm;
        private Button btnReportes;
        private Panel pnlSubReportes;
        private Button btnRptInventario;
        private Button btnRptVentas;
        private Button btnRptProveedores;
        private Button btnRptEmpleados;
        private Button btnRptProductos;
        private Button btnRtpClientes;
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
        private Button btnUsuario;
        private Button btnMenu;
    }
}