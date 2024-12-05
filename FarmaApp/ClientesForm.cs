using FarmaApp.Repository;
using SharedModels;
using SharedModels.Cliente;
using SharedModels.Dtos.Cliente;
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
    public partial class ClientesForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        private List<ClienteDto> clientes;
        public ClientesForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            clientes = new List<ClienteDto>();
        }
        private void ClearInputs()
        {
            txtCliente.Clear();
            txtApellido.Clear();
            mtbTelefono.Clear();
            dtpFechaModificacion.Value = DateTime.Now;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvClientes.ClearSelection();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (string.IsNullOrWhiteSpace(txtCliente.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevoCliente = new ClienteCreateDto
                {
                    FirstName = txtCliente.Text.Trim(),
                    LastName = txtApellido.Text.Trim(),
                    Phone = mtbTelefono.Text.Trim()
                };

                var newClienteId = await _apiClient.Clientes.CreateAsync(nuevoCliente);

                var clienteDto = new ClienteDto
                {
                    IdCustomer = newClienteId,
                    FirstName = nuevoCliente.FirstName,
                    LastName = nuevoCliente.LastName,
                    Phone = nuevoCliente.Phone,
                    RegistrationDate = DateTime.Now
                };

                clientes.Add(clienteDto);
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = clientes;
                await LoadClientesAsync();

                MessageBox.Show("Cliente creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                try
                {
                    var clienteSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as ClienteDto;
                    if (clienteSeleccionado == null)
                    {
                        MessageBox.Show("Seleccione un cliente válido para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var clienteActualizado = new ClienteUpdateDto
                    {
                        IdCustomer = clienteSeleccionado.IdCustomer,
                        FirstName = txtCliente.Text.Trim(),
                        LastName = txtApellido.Text.Trim(),
                        Phone = mtbTelefono.Text.Trim(),
                    };

                    var actualizado = await _apiClient.Clientes.UpdateAsync(clienteSeleccionado.IdCustomer, clienteActualizado);
                    if (actualizado)
                    {
                        MessageBox.Show("Cliente actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadClientesAsync();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el cliente. Revise los datos e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                try
                {
                    var clienteSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as ClienteDto;

                    var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar a {clienteSeleccionado.FirstName} {clienteSeleccionado.LastName}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        await _apiClient.Clientes.DeleteAsync(clienteSeleccionado.IdCustomer);
                        await LoadClientesAsync();
                        MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void ClientesForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadClientesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadClientesAsync()
        {

            try
            {
                var clientes = await _apiClient.Clientes.GetAllAsync();
                dgvClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error");
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (ClienteDto)dgvClientes.SelectedRows[0].DataBoundItem;
                txtCliente.Text = clienteSeleccionado.FirstName;
                txtApellido.Text = clienteSeleccionado.LastName;
                mtbTelefono.Text = clienteSeleccionado.Phone;
                dtpFechaModificacion.Value = clienteSeleccionado.RegistrationDate;
            }
        }
    }
}
