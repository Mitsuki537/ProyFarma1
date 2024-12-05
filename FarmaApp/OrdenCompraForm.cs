using SharedModels.Dtos.OrdenCompra;
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
    public partial class OrdenCompraForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        private List<OrdenCompraDto> ordenesCompra;

        public OrdenCompraForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            ordenesCompra = new List<OrdenCompraDto>();
        }
        private void ClearInputs()
        {
            cboProveedor.SelectedIndex = -1;
            dtpFechaOrden.Value = DateTime.Now;
            cboEstado.SelectedIndex = -1;
            dgvOrdenCompra.ClearSelection();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvOrdenCompra.ClearSelection();
        }

        private async void OrdenCompraForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadOrdenesCompraAsync();
                await LoadProveedoresAsync();
                CargarEstados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEstados()
        {
            var estados = new List<string> { "Pendiente", "Completada", "Cancelada" };
            cboEstado.DataSource = estados;
        }

        private async Task LoadProveedoresAsync()
        {
            try
            {
                var proveedores = await _apiClient.Proveedores.GetAllAsync();
                cboProveedor.DataSource = proveedores;
                cboProveedor.DisplayMember = "SupplierName"; 
                cboProveedor.ValueMember = "IdSupplier";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadOrdenesCompraAsync()
        {
            try
            {
                ordenesCompra = (await _apiClient.OrdenesCompra.GetAllAsync()).ToList();
                dgvOrdenCompra.DataSource = ordenesCompra;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las órdenes de compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProveedor.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cboEstado.Text))
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevaOrden = new OrdenCompraCreateDto
                {
                    IdSupplier = (int)cboProveedor.SelectedValue,
                    OrderDate = dtpFechaOrden.Value,
                    Status = cboEstado.Text.Trim()
                };

                var newOrdenId = await _apiClient.OrdenesCompra.CreateAsync(nuevaOrden);

                var ordenDto = new OrdenCompraDto
                {
                    IdPurchaseOrder = newOrdenId,
                    IdSupplier = nuevaOrden.IdSupplier,
                    OrderDate = nuevaOrden.OrderDate,
                    Status = nuevaOrden.Status,
                    ModifiedDate = DateTime.Now
                };

                ordenesCompra.Add(ordenDto);
                dgvOrdenCompra.DataSource = null;
                dgvOrdenCompra.DataSource = ordenesCompra;
                await LoadOrdenesCompraAsync();
                MessageBox.Show("Orden de compra creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la orden de compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenCompra.SelectedRows.Count > 0)
            {
                try
                {
                    var ordenSeleccionada = dgvOrdenCompra.SelectedRows[0].DataBoundItem as OrdenCompraDto;
                    if (ordenSeleccionada == null) return;

                    var ordenActualizada = new OrdenCompraUpdateDto
                    {
                        IdPurchaseOrder = ordenSeleccionada.IdPurchaseOrder,
                        IdSupplier = (int)cboProveedor.SelectedValue,
                        OrderDate = dtpFechaOrden.Value,
                        Status = cboEstado.Text.Trim(),
                        ModifiedDate = DateTime.Now
                    };

                    var actualizado = await _apiClient.OrdenesCompra.UpdateAsync(ordenSeleccionada.IdPurchaseOrder, ordenActualizada);

                    if (actualizado)
                    {
                        MessageBox.Show("Orden de compra actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadOrdenesCompraAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la orden de compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una orden de compra para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenCompra.SelectedRows.Count > 0)
            {
                try
                {
                    var ordenSeleccionada = dgvOrdenCompra.SelectedRows[0].DataBoundItem as OrdenCompraDto;

                    var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar la orden seleccionada?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        await _apiClient.OrdenesCompra.DeleteAsync(ordenSeleccionada.IdPurchaseOrder);
                        await LoadOrdenesCompraAsync();
                        MessageBox.Show("Orden de compra eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la orden de compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una orden de compra para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvOrdenCompra_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdenCompra.SelectedRows.Count > 0)
            {
                var ordenSeleccionada = (OrdenCompraDto)dgvOrdenCompra.SelectedRows[0].DataBoundItem;
                cboProveedor.SelectedValue = ordenSeleccionada.IdSupplier;
                dtpFechaOrden.Value = ordenSeleccionada.OrderDate;
                cboEstado.Text = ordenSeleccionada.Status;
            }
        }
    }
}
