using System.Data;
using System.Data.SqlClient;
using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public class SeanceRepository: ISeanceRepository
    {
        private readonly string _connectionString;

        public SeanceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Seance> GetSeances()
        {
            List<Seance> seances = new List<Seance>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Seance]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            seances.Add(new Seance
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                DateSeance = Convert.ToInt32(reader["DateSeance"]),
                                Title = Convert.ToString(reader["Title"]),
                                FilmId = Convert.ToInt32(reader["FilmId"])
                            });
                        }
                    }
                }
            }
            return seances;
        }

        public int Create(Seance seance)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Seance] (DateSeance,Title, FilmId) VALUES (@dateSeance, @title,@filmId)";
                    cmd.Parameters.Add("@DateStart", SqlDbType.NVarChar).Value = seance.DateSeance;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = seance.Title;
                    cmd.Parameters.Add("@faculty_id", SqlDbType.Int).Value = seance.FilmId;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(Seance seance)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Seance] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = seance.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Seance Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Seance] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Seance
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                DateSeance = Convert.ToInt32(reader["DateSeance"]),
                                Title = Convert.ToString(reader["Title"]),
                                FilmId = Convert.ToInt32(reader["FilmId"])
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

        public int Update(Seance seance)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Seance] SET [DateSeance] = @dateSeance, [Title] = @title, [FilmId] = @filmid
                        WHERE [id] = @id";
                    
                    cmd.Parameters.Add("@DateStart", SqlDbType.NVarChar).Value = seance.DateSeance;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = seance.Title;
                    cmd.Parameters.Add("@faculty_id", SqlDbType.Int).Value = seance.FilmId;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
}
