using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SharedModels;
using SharedModels.Dtos.DetalleOrdenCompra;
using SharedModels.Dtos.OrdenCompra;
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
    public partial class DetalleCompraForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        private List<DetalleOrdenCompraDto> detallesOrdenCompra;
        private List<OrdenCompraDto> ordenesCompra;
        private List<ProductoDto> productos;
        public DetalleCompraForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            detallesOrdenCompra = new List<DetalleOrdenCompraDto>();
            ordenesCompra = new List<OrdenCompraDto>();
            productos = new List<ProductoDto>();
        }
        private void ClearInputs()
        {
            txtPrecioUnitario.Clear();
            txtCantidad.Clear();
            dtpFechaExpiracion.Value = DateTime.Now;
            dtpLimiteDevolucion.Value = DateTime.Now;
            cboProducto.SelectedIndex = -1;
            cboNumeroOrden.SelectedIndex = -1;
            cboIdOrdenCompra.SelectedIndex = -1;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvDetalleOrdenCompra.ClearSelection();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboIdOrdenCompra.SelectedIndex == -1 || cboProducto.SelectedIndex == -1 ||
          string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var idOrdenSeleccionada = Convert.ToInt32(cboIdOrdenCompra.SelectedValue);
                var numeroOrdenSeleccionada = cboNumeroOrden.Text;

                var ordenSeleccionada = ordenesCompra.FirstOrDefault(o => o.IdPurchaseOrder == idOrdenSeleccionada);

                if (ordenSeleccionada == null || ordenSeleccionada.OrderNumber != numeroOrdenSeleccionada)
                {
                    MessageBox.Show("El Id de la Orden de Compra y el Número de Orden no coinciden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                    var nuevoDetalle = new DetalleOrdenCompraCreateDto
                {
                    IdPurchaseOrder = Convert.ToInt32(cboIdOrdenCompra.SelectedValue),
                    IdProduct = Convert.ToInt32(cboProducto.SelectedValue),
                    Quantity = int.Parse(txtCantidad.Text),
                    UnitPrice = decimal.Parse(txtPrecioUnitario.Text),
                    ExpirationDate = dtpFechaExpiracion.Value,
                    ReturnDeadline = dtpLimiteDevolucion.Value,
                    OrderNumber = cboNumeroOrden.Text
                };

                var newDetalleId = await _apiClient.DetallesOrdenCompra.CreateAsync(nuevoDetalle);

                var detalleDto = new DetalleOrdenCompraDto
                {
                    IdPurchaseOrderDetail = newDetalleId,
                    IdPurchaseOrder = nuevoDetalle.IdPurchaseOrder,
                    IdProduct = nuevoDetalle.IdProduct,
                    Quantity = nuevoDetalle.Quantity,
                    UnitPrice = nuevoDetalle.UnitPrice,
                    ExpirationDate = nuevoDetalle.ExpirationDate,
                    ReturnDeadline = nuevoDetalle.ReturnDeadline,
                    OrderNumber = nuevoDetalle.OrderNumber
                };
                detallesOrdenCompra.Add(detalleDto);
                dgvDetalleOrdenCompra.DataSource = null;
                dgvDetalleOrdenCompra.DataSource = detallesOrdenCompra;
                await LoadDetallesOrdenCompraAsync();
                MessageBox.Show("Detalle de orden de compra guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task LoadOrdenesCompraAsync()
        {
            try
            {
                ordenesCompra = (await _apiClient.OrdenesCompra.GetAllAsync()).ToList();

                cboIdOrdenCompra.DataSource = null; 
                cboIdOrdenCompra.DataSource = ordenesCompra;
                cboIdOrdenCompra.DisplayMember = "IdPurchaseOrder"; 
                cboIdOrdenCompra.ValueMember = "IdPurchaseOrder";  
                cboIdOrdenCompra.SelectedIndex = -1;

                cboNumeroOrden.DataSource = null;
                cboNumeroOrden.DataSource = ordenesCompra;
                cboNumeroOrden.DisplayMember = "OrderNumber";
                cboNumeroOrden.ValueMember = "OrderNumber"; 
                cboNumeroOrden.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las órdenes de compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private async void DetalleCompraForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadOrdenesCompraAsync();
                await LoadProductosAsync();
                await LoadDetallesOrdenCompraAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDetallesOrdenCompraAsync()
        {
            try
            {
                detallesOrdenCompra = (await _apiClient.DetallesOrdenCompra.GetAllAsync()).ToList();
                dgvDetalleOrdenCompra.DataSource = detallesOrdenCompra;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetalleOrdenCompra_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetalleOrdenCompra.SelectedRows.Count > 0)
            {
                var detalleSeleccionado = (DetalleOrdenCompraDto)dgvDetalleOrdenCompra.SelectedRows[0].DataBoundItem;

                cboIdOrdenCompra.SelectedValue = detalleSeleccionado.IdPurchaseOrder;
                cboProducto.SelectedValue = detalleSeleccionado.IdProduct;
                txtCantidad.Text = detalleSeleccionado.Quantity.ToString();
                txtPrecioUnitario.Text = detalleSeleccionado.UnitPrice.ToString("F2");
                dtpFechaExpiracion.Value = detalleSeleccionado.ExpirationDate.HasValue && detalleSeleccionado.ExpirationDate >= dtpFechaExpiracion.MinDate
            ? detalleSeleccionado.ExpirationDate.Value
            : DateTime.Now;
                dtpLimiteDevolucion.Value = detalleSeleccionado.ReturnDeadline.HasValue && detalleSeleccionado.ReturnDeadline >= dtpLimiteDevolucion.MinDate
             ? detalleSeleccionado.ReturnDeadline.Value
             : DateTime.Now;
                cboNumeroOrden.Text = detalleSeleccionado.OrderNumber;
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboIdOrdenCompra.SelectedIndex == -1 || cboProducto.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var idOrdenSeleccionada = Convert.ToInt32(cboIdOrdenCompra.SelectedValue);
                var numeroOrdenSeleccionada = cboNumeroOrden.Text;

                var ordenSeleccionada = ordenesCompra.FirstOrDefault(o => o.IdPurchaseOrder == idOrdenSeleccionada);

                if (ordenSeleccionada == null || ordenSeleccionada.OrderNumber != numeroOrdenSeleccionada)
                {
                    MessageBox.Show("El Id de la Orden de Compra y el Número de Orden no coinciden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var detalleSeleccionado = (DetalleOrdenCompraDto)dgvDetalleOrdenCompra.SelectedRows[0].DataBoundItem;

                detalleSeleccionado.IdPurchaseOrder = Convert.ToInt32(cboIdOrdenCompra.SelectedValue);
                detalleSeleccionado.IdProduct = Convert.ToInt32(cboProducto.SelectedValue);
                detalleSeleccionado.Quantity = int.Parse(txtCantidad.Text);
                detalleSeleccionado.UnitPrice = decimal.Parse(txtPrecioUnitario.Text);
                detalleSeleccionado.ExpirationDate = dtpFechaExpiracion.Checked ? dtpFechaExpiracion.Value : (DateTime?)null;
                detalleSeleccionado.ReturnDeadline = dtpLimiteDevolucion.Checked ? dtpLimiteDevolucion.Value : (DateTime?)null;
                detalleSeleccionado.OrderNumber = cboNumeroOrden.Text;

                await _apiClient.DetallesOrdenCompra.UpdateAsync(detalleSeleccionado.IdPurchaseOrderDetail, detalleSeleccionado);

                MessageBox.Show("Detalle de orden de compra actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDetallesOrdenCompraAsync();
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
                if (dgvDetalleOrdenCompra.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un detalle para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var detalleSeleccionado = (DetalleOrdenCompraDto)dgvDetalleOrdenCompra.SelectedRows[0].DataBoundItem;

                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este detalle?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    await _apiClient.DetallesOrdenCompra.DeleteAsync(detalleSeleccionado.IdPurchaseOrderDetail);
                    MessageBox.Show("Detalle eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDetallesOrdenCompraAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboIdOrdenCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (cboIdOrdenCompra.SelectedValue is int idOrdenSeleccionada)
            {
                var numeroOrdenSeleccionada = cboNumeroOrden.Text; // Recupera el texto seleccionado
                var ordenSeleccionada = ordenesCompra.FirstOrDefault(o => o.IdPurchaseOrder == idOrdenSeleccionada);

                if (ordenSeleccionada != null && ordenSeleccionada.OrderNumber == numeroOrdenSeleccionada)
                {
                    MessageBox.Show("El Id y el número de orden coinciden.");
                }
                else
                {
                    MessageBox.Show("El Id de la Orden de Compra y el Número de Orden no coinciden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Manejar caso donde no se pueda obtener un Id válido
                MessageBox.Show("Por favor, seleccione un Id válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void cboNumeroOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  if (cboIdOrdenCompra.SelectedValue is int idOrdenSeleccionada)
            {
                var numeroOrdenSeleccionada = cboNumeroOrden.Text;
                var ordenSeleccionada = ordenesCompra.FirstOrDefault(o => o.IdPurchaseOrder == idOrdenSeleccionada);

                if (ordenSeleccionada != null && ordenSeleccionada.OrderNumber == numeroOrdenSeleccionada)
                {
                    MessageBox.Show("El Id y el número de orden coinciden.");
                }
                else
                {
                    MessageBox.Show("El Id de la Orden de Compra y el Número de Orden no coinciden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un Id válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }
    }
}
