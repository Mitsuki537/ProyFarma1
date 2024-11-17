using FarmaControlAPI.Data;
using SharedModels;
using System.Data.SqlClient;

namespace FarmaControlAPI.Repository
{
    public class DetalleOrdenVentaRepository : IDetalleOrdenVentaRepository<DetalleOrdenVenta>
    {
        private readonly DatabaseContext _dbContext;

        public DetalleOrdenVentaRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(DetalleOrdenVenta entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("INSERT INTO [Sales].[SalesOrderDetails] " +
                                         "(Id_SalesOrder, Id_Product, Quantity, UnitPrice, Discount, ModifiedDate) " +
                                         "VALUES (@IdSalesOrder, @IdProduct, @Quantity, @UnitPrice, @Discount, GETDATE()); " +
                                         "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@IdSalesOrder", entity.IdSalesOrder);
            command.Parameters.AddWithValue("@IdProduct", entity.IdProduct);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("@Discount", entity.Discount ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM [Sales].[SalesOrderDetails] WHERE Id_SalesOrderDetail = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<DetalleOrdenVenta>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Sales].[SalesOrderDetails]", connection);
            var salesOrderDetails = new List<DetalleOrdenVenta>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                salesOrderDetails.Add(new DetalleOrdenVenta
                {
                    IdSalesOrderDetail = reader.GetInt32(0),
                    IdSalesOrder = reader.GetInt32(1),
                    IdProduct = reader.GetInt32(2),
                    Quantity = reader.GetInt32(3),
                    UnitPrice = reader.GetDecimal(4),
                    Discount = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5),
                    LineTotal = reader.GetDecimal(6),
                    ModifiedDate = reader.GetDateTime(7)
                });
            }
            return salesOrderDetails;
        }

        public async Task<DetalleOrdenVenta> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Sales].[SalesOrderDetails] WHERE Id_SalesOrderDetail = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new DetalleOrdenVenta
                {
                    IdSalesOrderDetail = reader.GetInt32(0),
                    IdSalesOrder = reader.GetInt32(1),
                    IdProduct = reader.GetInt32(2),
                    Quantity = reader.GetInt32(3),
                    UnitPrice = reader.GetDecimal(4),
                    Discount = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5),
                    LineTotal = reader.GetDecimal(6),
                    ModifiedDate = reader.GetDateTime(7)
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(DetalleOrdenVenta entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("UPDATE [Sales].[SalesOrderDetails] SET " +
                                         "Id_SalesOrder = @IdSalesOrder, Id_Product = @IdProduct, Quantity = @Quantity, " +
                                         "UnitPrice = @UnitPrice, Discount = @Discount, ModifiedDate = GETDATE() " +
                                         "WHERE Id_SalesOrderDetail = @IdSalesOrderDetail", connection);

            command.Parameters.AddWithValue("@IdSalesOrderDetail", entity.IdSalesOrderDetail);
            command.Parameters.AddWithValue("@IdSalesOrder", entity.IdSalesOrder);
            command.Parameters.AddWithValue("@IdProduct", entity.IdProduct);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("@Discount", entity.Discount ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}
