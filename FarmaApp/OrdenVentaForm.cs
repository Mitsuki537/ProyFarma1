using SharedModels.Dtos.OrdenVenta;
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
    public partial class OrdenVentaForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        private List<OrdenVentaDto> ordenesVenta;
        public OrdenVentaForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            ordenesVenta = new List<OrdenVentaDto>();
        }
        private void ClearInputs()
        {
            cboEmpleado.SelectedIndex = -1;
            cboCliente.SelectedIndex = -1;
            dtpFechaOrden.Value = DateTime.Now;
            dgvOrdenVenta.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvOrdenVenta.ClearSelection();
        }

        private async void OrdenVentaForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadOrdenesVentaAsync();
                await LoadClientesAsync();
                await LoadEmpleadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadEmpleadosAsync()
        {
            try
            {
                var empleados = await _apiClient.Empleados.GetAllAsync();
                cboEmpleado.DataSource = empleados;
                cboEmpleado.DisplayMember = "EmployeeName";
                cboEmpleado.ValueMember = "IdEmployee";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadClientesAsync()
        {
            try
            {
                var clientes = await _apiClient.Clientes.GetAllAsync();
                cboCliente.DataSource = clientes;
                cboCliente.DisplayMember = "ClientName";
                cboCliente.ValueMember = "IdCustomer";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadOrdenesVentaAsync()
        {
            try
            {
                ordenesVenta = (await _apiClient.OrdenesVenta.GetAllAsync()).ToList();
                dgvOrdenVenta.DataSource = ordenesVenta;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las órdenes de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboEmpleado.SelectedIndex == -1 || cboCliente.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevaOrden = new OrdenVentaCreateDto
                {
                    IdCustomer = (int)cboCliente.SelectedValue,
                    IdEmployee = (int)cboEmpleado.SelectedValue,
                    OrderDate = dtpFechaOrden.Value
                };

                var newOrdenId = await _apiClient.OrdenesVenta.CreateAsync(nuevaOrden);

                await LoadOrdenesVentaAsync();
                MessageBox.Show("Orden de venta creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la orden de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenVenta.SelectedRows.Count > 0)
            {
                try
                {
                    var ordenSeleccionada = dgvOrdenVenta.SelectedRows[0].DataBoundItem as OrdenVentaDto;

                    var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar la orden seleccionada?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        await _apiClient.OrdenesVenta.DeleteAsync(ordenSeleccionada.IdSalesOrder);
                        await LoadOrdenesVentaAsync();
                        MessageBox.Show("Orden de venta eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la orden de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una orden de venta para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenVenta.SelectedRows.Count > 0)
            {
                try
                {

                    var ordenSeleccionada = dgvOrdenVenta.SelectedRows[0].DataBoundItem as OrdenVentaDto;
                    if (ordenSeleccionada == null) return;

                    if (cboEmpleado.SelectedIndex == -1 || cboCliente.SelectedIndex == -1)
                    {
                        MessageBox.Show("Por favor, complete los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var ordenActualizada = new OrdenVentaUpdateDto
                    {
                        IdSalesOrder = ordenSeleccionada.IdSalesOrder,
                        IdCustomer = (int)cboCliente.SelectedValue,
                        IdEmployee = (int)cboEmpleado.SelectedValue,
                        OrderDate = dtpFechaOrden.Value,
                        ModifiedDate = DateTime.Now 
                    };

                    var actualizado = await _apiClient.OrdenesVenta.UpdateAsync(ordenSeleccionada.IdSalesOrder, ordenActualizada);

                    if (actualizado)
                    {
                        MessageBox.Show("Orden de venta actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadOrdenesVentaAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la orden de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una orden de venta para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvOrdenVenta_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdenVenta.SelectedRows.Count > 0)
            {
                var ordenSeleccionada = (OrdenVentaDto)dgvOrdenVenta.SelectedRows[0].DataBoundItem;
                cboCliente.SelectedValue = ordenSeleccionada.IdCustomer;
                cboEmpleado.SelectedValue = ordenSeleccionada.IdEmployee;
                dtpFechaOrden.Value = ordenSeleccionada.OrderDate;
            }
        }
    }
}
