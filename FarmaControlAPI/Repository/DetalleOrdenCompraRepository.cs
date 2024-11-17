using FarmaControlAPI.Data;
using SharedModels;
using System.Data.SqlClient;

namespace FarmaControlAPI.Repository
{
    public class DetalleOrdenCompraRepository : IDetalleOrdenCompraRepository<DetalleOrdenCompra>
    {
        private readonly DatabaseContext _dbContext;

        public DetalleOrdenCompraRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(DetalleOrdenCompra entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("INSERT INTO [Purchasing].[PurchaseOrderDetails] " +
                                         "(Id_PurchaseOrder, Id_Product, Quantity, UnitPrice, ReturnDeadline, ModifiedDate) " +
                                         "VALUES (@IdPurchaseOrder, @IdProduct, @Quantity, @UnitPrice, @ReturnDeadline, GETDATE()); " +
                                         "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@IdPurchaseOrder", entity.IdPurchaseOrder);
            command.Parameters.AddWithValue("@IdProduct", entity.IdProduct);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("@ReturnDeadline", entity.ReturnDeadline);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM [Purchasing].[PurchaseOrderDetails] WHERE Id_PurchaseOrderDetail = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<DetalleOrdenCompra>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Purchasing].[PurchaseOrderDetails]", connection);
            var detalles = new List<DetalleOrdenCompra>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                detalles.Add(new DetalleOrdenCompra
                {
                    IdPurchaseOrderDetail = reader.GetInt32(0),
                    IdPurchaseOrder = reader.GetInt32(1),
                    IdProduct = reader.GetInt32(2),
                    Quantity = reader.GetInt32(3),
                    UnitPrice = reader.GetDecimal(4),
                    LineTotal = reader.GetDecimal(5),
                    ModifiedDate = reader.GetDateTime(6),
                    ReturnDeadline = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7)
                });
            }
            return detalles;
        }

        public async Task<DetalleOrdenCompra> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Purchasing].[PurchaseOrderDetails] WHERE Id_PurchaseOrderDetail = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new DetalleOrdenCompra
                {
                    IdPurchaseOrderDetail = reader.GetInt32(0),
                    IdPurchaseOrder = reader.GetInt32(1),
                    IdProduct = reader.GetInt32(2),
                    Quantity = reader.GetInt32(3),
                    UnitPrice = reader.GetDecimal(4),
                    LineTotal = reader.GetDecimal(5), 
                    ModifiedDate = reader.GetDateTime(6),
                    ReturnDeadline = reader.GetDateTime(7)
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(DetalleOrdenCompra entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("UPDATE [Purchasing].[PurchaseOrderDetails] SET " +
                                         "Id_PurchaseOrder = @IdPurchaseOrder, Id_Product = @IdProduct, Quantity = @Quantity, " +
                                         "UnitPrice = @UnitPrice, ReturnDeadline = @ReturnDeadline, ModifiedDate = GETDATE() " +
                                         "WHERE Id_PurchaseOrderDetail = @IdPurchaseOrderDetail", connection);

            command.Parameters.AddWithValue("@IdPurchaseOrderDetail", entity.IdPurchaseOrderDetail);
            command.Parameters.AddWithValue("@IdPurchaseOrder", entity.IdPurchaseOrder);
            command.Parameters.AddWithValue("@IdProduct", entity.IdProduct);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("@ReturnDeadline", entity.ReturnDeadline);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}
