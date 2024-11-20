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
    }
}
