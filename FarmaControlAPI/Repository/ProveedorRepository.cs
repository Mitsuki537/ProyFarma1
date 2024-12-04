using FarmaControlAPI.Data;
using SharedModels;
using System.Data.SqlClient;

namespace FarmaControlAPI.Repository
{
    public class ProveedorRepository : IProveedorRepository<Proveedor>
    {
        private readonly DatabaseContext _dbContext;

        public ProveedorRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Proveedor entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();
            var command = new SqlCommand("INSERT INTO [Suppliers].[Suppliers] " +
                                         "(SupplierName, ContactName, ContactTitle, Phone, Email, Address, City, Country, PostalCode, ModifiedDate) " +
                                         "VALUES (@SupplierName, @ContactName, @ContactTitle, @Phone, @Email, @Address, @City, @Country, @PostalCode, @ModifiedDate); " +
                                         "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@SupplierName", entity.SupplierName);
            command.Parameters.AddWithValue("@ContactName", entity.ContactName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ContactTitle", entity.ContactTitle ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Phone", entity.Phone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Address", entity.Address ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@City", entity.City ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Country", entity.Country ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PostalCode", entity.PostalCode ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM [Suppliers].[Suppliers] WHERE Id_Supplier = @Id_Supplier", connection);
            command.Parameters.AddWithValue("@Id_Supplier", id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Suppliers].[Suppliers]", connection);
            var proveedores = new List<Proveedor>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                proveedores.Add(new Proveedor
                {
                    IdSupplier = reader.GetInt32(0),
                    SupplierName = reader.GetString(1),
                    ContactName = reader.GetString(2),
                    ContactTitle = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                    Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Address = reader.IsDBNull(6) ? null : reader.GetString(6),
                    City = reader.IsDBNull(7) ? null : reader.GetString(7),
                    Country = reader.IsDBNull(8) ? null : reader.GetString(8),
                    PostalCode = reader.IsDBNull(9) ? null : reader.GetString(9),
                    ModifiedDate = reader.GetDateTime(10)
                });
            }
            return proveedores;
        }

        public async Task<Proveedor> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Suppliers].[Suppliers] WHERE Id_Supplier = @Id_Supplier", connection);
            command.Parameters.AddWithValue("@Id_Supplier", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Proveedor
                {
                    IdSupplier = reader.GetInt32(0),
                    SupplierName = reader.GetString(1),
                    ContactName = reader.GetString(2),
                    ContactTitle = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                    Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Address = reader.IsDBNull(6) ? null : reader.GetString(6),
                    City = reader.IsDBNull(7) ? null : reader.GetString(7),
                    Country = reader.IsDBNull(8) ? null : reader.GetString(8),
                    PostalCode = reader.IsDBNull(9) ? null : reader.GetString(9),
                    ModifiedDate = reader.GetDateTime(10)
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Proveedor entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            try
            {
                var command = new SqlCommand("UPDATE [Suppliers].[Suppliers] SET " +
                                             "SupplierName = @SupplierName, ContactName = @ContactName, ContactTitle = @ContactTitle, " +
                                             "Phone = @Phone, Email = @Email, Address = @Address, City = @City, Country = @Country, " +
                                             "PostalCode = @PostalCode, ModifiedDate = @ModifiedDate " +
                                             "WHERE Id_Supplier = @Id_Supplier", connection);

                command.Parameters.AddWithValue("@Id_Supplier", entity.IdSupplier);
                command.Parameters.AddWithValue("@SupplierName", entity.SupplierName);
                command.Parameters.AddWithValue("@ContactName", entity.ContactName ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ContactTitle", entity.ContactTitle ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Phone", entity.Phone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Address", entity.Address ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@City", entity.City ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Country", entity.Country ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@PostalCode", entity.PostalCode ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                return await command.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                // Aquí puedes loguear el error
                throw new Exception($"Error al actualizar el proveedor: {ex.Message}", ex);
            }
        }
    }
}
