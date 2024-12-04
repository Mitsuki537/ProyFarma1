using SharedModels.Dtos.Empleado;
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
    public partial class EmpleadosForm : Form
    {
        private readonly ApiClientFarma _apiClient;
        private List<EmpleadoDto> empleados;
        public EmpleadosForm(ApiClientFarma apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            empleados = new List<EmpleadoDto>();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvEmpleados.ClearSelection();
        }

        private async void EmpleadosForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadReportadoAAsync();
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
                this.empleados = empleados?.ToList() ?? new List<EmpleadoDto>();
                dgvEmpleados.DataSource = this.empleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadReportadoAAsync()
        {
            try
            {
                var empleados = await _apiClient.Empleados.GetAllAsync();
                cboReportadoA.DataSource = empleados.ToList();
                cboReportadoA.DisplayMember = "FirstName";
                cboReportadoA.ValueMember = "IdEmployee";
                cboReportadoA.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de supervisores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoEmpleado = new EmpleadoCreateDto
                {
                    FirstName = txtNombre.Text.Trim(),
                    LastName = txtApellido.Text.Trim(),
                    Title = txtTitulo.Text.Trim(),
                    HireDate = dtpFechaContratacion.Value,
                    BirthDate = dtpFechaNacimiento.Value,
                    Email = txtCorreo.Text.Trim(),
                    Phone = mtbTelefono.Text.Trim(),
                    Department = txtDepartamento.Text.Trim(),
                    ReportsTo = cboReportadoA.SelectedValue as int?
                };

                var newId = await _apiClient.Empleados.CreateAsync(nuevoEmpleado);

                var nuevoEmpleadoDto = new EmpleadoDto
                {
                    IdEmployee = newId,
                    FirstName = nuevoEmpleado.FirstName,
                    LastName = nuevoEmpleado.LastName,
                    Title = nuevoEmpleado.Title,
                    HireDate = nuevoEmpleado.HireDate,
                    BirthDate = nuevoEmpleado.BirthDate,
                    Email = nuevoEmpleado.Email,
                    Phone = nuevoEmpleado.Phone,
                    Department = nuevoEmpleado.Department,
                    ReportsTo = nuevoEmpleado.ReportsTo,
                    ModifiedDate = DateTime.Now
                };

                empleados.Add(nuevoEmpleadoDto);
                dgvEmpleados.DataSource = null; 
                dgvEmpleados.DataSource = empleados;

                MessageBox.Show("Empleado creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTitulo.Clear();
            dtpFechaContratacion.Value = DateTime.Now;
            dtpFechaNacimiento.Value = DateTime.Now;
            txtCorreo.Clear();
            mtbTelefono.Clear();
            cboReportadoA.SelectedIndex = -1;
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                try
                {
                    var empleadoSeleccionado = dgvEmpleados.SelectedRows[0].DataBoundItem as EmpleadoDto;
                    if (empleadoSeleccionado == null)
                    {
                        MessageBox.Show("Seleccione un empleado válido para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var empleadoActualizado = new EmpleadoUpdateDto
                    {
                        IdEmployee = empleadoSeleccionado.IdEmployee,
                        FirstName = txtNombre.Text.Trim(),
                        LastName = txtApellido.Text.Trim(),
                        Title = txtTitulo.Text.Trim(),
                        HireDate = dtpFechaContratacion.Value,
                        BirthDate = dtpFechaNacimiento.Value,
                        Email = txtCorreo.Text.Trim(),
                        Phone = mtbTelefono.Text.Trim(),
                        Department = txtDepartamento.Text.Trim(),
                        ReportsTo = cboReportadoA.SelectedValue as int?, 
                        ModifiedDate = DateTime.Now
                    };

                    if (string.IsNullOrWhiteSpace(empleadoActualizado.FirstName) || string.IsNullOrWhiteSpace(empleadoActualizado.LastName))
                    {
                        MessageBox.Show("El nombre y el apellido son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var actualizado = await _apiClient.Empleados.UpdateAsync(empleadoActualizado.IdEmployee, empleadoActualizado);
                    if (actualizado)
                    {
                        MessageBox.Show("Empleado actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadEmpleadosAsync(); 
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el empleado. Revise los datos e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                try
                {
                    var empleadoSeleccionado = (EmpleadoDto)dgvEmpleados.SelectedRows[0].DataBoundItem;

                    var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar a {empleadoSeleccionado.FirstName} {empleadoSeleccionado.LastName}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        await _apiClient.Empleados.DeleteAsync(empleadoSeleccionado.IdEmployee);
                        await LoadEmpleadosAsync();
                        MessageBox.Show("Empleado eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                var empleadoSeleccionado = (EmpleadoDto)dgvEmpleados.SelectedRows[0].DataBoundItem;
                txtNombre.Text = empleadoSeleccionado.FirstName;
                txtApellido.Text = empleadoSeleccionado.LastName;
                txtTitulo.Text = empleadoSeleccionado.Title;
                dtpFechaContratacion.Value = empleadoSeleccionado.HireDate;
                dtpFechaNacimiento.Value = empleadoSeleccionado.BirthDate ?? DateTime.Now;
                txtCorreo.Text = empleadoSeleccionado.Email;
                mtbTelefono.Text = empleadoSeleccionado.Phone;
                txtDepartamento.Text = empleadoSeleccionado.Department;

                cboReportadoA.SelectedValue = empleadoSeleccionado.ReportsTo ?? -1;
                if (empleadoSeleccionado.ReportsTo == null) cboReportadoA.SelectedIndex = -1;
            }
        }
    }
}
