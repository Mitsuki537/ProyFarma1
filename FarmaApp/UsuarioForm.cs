using BCrypt.Net;
using SharedModels;
using SharedModels.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaApp
{
    public partial class UsuarioForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        private List<UsuarioDto> usuarios;
        public UsuarioForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            usuarios = new List<UsuarioDto>();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvUsuarios.ClearSelection();
        }

        private void ClearInputs()
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtRol.Clear();
            cboEmpleado.SelectedIndex = -1;
            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaModificacion.Value = DateTime.Now;
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var usuarioSeleccionado = (UsuarioDto)dgvUsuarios.Rows[e.RowIndex].DataBoundItem as UsuarioDto;
                SetValuesToInputs(usuarioSeleccionado);
            }
        }

        private void SetValuesToInputs(UsuarioDto usuario)
        {
            txtUsuario.Text = usuario.Username;
            txtRol.Text = usuario.Role;
            cboEmpleado.SelectedValue = usuario.IdEmployee;
            dtpFechaCreacion.Value = usuario.CreatedDate ?? DateTime.Now;
            dtpFechaModificacion.Value = usuario.ModifiedDate ?? DateTime.Now;
        }

        private void SetInputs(UsuarioDto usuario)
        {
            txtUsuario.Text = usuario.Username;
            txtContraseña.Text = usuario.PasswordHash;
            txtRol.Text = usuario.Role;
            cboEmpleado.SelectedValue = usuario.IdEmployee;
            dtpFechaCreacion.Value = usuario.CreatedDate ?? DateTime.Now;
            dtpFechaModificacion.Value = usuario.ModifiedDate ?? DateTime.Now;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevoUsuario = new UsuarioCreateDto
                {
                    Username = txtUsuario.Text.Trim(),
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(txtContraseña.Text.Trim()), // Generar el hash
                    IdEmployee = (int)cboEmpleado.SelectedValue,
                    Role = txtRol.Text.Trim()
                };

                var newUserId = await _apiClient.Usuario.CreateAsync(nuevoUsuario);

                await LoadUsuariosAsync();

                MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUsuariosAsync()
        {
            try
            {
                var usuarios = await _apiClient.Usuario.GetAllAsync();
                /*
                dgvUsuarios.DataSource = null; 
                dgvUsuarios.DataSource = usuarios?.ToList() ?? new List<UsuarioDto>();
                */
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async Task LoadEmpleadosAsync()
        {
            try
            {
                var empleados = await _apiClient.Empleados.GetAllAsync();

                if (empleados != null && empleados.Any())
                {
                    cboEmpleado.DataSource = empleados.ToList();
                    cboEmpleado.DisplayMember = "FirstName";
                    cboEmpleado.ValueMember = "IdEmployee";
                }
                else
                {
                    cboEmpleado.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private UsuarioDto GetValuesFromInputs()
        {
            if (cboEmpleado.SelectedValue == null)
            {
                throw new Exception("Seleccione un empleado válido.");
            }

            return new UsuarioDto
            {
                Username = txtUsuario.Text.Trim(),
                PasswordHash = string.IsNullOrEmpty(txtContraseña.Text.Trim()) ? null : BCrypt.Net.BCrypt.HashPassword(txtContraseña.Text.Trim()),
                Role = txtRol.Text.Trim(),
                IdEmployee = Convert.ToInt32(cboEmpleado.SelectedValue),
                CreatedDate = dtpFechaCreacion.Value,
                ModifiedDate = dtpFechaModificacion.Value
            };
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                try
                {
                    var usuarioSeleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as UsuarioDto;
                    var valoresActualizados = GetValuesFromInputs();

                    if (string.IsNullOrEmpty(txtContraseña.Text.Trim()))
                    {
                        valoresActualizados.PasswordHash = usuarioSeleccionado.PasswordHash;
                    }

                    valoresActualizados.IdUser = usuarioSeleccionado.IdUser;
                    await _apiClient.Usuario.UpdateAsync(usuarioSeleccionado.IdUser, valoresActualizados);
                    await LoadUsuariosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                try
                {
                    var usuarioSeleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as UsuarioDto;
                    if (usuarioSeleccionado != null && usuarioSeleccionado.IdUser > 0)
                    {
                        await _apiClient.Usuario.DeleteAsync(usuarioSeleccionado.IdUser);
                        await LoadUsuariosAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private async void UsuarioForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadUsuariosAsync();
                await LoadEmpleadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var usuarioSeleccionado = (UsuarioDto)dgvUsuarios.SelectedRows[0].DataBoundItem;
                SetValuesToInputs(usuarioSeleccionado);
            }
        }
    }
}
