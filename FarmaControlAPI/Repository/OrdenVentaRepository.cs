using FarmaControlAPI.Data;
using SharedModels;
using System.Data.SqlClient;

namespace FarmaControlAPI.Repository
{
    public class OrdenVentaRepository : IOrdenVentaRepository<OrdenVenta>
    {
        private readonly DatabaseContext _dbContext;

        public OrdenVentaRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(OrdenVenta entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand(
                "INSERT INTO [Sales].[SalesOrders] (Id_Customer, Id_Employee, OrderDate) " +
                "VALUES (@Id_Customer, @Id_Employee, @OrderDate); " +
                "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@Id_Customer", entity.IdCustomer);
            command.Parameters.AddWithValue("@Id_Employee", entity.IdEmployee);
            command.Parameters.AddWithValue("@OrderDate", entity.OrderDate);

            var result = await command.ExecuteScalarAsync();

            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                throw new Exception("No se pudo obtener el ID de la orden de venta creada.");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM [Sales].[SalesOrders] WHERE Id_SalesOrder = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<OrdenVenta>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Sales].[SalesOrders]", connection);
            var salesOrders = new List<OrdenVenta>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                salesOrders.Add(new OrdenVenta
                {
                    IdSalesOrder = reader.GetInt32(0),
                    IdCustomer = reader.GetInt32(1),
                    IdEmployee = reader.GetInt32(2),    
                    OrderDate = reader.GetDateTime(3),
                    ModifiedDate = reader.GetDateTime(4),
                    OrderNumber = reader.IsDBNull(5) ? null : reader.GetString(5),

                });
            }

            return salesOrders;
        }

        public async Task<OrdenVenta> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Sales].[SalesOrders] WHERE Id_SalesOrder = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new OrdenVenta
                {
                    IdSalesOrder = reader.GetInt32(0),
                    IdCustomer = reader.GetInt32(1),
                    IdEmployee = reader.GetInt32(2),
                    OrderDate = reader.GetDateTime(3),
                    ModifiedDate = reader.GetDateTime(4),
                    OrderNumber = reader.IsDBNull(5) ? null : reader.GetString(5)  
                };
            }

            return null;
        }

        public async Task<bool> UpdateAsync(OrdenVenta entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand(
                "UPDATE [Sales].[SalesOrders] SET Id_Customer = @Id_Customer, Id_Employee = @Id_Employee, " +
                "OrderDate = @OrderDate, ModifiedDate = GETDATE(), OrderNumber = @OrderNumber WHERE Id_SalesOrder = @Id_SalesOrder", connection);

            command.Parameters.AddWithValue("@Id_SalesOrder", entity.IdSalesOrder);
            command.Parameters.AddWithValue("@Id_Customer", entity.IdCustomer);
            command.Parameters.AddWithValue("@Id_Employee", entity.IdEmployee);
            command.Parameters.AddWithValue("@OrderDate", entity.OrderDate);
            command.Parameters.AddWithValue("@OrderNumber", entity.OrderNumber ?? (object)DBNull.Value);
           

            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}
