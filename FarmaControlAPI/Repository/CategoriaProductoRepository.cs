
using FarmaControlAPI.Data;
using SharedModels;
using System.Data.SqlClient;

namespace FarmaControlAPI.Repository
{
    public class CategoriaProductoRepository : ICategoriaProductoRepository<CategoriaProducto>
    {
        private readonly DatabaseContext _dbContext;

        public CategoriaProductoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> CreateAsync(CategoriaProducto entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("INSERT INTO [Products].[ProductCategories] " +
                                         "(Id_ParentCategory, CategoryName, ModifiedDate) " +
                                         "VALUES (@Id_ParentCategory, @CategoryName, GETDATE()); " +
                                         "SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddWithValue("@Id_ParentCategory", entity.IdParentCategory ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM [Products].[ProductCategories] WHERE Id_Category = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<IEnumerable<CategoriaProducto>> GetAllAsync()
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT * FROM [Products].[ProductCategories]", connection);
            var categorias = new List<CategoriaProducto>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                categorias.Add(new CategoriaProducto
                {
                    IdCategory = reader.GetInt32(0),
                    IdParentCategory = reader.IsDBNull(1) ? null : reader.GetInt32(1),
                    CategoryName = reader.GetString(2),
                    ModifiedDate = reader.GetDateTime(3)
                });
            }
            return categorias;
        }

        public async Task<CategoriaProducto> GetByIdAsync(int id)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT Id_Category, Id_ParentCategory, CategoryName, ModifiedDate " +
                               "FROM [Products].[ProductCategories] WHERE Id_Category = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new CategoriaProducto
                {
                    IdCategory = reader.GetInt32(0),
                    IdParentCategory = reader.IsDBNull(1) ? null : reader.GetInt32(1),
                    CategoryName = reader.GetString(2),
                    ModifiedDate = reader.GetDateTime(3)
                };
            }
            return null;
        }

        public async Task<bool> UpdateAsync(CategoriaProducto entity)
        {
            using var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            var command = new SqlCommand("UPDATE [Products].[ProductCategories] SET " +
                                 "Id_ParentCategory = @Id_ParentCategory, CategoryName = @CategoryName, " +
                                 "ModifiedDate = GETDATE() " +
                                 "WHERE Id_Category = @Id_Category", connection);

            command.Parameters.AddWithValue("@Id_Category", entity.IdCategory);
            command.Parameters.AddWithValue("@Id_ParentCategory", entity.IdParentCategory ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}
