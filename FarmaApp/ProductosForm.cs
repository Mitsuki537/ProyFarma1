using SharedModels.Dtos.Producto;
using SharedModels;
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
using SharedModels.Dtos.CategoriaProducto;

namespace FarmaApp
{
    public partial class ProductosForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        private List<ProductoDto> productos;

        public ProductosForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            productos = new List<ProductoDto>();
        }
        private void ClearInputs()
        {
            txtProducto.Clear();
            txtNumeroLote.Clear();
            txtPrecioUnitario.Clear();
            txtReabastecimiento.Clear();
            cboProveedor.SelectedIndex = -1;
            cboCategoria.SelectedIndex = -1;
            dtpFechaModificacion.Value = DateTime.Now;
        }
        private async void ProductosForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadProductosAsync();
                await LoadComboBoxesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProducto.Text) || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var proveedorSeleccionado = cboProveedor.SelectedItem as ProveedorDto;
                if (proveedorSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un proveedor válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var categoriaSeleccionada = cboCategoria.SelectedItem as CategoriaProductoDto;
                if (categoriaSeleccionada == null)
                {
                    MessageBox.Show("Debe seleccionar una categoría válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevoProducto = new ProductoCreateDto
                {
                    ProductName = txtProducto.Text.Trim(),
                    UnitPrice = Convert.ToDecimal(txtPrecioUnitario.Text.Trim()),
                    ReorderLevel = string.IsNullOrWhiteSpace(txtReabastecimiento.Text) ? 0 : Convert.ToInt32(txtReabastecimiento.Text.Trim()),
                    LoteNumber = txtNumeroLote.Text.Trim(),
                    ManufactureDate = dtpFechaModificacion.Value,
                    IdSupplier = proveedorSeleccionado.IdSupplier,  
                    IdCategory = categoriaSeleccionada.IdCategory  
                };

                var newProductoId = await _apiClient.Productos.CreateAsync(nuevoProducto);

                var productoDto = new ProductoDto
                {
                    IdProduct = newProductoId,
                    ProductName = nuevoProducto.ProductName,
                    UnitPrice = nuevoProducto.UnitPrice,
                    ReorderLevel = nuevoProducto.ReorderLevel,
                    LoteNumber = nuevoProducto.LoteNumber,
                    ManufactureDate = nuevoProducto.ManufactureDate,
                    ModifiedDate = DateTime.Now
                };

                productos.Add(productoDto);

                dgvProductos.DataSource = null; 
                dgvProductos.DataSource = productos;  
                await LoadProductosAsync();
                MessageBox.Show("Producto creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvProductos.ClearSelection();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                try
                {
                    var productoSeleccionado = dgvProductos.SelectedRows[0].DataBoundItem as ProductoDto;
                    if (productoSeleccionado == null)
                    {
                        MessageBox.Show("Seleccione un producto válido para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var productoActualizado = new ProductoUpdateDto
                    {
                        IdProduct = productoSeleccionado.IdProduct,
                        ProductName = txtProducto.Text.Trim(),
                        UnitPrice = Convert.ToDecimal(txtPrecioUnitario.Text.Trim()),
                        ReorderLevel = string.IsNullOrWhiteSpace(txtReabastecimiento.Text) ? 0 : Convert.ToInt32(txtReabastecimiento.Text.Trim()),
                        LoteNumber = txtNumeroLote.Text.Trim(),
                        ManufactureDate = dtpFechaModificacion.Value,
                        IdSupplier = (cboProveedor.SelectedItem as ProveedorDto).IdSupplier,
                        IdCategory = (cboCategoria.SelectedItem as CategoriaProductoDto).IdCategory
                    };

                    var actualizado = await _apiClient.Productos.UpdateAsync(productoSeleccionado.IdProduct, productoActualizado);
                    if (actualizado)
                    {
                        MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadProductosAsync();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el producto. Revise los datos e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task LoadProductosAsync()
        {
            try
            {
                var productos = await _apiClient.Productos.GetAllAsync();
                dgvProductos.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error");
            }
        }
        private async Task LoadComboBoxesAsync()
        {
            try
            {
                var proveedores = await _apiClient.Proveedores.GetAllAsync();
                cboProveedor.DataSource = proveedores;
                cboProveedor.DisplayMember = "SupplierName";
                cboProveedor.ValueMember = "IdSupplier";

                var categorias = await _apiClient.CategoriasProducto.GetAllAsync();
                cboCategoria.DataSource = categorias;
                cboCategoria.DisplayMember = "CategoryName";
                cboCategoria.ValueMember = "IdCategory";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los combos: {ex.Message}", "Error");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                try
                {
                    var productoSeleccionado = dgvProductos.SelectedRows[0].DataBoundItem as ProductoDto;

                    var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar el producto {productoSeleccionado.ProductName}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        await _apiClient.Productos.DeleteAsync(productoSeleccionado.IdProduct);
                        await LoadProductosAsync();
                        MessageBox.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var productoSeleccionado = (ProductoDto)dgvProductos.SelectedRows[0].DataBoundItem;
                txtProducto.Text = productoSeleccionado.ProductName;
                txtNumeroLote.Text = productoSeleccionado.LoteNumber;
                txtPrecioUnitario.Text = productoSeleccionado.UnitPrice.ToString();
                txtReabastecimiento.Text = productoSeleccionado.ReorderLevel.ToString();
                cboProveedor.SelectedValue = productoSeleccionado.IdSupplier;
                cboCategoria.SelectedValue = productoSeleccionado.IdCategory;
                dtpFechaModificacion.Value = productoSeleccionado.ModifiedDate;
            }
        }
    }
}
