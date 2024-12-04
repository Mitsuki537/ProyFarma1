using SharedModels.Dtos.Compras;
using SharedModels.Dtos.Proveedor;
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
    public partial class ProveedoresForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        private List<ProveedorDto> proveedores;
        public ProveedoresForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            proveedores = new List<ProveedorDto>();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvProveedores.ClearSelection();
        }

        private void ClearInputs()
        {
            txtProveedor.Clear();
            txtNombreContacto.Clear();
            txtTitulo.Clear();
            mtbTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtPais.Clear();
            txtCodigoPostal.Clear();
            dtpFechaModificacion.Value = DateTime.Now;
        }

        private async void ProveedoresForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadProveedoresAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProveedoresAsync()
        {
            try
            {
                var proveedores = await _apiClient.Proveedores.GetAllAsync();
                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = proveedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProveedor.Text) || string.IsNullOrWhiteSpace(txtNombreContacto.Text))
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevoProveedor = new ProveedorCreateDto
                {
                    SupplierName = txtProveedor.Text.Trim(),
                    ContactName = txtNombreContacto.Text.Trim(),
                    ContactTitle = txtTitulo.Text.Trim(),
                    Phone = mtbTelefono.Text.Trim(),
                    Email = txtCorreo.Text.Trim(),
                    Address = txtDireccion.Text.Trim(),
                    City = txtCiudad.Text.Trim(),
                    Country = txtPais.Text.Trim(),
                    PostalCode = txtCodigoPostal.Text.Trim()
                };

                var newProveedorId = await _apiClient.Proveedores.CreateAsync(nuevoProveedor);
                await LoadProveedoresAsync();

                MessageBox.Show("Proveedor creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                try
                {
                    // Intenta obtener el proveedor seleccionado.
                    var proveedorSeleccionado = dgvProveedores.SelectedRows[0].DataBoundItem as ProveedorDto;

                    if (proveedorSeleccionado == null)
                    {
                        MessageBox.Show("Seleccione un proveedor válido para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Prepara el objeto actualizado.
                    var proveedorActualizado = new ProveedorUpdateDto
                    {
                        IdSupplier = proveedorSeleccionado.IdSupplier,
                        SupplierName = txtProveedor.Text.Trim(),
                        ContactName = txtNombreContacto.Text.Trim(),
                        ContactTitle = txtTitulo.Text.Trim(),
                        Phone = mtbTelefono.Text.Trim(),
                        Email = txtCorreo.Text.Trim(),
                        Address = txtDireccion.Text.Trim(),
                        City = txtCiudad.Text.Trim(),
                        Country = txtPais.Text.Trim(),
                        PostalCode = txtCodigoPostal.Text.Trim(),
                        ModifiedDate = DateTime.Now
                    };

                    if (string.IsNullOrWhiteSpace(proveedorActualizado.SupplierName) || string.IsNullOrWhiteSpace(proveedorActualizado.ContactName))
                    {
                        MessageBox.Show("El nombre del proveedor y el contacto son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Llamar al método de actualización.
                    bool actualizado = await _apiClient.Proveedores.UpdateAsync(proveedorActualizado.IdSupplier, proveedorActualizado);

                    if (actualizado)
                    {
                        MessageBox.Show("Proveedor actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadProveedoresAsync();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el proveedor. Revise los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                try
                {
                    // Intenta obtener el proveedor seleccionado.
                    var proveedorSeleccionado = dgvProveedores.SelectedRows[0].DataBoundItem as ProveedorDto;

                    if (proveedorSeleccionado == null)
                    {
                        MessageBox.Show("Seleccione un proveedor válido para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Confirmación de eliminación.
                    var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar a {proveedorSeleccionado.SupplierName}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        // Llamar al método de eliminación.
                        bool eliminado = await _apiClient.Proveedores.DeleteAsync(proveedorSeleccionado.IdSupplier);
                        if (eliminado)
                        {
                            MessageBox.Show("Proveedor eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadProveedoresAsync();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var proveedorSeleccionado = (ProveedorDto)dgvProveedores.SelectedRows[0].DataBoundItem;
                txtProveedor.Text = proveedorSeleccionado.SupplierName;
                txtNombreContacto.Text = proveedorSeleccionado.ContactName;
                txtTitulo.Text = proveedorSeleccionado.ContactTitle;
                mtbTelefono.Text = proveedorSeleccionado.Phone;
                txtCorreo.Text = proveedorSeleccionado.Email;
                txtDireccion.Text = proveedorSeleccionado.Address;
                txtCiudad.Text = proveedorSeleccionado.City;
                txtPais.Text = proveedorSeleccionado.Country;
                txtCodigoPostal.Text = proveedorSeleccionado.PostalCode;
                dtpFechaModificacion.Value = proveedorSeleccionado.ModifiedDate /*?? DateTime.Now*/;
            }
        }
    }
}
