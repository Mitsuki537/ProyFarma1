using FarmaControlAPI.Data;
using SharedModels;
using System.Data.SqlClient;

namespace FarmaControlAPI.Repository
{
    public class ClienteRepository : ICLienteRepository<Client>
    {
        private readonly DatabaseContext _dbContext;

        public ClienteRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Client entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("INSERT INTO [Sales].[Customers] " +
                                         "(FirstName, LastName, Phone, RegistrationDate) " +
                                         "VALUES (@FirstName, @LastName, @Phone, GETDATE()); " +
                                         "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Phone", entity.Phone ?? (object)DBNull.Value);

            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM [Sales].[Customers] WHERE Id_Customer = @Id_Customer", connection);
            command.Parameters.AddWithValue("@Id_Customer", id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Sales].[Customers]", connection);
            var customers = new List<Client>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                customers.Add(new Client
                {
                    IdCustomer = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.IsDBNull(3) ? null : reader.GetString(3),
                    RegistrationDate = reader.GetDateTime(4)
                });
            }
            return customers;
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Sales].[Customers] WHERE Id_Customer = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Client
                {
                    IdCustomer = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.IsDBNull(3) ? null : reader.GetString(3),
                    RegistrationDate = reader.GetDateTime(4)
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Client entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("UPDATE [Sales].[Customers] SET " +
                                         "FirstName = @FirstName, LastName = @LastName, Phone = @Phone " +
                                         "WHERE Id_Customer = @Id_Customer", connection);

            command.Parameters.AddWithValue("@Id_Customer", entity.IdCustomer);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Phone", entity.Phone ?? (object)DBNull.Value);

            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}
