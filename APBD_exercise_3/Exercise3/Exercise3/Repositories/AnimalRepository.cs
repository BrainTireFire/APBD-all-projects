using Exercise3.Models;
using Exercise3.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Exercise3.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly string _connectionString;
        public AnimalRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default")
                ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task AddAnimal(AnimalPOST animalPOST)
        {
            string query = $"INSERT INTO [dbo].[Animal] ([ID], [Name], [Description], [Category], [Area]) VALUES (@ID, @Name, @Description, @Category, @Area)";

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@ID", animalPOST.ID);
                sqlCommand.Parameters.AddWithValue("@Name", animalPOST.Name);
                sqlCommand.Parameters.AddWithValue("@Description", animalPOST.Description);
                sqlCommand.Parameters.AddWithValue("@Category", animalPOST.Category);
                sqlCommand.Parameters.AddWithValue("@Area", animalPOST.Area);

                await connection.OpenAsync();

                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task<bool> DoesAnimalExist(int animalID)
        {
            string query = $"SELECT COUNT(*) FROM [dbo].[Animal] WHERE [ID] = {animalID}";

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                await connection.OpenAsync();

                int count = (int)await sqlCommand.ExecuteScalarAsync();

                return count > 0;
            }
        }

        public async Task UpdateAnimal(int animalID, AnimalPUT animalPUT)
        {
            string query = $"UPDATE [dbo].[Animal] SET [Name] = @Name, [Description] =  @Description, [Category] = @Category, [Area] = @Area WHERE [ID] = {animalID}";

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Name", animalPUT.Name);
                sqlCommand.Parameters.AddWithValue("@Description", animalPUT.Description);
                sqlCommand.Parameters.AddWithValue("@Category", animalPUT.Category);
                sqlCommand.Parameters.AddWithValue("@Area", animalPUT.Area);

                await connection.OpenAsync();

                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task<ICollection<Animal>> GetAnimalsAsync(string orderBy)
        {
            string query = $"SELECT * FROM Animal ORDER BY {orderBy}";
            var animals = new List<Animal>();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                await connection.OpenAsync();

                using (var reader = await sqlCommand.ExecuteReaderAsync())
                {
                    int ID = reader.GetOrdinal("ID");
                    int Name = reader.GetOrdinal("Name");
                    int Description = reader.GetOrdinal("Description");
                    int Category = reader.GetOrdinal("Category");
                    int Area = reader.GetOrdinal("Area");

                    while(await reader.ReadAsync())
                    {
                        animals.Add(new Animal
                        {
                            ID = reader.GetInt32(ID),
                            Name = reader.GetString(Name),
                            Description = reader.GetString(Description),
                            Category = reader.GetString(Category),
                            Area = reader.GetString(Area)
                        });
                    }
                }
            }

            return animals;
        }

        public async Task DeleteAnimal(int animalID)
        {
            string query = $"DELETE FROM [dbo].[Animal] WHERE [ID] = {animalID}";

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                await connection.OpenAsync();

                await sqlCommand.ExecuteNonQueryAsync();
            }
        }
    }
}
