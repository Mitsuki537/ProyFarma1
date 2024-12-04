using SharedModels.Dtos.CategoriaProducto;
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
    public partial class CategoriasForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        private List<CategoriaProductoDto> categorias;
        public CategoriasForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            categorias = new List<CategoriaProductoDto>();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearInputs(); 
            dgvCategorias.ClearSelection();
        }

        private async void CategoriasForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadCategoriasAsync();
                await LoadCategoriasAsociadasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCategoriasAsociadasAsync()
        {
            try
            {
                var categoriasAsociadas = await _apiClient.CategoriasProducto.GetAllAsync();
                cboCategoriaAsociada.DataSource = categoriasAsociadas.ToList();
                cboCategoriaAsociada.DisplayMember = "CategoryName";
                cboCategoriaAsociada.ValueMember = "IdCategory";
                cboCategoriaAsociada.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías asociadas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCategoriasAsync()
        {
            try
            {
                categorias = (List<CategoriaProductoDto>)await _apiClient.CategoriasProducto.GetAllAsync();
                dgvCategorias.DataSource = null; 
                dgvCategorias.DataSource = categorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCategoria.Text))
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevaCategoria = new CategoriaProductoCreateDto
                {
                    CategoryName = txtCategoria.Text.Trim(),
                    IdParentCategory = (int?)cboCategoriaAsociada.SelectedValue,
                };

                await _apiClient.CategoriasProducto.CreateAsync(nuevaCategoria);
                await LoadCategoriasAsync(); 
                MessageBox.Show("Categoría creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtCategoria.Clear();
            cboCategoriaAsociada.SelectedIndex = -1;
            dtpFechaModificacion.Value = DateTime.Now;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                try
                {
                    var categoriaSeleccionada = (CategoriaProductoDto)dgvCategorias.SelectedRows[0].DataBoundItem;

                    var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar la categoría {categoriaSeleccionada.CategoryName}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        await _apiClient.CategoriasProducto.DeleteAsync(categoriaSeleccionada.IdCategory);
                        await LoadCategoriasAsync(); 
                        MessageBox.Show("Categoría eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                try
                {
                    var categoriaSeleccionada = dgvCategorias.SelectedRows[0].DataBoundItem as CategoriaProductoDto;
                    if (categoriaSeleccionada == null)
                    {
                        MessageBox.Show("Seleccione una categoría válida para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var categoriaActualizada = new CategoriaProductoUpdateDto
                    {
                        IdCategory = categoriaSeleccionada.IdCategory,
                        CategoryName = txtCategoria.Text.Trim(),
                        IdParentCategory = (int?)cboCategoriaAsociada.SelectedValue
                    };

                    await _apiClient.CategoriasProducto.UpdateAsync(categoriaActualizada.IdCategory, categoriaActualizada);
                    await LoadCategoriasAsync();
                    MessageBox.Show("Categoría actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                var categoriaSeleccionada = (CategoriaProductoDto)dgvCategorias.SelectedRows[0].DataBoundItem;
                txtCategoria.Text = categoriaSeleccionada.CategoryName;
                cboCategoriaAsociada.SelectedValue = categoriaSeleccionada.IdParentCategory ?? -1;
            }
        }
    }
}
