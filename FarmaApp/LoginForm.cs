using FarmaApp.Properties;
using Newtonsoft.Json;
using SharedModels.Dtos.Usuario;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Text;

namespace FarmaApp
{
    public partial class LoginForm : Form
    {
        private int failedAttempts = 0;
        private bool isLocked = false;
        private int lockoutTimeRemaining;
        private System.Windows.Forms.Timer lockoutTimer;
        private ErrorProvider errorProvider;
        private Size originalSize;
        private Point originalLocation;

        public LoginForm()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            InitializeLockoutTimer();
            txtPassword.UseSystemPasswordChar = true;

            pbShowPassword.Visible = true;
            pbHidePassword.Visible = false;

            pbShowPassword.Click += PbShowPassword_Click;
            pbHidePassword.Click += PbHidePassword_Click;
            lblStatus.Text = "Intentos restantes: 5";
            originalSize = this.Size;
            originalLocation = this.Location;

            btnNormal.Visible = false;
        }

        private void PbShowPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            pbShowPassword.Visible = false;
            pbHidePassword.Visible = true;
        }

        private void PbHidePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            pbHidePassword.Visible = false;
            pbShowPassword.Visible = true;
        }

        private void InitializeLockoutTimer()
        {
            lockoutTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            lockoutTimer.Tick += LockoutTimer_Tick;
        }

        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            lockoutTimeRemaining--;

            if (lockoutTimeRemaining <= 0)
            {
                lockoutTimer.Stop();
                isLocked = false;
                failedAttempts = 0;
                lblStatus.Text = "";
                btnLogin.Enabled = true;
            }
            else
            {
                lblStatus.Text = $"Intenta de nuevo en {lockoutTimeRemaining} segundos";
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            /*if (isLocked)
            {
                lblStatus.Text = "El acceso está bloqueado temporalmente. Intenta más tarde.";
                return;
            }*/

            bool hasErrors = false;

            // Validar usuario
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text == "Usuario")
            {
                errorProvider.SetError(txtEmail, "El nombre de usuario es requerido.");
                hasErrors = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, "");
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text == "Contraseña")
            {
                errorProvider.SetError(txtPassword, "La contraseña es requerida.");
                hasErrors = true;
            }
            else
            {
                errorProvider.SetError(txtPassword, "");
            }

            if (hasErrors)
                return;

            try
            {
                string uri = ConfigurationManager.AppSettings["ApiBaseUrl"];
                var http = new HttpClient { BaseAddress = new Uri(uri) };

                UserLoginDto loginDto = new UserLoginDto
                {
                    Username = txtEmail.Text,
                    Password = txtPassword.Text
                };

                var json = JsonConvert.SerializeObject(loginDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await http.PostAsync("api/Auth/login", content);

                if (!response.IsSuccessStatusCode)
                {
                    failedAttempts++;

                    if (failedAttempts >= 5)
                    {
                        LockAccount();
                    }
                    else
                    {
                        lblStatus.Text = $"Intentos restantes: {5 - failedAttempts}";
                        errorProvider.SetError(txtPassword, "Credenciales incorrectas.");
                    }
                    return;
                }

                var dataString = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(dataString);

                lblStatus.Text = "Usuario autenticado correctamente.";
                CargarMenuEnPanel(tokenResponse.Token);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al iniciar sesión: {ex.Message}";
            }
        }

        private void CargarMenuEnPanel(string token)
        {
            MenuForm menu = new MenuForm { Token = token };
            menu.TopLevel = false;
            menu.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(menu);
            menu.Show();
        }

        private void LockAccount()
        {
            isLocked = true;
            lockoutTimeRemaining = 30;
            btnLogin.Enabled = false;
            lblStatus.Text = $"Intenta de nuevo en {lockoutTimeRemaining} segundos.";
            lockoutTimer.Start();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Size = originalSize;
            this.Location = originalLocation;
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click_1(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;
        }

        private void btnNormal_Click_1(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }
    }
}
