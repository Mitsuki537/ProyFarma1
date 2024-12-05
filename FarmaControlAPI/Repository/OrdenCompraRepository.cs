using FarmaControlAPI.Data;
using SharedModels;
using System.Data.SqlClient;

namespace FarmaControlAPI.Repository
{
    public class OrdenCompraRepository : IOrdenCompraRepository<OrdenCompra>
    {
        private readonly DatabaseContext _dbContext;

        public OrdenCompraRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(OrdenCompra entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("INSERT INTO [Purchasing].[PurchaseOrders] " +
                                         "(Id_Supplier, OrderDate, Status, ModifiedDate) " +
                                         "VALUES (@Id_Supplier, @OrderDate, @Status, @ModifiedDate); " +
                                         "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@Id_Supplier", entity.IdSupplier);
            command.Parameters.AddWithValue("@OrderDate", entity.OrderDate);
            command.Parameters.AddWithValue("@Status", entity.Status ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
          //  command.Parameters.AddWithValue("@OrderNumber", entity.OrderNumber);
            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM [Purchasing].[PurchaseOrders] WHERE Id_PurchaseOrder = @Id_PurchaseOrder", connection);
            command.Parameters.AddWithValue("@Id_PurchaseOrder", id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<OrdenCompra>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Purchasing].[PurchaseOrders]", connection);
            var orders = new List<OrdenCompra>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                orders.Add(new OrdenCompra
                {
                    IdPurchaseOrder = reader.GetInt32(0),
                    IdSupplier = reader.GetInt32(1),
                    OrderDate = reader.GetDateTime(2),
                    Status = reader.IsDBNull(3) ? null : reader.GetString(3),
                    ModifiedDate = reader.GetDateTime(4),
                    OrderNumber = reader.IsDBNull(5) ? null : reader.GetString(5)
                });
            }
            return orders;
        }

        public async Task<OrdenCompra> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Purchasing].[PurchaseOrders] WHERE Id_PurchaseOrder = @Id_PurchaseOrder", connection);
            command.Parameters.AddWithValue("@Id_PurchaseOrder", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new OrdenCompra
                {
                    IdPurchaseOrder = reader.GetInt32(0),
                    IdSupplier = reader.GetInt32(1),
                    OrderDate = reader.GetDateTime(2),
                    Status = reader.IsDBNull(3) ? null : reader.GetString(3),
                    ModifiedDate = reader.GetDateTime(4),
                    OrderNumber = reader.IsDBNull(5) ? null : reader.GetString(5)
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(OrdenCompra entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("UPDATE [Purchasing].[PurchaseOrders] SET " +
                                         "Id_Supplier = @Id_Supplier, OrderDate = @OrderDate, Status = @Status, " +
                                         "ModifiedDate = @ModifiedDate, OrderNumber = @OrderNumber WHERE Id_PurchaseOrder = @Id_PurchaseOrder", connection);

            command.Parameters.AddWithValue("@Id_PurchaseOrder", entity.IdPurchaseOrder);
            command.Parameters.AddWithValue("@Id_Supplier", entity.IdSupplier);
            command.Parameters.AddWithValue("@OrderDate", entity.OrderDate);
            command.Parameters.AddWithValue("@Status", entity.Status ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            command.Parameters.AddWithValue("@OrderNumber", entity.OrderNumber ?? (object)DBNull.Value);
            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}
