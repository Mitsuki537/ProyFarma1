using FarmaControlAPI.Data;
using SharedModels;
using System.Data.SqlClient;

namespace FarmaControlAPI.Repository
{
    public class InventarioMovimientoRepository : IInventorioMovimientoRepository<Movimiento>
    {
        private readonly DatabaseContext _dbContext;

        public InventarioMovimientoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movimiento>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Inventory].[InventoryMovements]", connection);
            var movements = new List<Movimiento>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                movements.Add(new Movimiento
                {
                    IdMovement = reader.GetInt32(0),
                    IdInventory = reader.GetInt32(1),
                    MovementType = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Quantity = reader.GetInt32(3),
                    MovementDate = reader.GetDateTime(4)   
                });
            }
            return movements;
        }

        public async Task<Movimiento> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Inventory].[InventoryMovements] WHERE Id_Movement = @Id_Movement", connection);
            command.Parameters.AddWithValue("@Id_Movement", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Movimiento
                {
                    IdMovement = reader.GetInt32(0),
                    IdInventory = reader.GetInt32(1),
                    MovementType = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Quantity = reader.GetInt32(3),
                    ModifiedDate = reader.GetDateTime(6)
                };
            }
            return null;
        }
    }
}

