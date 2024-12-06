using SharedModels.Dtos.DetalleOrdenCompra;
using SharedModels.Dtos.DetalleOrdenVenta;
using SharedModels.Dtos.OrdenVenta;
using SharedModels.Dtos.Producto;
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
    public partial class DetalleOrdenVentaForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        private List<DetalleOrdenVentaDto> detallesOrdenVenta;
        private List<OrdenVentaDto> ordenesVenta;
        private List<ProductoDto> productos;

        public DetalleOrdenVentaForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            detallesOrdenVenta = new List<DetalleOrdenVentaDto>();
            ordenesVenta = new List<OrdenVentaDto>();
            productos = new List<ProductoDto>();
        }

        private void ClearInputs()
        {
            txtPrecioUnitario.Clear();
            txtCantidad.Clear();
            cboProducto.SelectedIndex = -1;
            cboNumeroOrden.SelectedIndex = -1;
            cboIdOrdenVenta.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvDetalleOrdenVenta.ClearSelection();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboIdOrdenVenta.SelectedIndex == -1 || cboProducto.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var idOrdenSeleccionada = Convert.ToInt32(cboIdOrdenVenta.SelectedValue);
                var numeroOrdenSeleccionada = cboNumeroOrden.Text;

                var ordenSeleccionada = ordenesVenta.FirstOrDefault(o => o.IdSalesOrder == idOrdenSeleccionada);

                if (ordenSeleccionada == null || ordenSeleccionada.OrderNumber != numeroOrdenSeleccionada)
                {
                    MessageBox.Show("El Id de la Orden de Venta y el Número de Orden no coinciden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevoDetalle = new DetalleOrdenVentaCreateDto
                {
                    IdSalesOrder = Convert.ToInt32(cboIdOrdenVenta.SelectedValue),
                    IdProduct = Convert.ToInt32(cboProducto.SelectedValue),
                    Quantity = int.Parse(txtCantidad.Text),
                    UnitPrice = decimal.Parse(txtPrecioUnitario.Text),
                    OrderNumber = cboNumeroOrden.Text
                };

                var newDetalleId = await _apiClient.DetallesOrdenVenta.CreateAsync(nuevoDetalle);

                var detalleDto = new DetalleOrdenVentaDto
                {
                    IdSalesOrderDetail = newDetalleId,
                    IdSalesOrder = nuevoDetalle.IdSalesOrder,
                    IdProduct = nuevoDetalle.IdProduct,
                    Quantity = nuevoDetalle.Quantity,
                    UnitPrice = nuevoDetalle.UnitPrice,
                    OrderNumber = nuevoDetalle.OrderNumber
                };

                detallesOrdenVenta.Add(detalleDto);
                dgvDetalleOrdenVenta.DataSource = null;
                dgvDetalleOrdenVenta.DataSource = detallesOrdenVenta;

                await LoadDetallesOrdenVentaAsync();
                MessageBox.Show("Detalle de orden de venta guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task LoadOrdenesVentaAsync()
        {
            try
            {
                ordenesVenta = (await _apiClient.OrdenesVenta.GetAllAsync()).ToList();

                if (ordenesVenta == null || !ordenesVenta.Any())
                {
                    MessageBox.Show("No se encontraron órdenes de venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cboIdOrdenVenta.DataSource = null;
                cboIdOrdenVenta.DataSource = ordenesVenta;
                cboIdOrdenVenta.DisplayMember = "IdSalesOrder"; 
                cboIdOrdenVenta.ValueMember = "IdSalesOrder";
                cboIdOrdenVenta.SelectedIndex = -1;

                cboNumeroOrden.DataSource = null;
                cboNumeroOrden.DataSource = ordenesVenta;
                cboNumeroOrden.DisplayMember = "OrderNumber"; 
                cboNumeroOrden.ValueMember = "OrderNumber";
                cboNumeroOrden.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las órdenes de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProductosAsync()
        {
            try
            {
                productos = (await _apiClient.Productos.GetAllAsync()).ToList();

                cboProducto.DataSource = null;
                cboProducto.DataSource = productos;
                cboProducto.DisplayMember = "ProductName";
                cboProducto.ValueMember = "IdProduct";
                cboProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DetalleOrdenVentaForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadOrdenesVentaAsync();
                await LoadProductosAsync();
                await LoadDetallesOrdenVentaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDetallesOrdenVentaAsync()
        {
            try
            {
                detallesOrdenVenta = (await _apiClient.DetallesOrdenVenta.GetAllAsync()).ToList();
                dgvDetalleOrdenVenta.DataSource = detallesOrdenVenta;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboIdOrdenVenta.SelectedIndex == -1 || cboProducto.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var idOrdenSeleccionada = Convert.ToInt32(cboIdOrdenVenta.SelectedValue);
                var numeroOrdenSeleccionada = cboNumeroOrden.Text;

                var ordenSeleccionada = ordenesVenta.FirstOrDefault(o => o.IdSalesOrder == idOrdenSeleccionada);

                if (ordenSeleccionada == null || ordenSeleccionada.OrderNumber != numeroOrdenSeleccionada)
                {
                    MessageBox.Show("El Id de la Orden de Venta y el Número de Orden no coinciden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var detalleSeleccionado = (DetalleOrdenVentaDto)dgvDetalleOrdenVenta.SelectedRows[0].DataBoundItem;

                detalleSeleccionado.IdSalesOrder = Convert.ToInt32(cboIdOrdenVenta.SelectedValue);
                detalleSeleccionado.IdProduct = Convert.ToInt32(cboProducto.SelectedValue);
                detalleSeleccionado.Quantity = int.Parse(txtCantidad.Text);
                detalleSeleccionado.UnitPrice = decimal.Parse(txtPrecioUnitario.Text);
                detalleSeleccionado.OrderNumber = cboNumeroOrden.Text;

                await _apiClient.DetallesOrdenVenta.UpdateAsync(detalleSeleccionado.IdSalesOrderDetail, detalleSeleccionado);

                MessageBox.Show("Detalle de orden de venta actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDetallesOrdenVentaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetalleOrdenVenta.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un detalle para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var detalleSeleccionado = (DetalleOrdenVentaDto)dgvDetalleOrdenVenta.SelectedRows[0].DataBoundItem;

                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este detalle?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    await _apiClient.DetallesOrdenVenta.DeleteAsync(detalleSeleccionado.IdSalesOrderDetail);
                    MessageBox.Show("Detalle eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDetallesOrdenVentaAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetalleOrdenVenta_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetalleOrdenVenta.SelectedRows.Count > 0)
            {
                var detalleSeleccionado = (DetalleOrdenVentaDto)dgvDetalleOrdenVenta.SelectedRows[0].DataBoundItem;

                cboIdOrdenVenta.SelectedValue = detalleSeleccionado.IdSalesOrder;
                cboProducto.SelectedValue = detalleSeleccionado.IdProduct;
                txtCantidad.Text = detalleSeleccionado.Quantity.ToString();
                txtPrecioUnitario.Text = detalleSeleccionado.UnitPrice.ToString("F2");
                cboNumeroOrden.Text = detalleSeleccionado.OrderNumber;
            }
        }
    }
}
