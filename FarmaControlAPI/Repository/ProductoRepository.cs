using FarmaControlAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedModels;
using System.Data.SqlClient;

namespace FarmaControlAPI.Repository
{
    public class ProductoRepository : IProductoRepository<Producto>
    {
        private readonly DatabaseContext _dbContext;

        public ProductoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Producto entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("INSERT INTO [Products].[Products] " +
                                         "(ProductName, Id_Supplier, Id_Category, UnitPrice, ReorderLevel, LoteNumber, " +
                                         "ManufactureDate,  ModifiedDate) " +
                                         "VALUES (@ProductName, @Id_Supplier, @Id_Category, @UnitPrice, @ReorderLevel, " +
                                         "@LoteNumber, @ManufactureDate,  GETDATE()); " +
                                         "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@ProductName", entity.ProductName);
            command.Parameters.AddWithValue("@Id_Supplier", entity.IdSupplier);
            command.Parameters.AddWithValue("@Id_Category", entity.IdCategory);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("@ReorderLevel", entity.ReorderLevel ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LoteNumber", entity.LoteNumber);
            command.Parameters.AddWithValue("@ManufactureDate", entity.ManufactureDate);

            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM [Products].[Products] WHERE Id_Product = @Id_Product", connection);
            command.Parameters.AddWithValue("@Id_Product", id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Products].[Products]", connection);
            var productos = new List<Producto>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                productos.Add(new Producto
                {
                    IdProduct = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    IdSupplier = reader.GetInt32(2),
                    IdCategory = reader.GetInt32(3),
                    UnitPrice = reader.GetDecimal(4),
                    ReorderLevel = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                    LoteNumber = reader.GetString(6),
                    ManufactureDate = reader.GetDateTime(7),
                    ModifiedDate = reader.GetDateTime(8)
                });
            }
            return productos;
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Products].[Products] WHERE Id_Product = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Producto
                {
                    IdProduct = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    IdSupplier = reader.GetInt32(2),
                    IdCategory = reader.GetInt32(3),
                    UnitPrice = reader.GetDecimal(4),
                    ReorderLevel = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                    LoteNumber = reader.GetString(6),
                    ManufactureDate = reader.GetDateTime(7),
                    ModifiedDate = reader.GetDateTime(8)
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Producto entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("UPDATE [Products].[Products] SET " +
                                         "ProductName = @ProductName, Id_Supplier = @Id_Supplier, Id_Category = @Id_Category, " +
                                         "UnitPrice = @UnitPrice, ReorderLevel = @ReorderLevel, LoteNumber = @LoteNumber, " +
                                         "ManufactureDate = @ManufactureDate, ModifiedDate = GETDATE() " +
                                         "WHERE Id_Product = @Id_Product", connection);

            command.Parameters.AddWithValue("@Id_Product", entity.IdProduct);
            command.Parameters.AddWithValue("@ProductName", entity.ProductName);
            command.Parameters.AddWithValue("@Id_Supplier", entity.IdSupplier);
            command.Parameters.AddWithValue("@Id_Category", entity.IdCategory);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("@ReorderLevel", entity.ReorderLevel ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LoteNumber", entity.LoteNumber);
            command.Parameters.AddWithValue("@ManufactureDate", entity.ManufactureDate);

            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}
