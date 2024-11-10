using FarmaControlAPI.Data;
using Microsoft.EntityFrameworkCore.Storage;
using SharedModels;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace FarmaControlAPI.Repository
{
    public class EmlpeadoRepository : IEmpleadoRepository<Empleado>
    {
        private readonly DatabaseContext _dbContext;

        public EmlpeadoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Empleado entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();
            var command = new SqlCommand("INSERT INTO [Employees].[Employees] " +
                                 "(FirstName, LastName, Title, HireDate, BirthDate, Email, Phone, Department, ReportsTo, ModifiedDate) " +
                                 "VALUES (@FirstName, @LastName, @Title, @HireDate, @BirthDate, @Email, @Phone, @Department, @ReportsTo, @ModifiedDate); " +
                                 "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Title", entity.Title ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@HireDate", entity.HireDate);
            command.Parameters.AddWithValue("@BirthDate", entity.BirthDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Phone", entity.Phone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Department", entity.Department ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ReportsTo", entity.ReportsTo ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var updateReportsToCommand = new SqlCommand(
                "UPDATE [Employees].[Employees] SET ReportsTo = NULL WHERE ReportsTo = @Id_Employee",
                connection
            );
            updateReportsToCommand.Parameters.AddWithValue("@Id_Employee", id);
            await updateReportsToCommand.ExecuteNonQueryAsync();

            var deleteEmployeeCommand = new SqlCommand(
                "DELETE FROM [Employees].[Employees] WHERE Id_Employee = @Id_Employee",
                connection
            );
            deleteEmployeeCommand.Parameters.AddWithValue("@Id_Employee", id);

            return await deleteEmployeeCommand.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Employees].[Employees]", connection);
            var empleados = new List<Empleado>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                empleados.Add(new Empleado
                {
                    IdEmployee = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Title = reader.IsDBNull(3) ? null : reader.GetString(3),
                    HireDate = reader.GetDateTime(4),
                    BirthDate = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                    Email = reader.IsDBNull(6) ? null : reader.GetString(6),
                    Phone = reader.IsDBNull(7) ? null : reader.GetString(7),
                    Department = reader.IsDBNull(8) ? null : reader.GetString(8),
                    ReportsTo = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9),
                    ModifiedDate = reader.GetDateTime(10)
                });
            }
            return empleados;
        }

        public async Task<Empleado> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Employees].[Employees] WHERE Id_Employee = @Id_Employee", connection);
            command.Parameters.AddWithValue("@Id_Employee", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Empleado
                {
                    IdEmployee = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Title = reader.IsDBNull(3) ? null : reader.GetString(3),
                    HireDate = reader.GetDateTime(4),
                    BirthDate = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                    Email = reader.IsDBNull(6) ? null : reader.GetString(6),
                    Phone = reader.IsDBNull(7) ? null : reader.GetString(7),
                    Department = reader.IsDBNull(8) ? null : reader.GetString(8),
                    ReportsTo = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9),
                    ModifiedDate = reader.GetDateTime(10)
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Empleado entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("UPDATE [Employees].[Employees] SET " +
                                         "FirstName = @FirstName, LastName = @LastName, Title = @Title, HireDate = @HireDate, " +
                                         "BirthDate = @BirthDate, Email = @Email, Phone = @Phone, Department = @Department, " +
                                         "ReportsTo = @ReportsTo, ModifiedDate = @ModifiedDate " +
                                         "WHERE Id_Employee = @Id_Employee", connection);

            command.Parameters.AddWithValue("@Id_Employee", entity.IdEmployee);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Title", entity.Title ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@HireDate", entity.HireDate);
            command.Parameters.AddWithValue("@BirthDate", entity.BirthDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Phone", entity.Phone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Department", entity.Department ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ReportsTo", entity.ReportsTo ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}
