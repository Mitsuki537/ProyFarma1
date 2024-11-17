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

        public async Task<int> CreateAsync(Movimiento entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("INSERT INTO [Inventory].[InventoryMovements] " +
                                         "(Id_Inventory, MovementType, Quantity, MovementDate, ReferenceID, ModifiedDate) " +
                                         "VALUES (@Id_Inventory, @MovementType, @Quantity, @MovementDate, @ReferenceID, @ModifiedDate); " +
                                         "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@Id_Inventory", entity.IdInventory);
            command.Parameters.AddWithValue("@MovementType", entity.MovementType ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);
            command.Parameters.AddWithValue("@MovementDate", entity.MovementDate);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            if (entity.ReferenceID.HasValue)
                command.Parameters.AddWithValue("@ReferenceID", entity.ReferenceID.Value);
            else
                command.Parameters.AddWithValue("@ReferenceID", DBNull.Value);
            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM [Inventory].[InventoryMovements] WHERE Id_Movement = @Id_Movement", connection);
            command.Parameters.AddWithValue("@Id_Movement", id);

            return await command.ExecuteNonQueryAsync() > 0;
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
                    MovementDate = reader.GetDateTime(4),
                    ReferenceID = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                    ModifiedDate = reader.GetDateTime(6)
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
                    MovementDate = reader.GetDateTime(4),
                    ReferenceID = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                    ModifiedDate = reader.GetDateTime(6)
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Movimiento entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("UPDATE [Inventory].[InventoryMovements] SET " +
                                         "Id_Inventory = @Id_Inventory, MovementType = @MovementType, Quantity = @Quantity, " +
                                         "MovementDate = @MovementDate, ReferenceID = @ReferenceID, ModifiedDate = @ModifiedDate " +
                                         "WHERE Id_Movement = @Id_Movement", connection);

            command.Parameters.AddWithValue("@Id_Movement", entity.IdMovement);
            command.Parameters.AddWithValue("@Id_Inventory", entity.IdInventory);
            command.Parameters.AddWithValue("@MovementType", entity.MovementType ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);
            command.Parameters.AddWithValue("@MovementDate", entity.MovementDate);
            command.Parameters.AddWithValue("@ReferenceID", entity.ReferenceID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}

