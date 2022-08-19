using System.Data;
using System.Data.SqlClient;
using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public  class FilmRepository: IFilmRepository
    {
        private readonly string _connectionString;

        public FilmRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Film> GetFilms()
        {
            List<Film> films = new List<Film>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Film]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            films.Add(new Film
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Denomination = Convert.ToString(reader["Denomination"]),
                                DateStart = Convert.ToInt32(reader["DateStart"]),
                                Company = Convert.ToString(reader["Company"])
                            });
                        }
                    }
                }
            }
            return films;
        }

        public int Create(Film film)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Film] (Denomination, DateStart, Company) VALUES (@denomination, @dateStart,@company)";
                    cmd.Parameters.Add("@denomination", SqlDbType.NVarChar).Value = film.Denomination;
                    cmd.Parameters.Add("@dateStart", SqlDbType.Int).Value = film.DateStart;
                    cmd.Parameters.Add("@company", SqlDbType.NVarChar).Value = film.Company;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(Film film)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Film] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = film.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Film Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Film] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Film
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Denomination = Convert.ToString(reader["Denomination"]),
                                DateStart = Convert.ToInt32(reader["DateStart"]),
                                Company = Convert.ToString(reader["Company"])
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public int Update(Film film)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"UPDATE [Film] SET [Denomination] = @denomination, [DateStart] = @dateStart, [Company] = @company
                        WHERE [id] = @id";

                cmd.Parameters.Add("@denomination", SqlDbType.NVarChar).Value = film.denomination;
                cmd.Parameters.Add("@dateStart", SqlDbType.Int).Value = film.dateStart;
                cmd.Parameters.Add("@company", SqlDbType.NVarChar).Value = film.company;

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
}
