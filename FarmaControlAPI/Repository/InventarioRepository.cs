using FarmaControlAPI.Data;
using SharedModels;
using System.Data.SqlClient;

namespace FarmaControlAPI.Repository
{
    public class InventarioRepository : IInventarioRepository<Inventario>
    {
        private readonly DatabaseContext _dbContext;

        public InventarioRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Inventario entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("INSERT INTO [Inventory].[Inventories] " +
                                         "(Id_Product, Quantity, DateReceived, ModifiedDate) " +
                                         "VALUES (@Id_Product, @Quantity, @DateReceived, @ModifiedDate); " +
                                         "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@Id_Product", entity.IdProduct);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);
            command.Parameters.AddWithValue("@DateReceived", entity.DateReceived);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM [Inventory].[Inventories] WHERE Id_Inventory = @Id_Inventory", connection);
            command.Parameters.AddWithValue("@Id_Inventory", id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<Inventario>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Inventory].[Inventories]", connection);
            var inventories = new List<Inventario>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                inventories.Add(new Inventario
                {
                    IdInventory = reader.GetInt32(reader.GetOrdinal("Id_Inventory")),
                    IdProduct = reader.GetInt32(reader.GetOrdinal("Id_Product")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    DateReceived = reader.GetDateTime(reader.GetOrdinal("DateReceived")),
                    ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"))
                });
            }
            return inventories;
        }

        public async Task<Inventario> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Inventory].[Inventories] WHERE Id_Inventory = @Id_Inventory", connection);
            command.Parameters.AddWithValue("@Id_Inventory", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Inventario
                {
                    IdInventory = reader.GetInt32(reader.GetOrdinal("Id_Inventory")),
                    IdProduct = reader.GetInt32(reader.GetOrdinal("Id_Product")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    DateReceived = reader.GetDateTime(reader.GetOrdinal("DateReceived")),
                    ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"))
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Inventario entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("UPDATE [Inventory].[Inventories] SET " +
                                         "Id_Product = @Id_Product, Quantity = @Quantity, DateReceived = @DateReceived, " +
                                         "ModifiedDate = @ModifiedDate WHERE Id_Inventory = @Id_Inventory", connection);

            command.Parameters.AddWithValue("@Id_Inventory", entity.IdInventory);
            command.Parameters.AddWithValue("@Id_Product", entity.IdProduct);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);
            command.Parameters.AddWithValue("@DateReceived", entity.DateReceived);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}
