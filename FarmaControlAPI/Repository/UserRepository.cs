using FarmaControlAPI.Data;
using SharedModels;
using System.Data.SqlClient;
namespace FarmaControlAPI.Repository
{
    public class UserRepository : IUsuarioRepository<Usuario>
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Usuario entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(entity.PasswordHash);

            var command = new SqlCommand("INSERT INTO [Employees].[Users] (Username, PasswordHash, Id_Employee, Role, CreatedDate, ModifiedDate) " +
                                          "VALUES (@Username, @PasswordHash, @Id_Employee, @Role, @CreatedDate, @ModifiedDate); SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@Username", entity.Username);
            command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
            command.Parameters.AddWithValue("@Id_Employee", entity.IdEmployee);
            command.Parameters.AddWithValue("@Role", entity.Role);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();
            var command = new SqlCommand("DELETE FROM [Employees].[Users] WHERE Id_User = @Id_User", connection);

            command.Parameters.AddWithValue("@Id_User", id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();
            var command = new SqlCommand("SELECT * FROM [Employees].[Users]", connection);

            var users = new List<Usuario>();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    users.Add(new Usuario
                    {
                        IdUser = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        CreatedDate = (DateTime)(reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)),
                        ModifiedDate = (DateTime)(reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6))     
                    });
                }
            }
            return users;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();
            var command = new SqlCommand("SELECT Id_User, Username, PasswordHash, Id_Employee, Role, CreatedDate, ModifiedDate FROM [Employees].[Users] WHERE Id_User = @Id_User", connection);

            command.Parameters.AddWithValue("@Id_User", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Usuario
                {
                    IdUser = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    PasswordHash = reader.GetString(2),
                    IdEmployee = reader.GetInt32(3),
                    Role = reader.GetString(4),
                    CreatedDate = (DateTime)(reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)),
                    ModifiedDate = (DateTime)(reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6))
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Usuario entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();
            var command = new SqlCommand("UPDATE [Employees].[Users] SET Username = @Username, PasswordHash = @PasswordHash, " +
                                          "Id_Employee = @Id_Employee, Role = @Role, ModifiedDate = @ModifiedDate WHERE Id_User = @Id_User", connection);

            command.Parameters.AddWithValue("@Id_User", entity.IdUser);
            command.Parameters.AddWithValue("@Username", entity.Username);
            command.Parameters.AddWithValue("@PasswordHash", entity.PasswordHash);
            command.Parameters.AddWithValue("@Id_Employee", entity.IdEmployee);
            command.Parameters.AddWithValue("@Role", entity.Role);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return await command.ExecuteNonQueryAsync() > 0; 
        }
        public async Task<bool> EmployeeExistAsync(int idEmployee)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();
            var command = new SqlCommand("SELECT COUNT(1) FROM [Employees].[Users] WHERE Id_Employee = @Id_Employee", connection);
            command.Parameters.AddWithValue("@Id_Employee", idEmployee);

            var count = Convert.ToInt32(await command.ExecuteScalarAsync());
            return count > 0;
        }

    }

}
