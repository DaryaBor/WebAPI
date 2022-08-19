using System.Data;
using System.Data.SqlClient;
using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly string _connectionString;

        public TicketsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Tickets> GetStudents()
        {
            List<Tickets> tickets = new List<Tickets>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Tickets]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tickets.Add(new Tickets
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Number = Convert.ToInt32(reader["Number"]),
                                SeanceNumber = Convert.ToInt32(reader["SeanceNumber"]),
                                Place = Convert.ToInt32(reader["Place"]),
                                Cost = Convert.ToInt32(reader["Cost"]),
                                SeanceId = Convert.ToInt32(reader["SeanceId"])
                            });
                        }
                    }
                }
            }
            return tickets;
        }

        public int Create(Tickets ticket)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Tickets] (Number, SeanceNumber, Place, Cost, SeanceId) VALUES (@number, @seanceNumber, @place, @cost, @seanceId)";
                    cmd.Parameters.Add("@number", SqlDbType.Int).Value = ticket.Number;
                    cmd.Parameters.Add("@seanceNumber", SqlDbType.Int).Value = ticket.SeanceNumber;
                    cmd.Parameters.Add("@place", SqlDbType.Int).Value = ticket.Place;
                    cmd.Parameters.Add("@cost", SqlDbType.Int).Value = ticket.Cost;
                    cmd.Parameters.Add("@seanceId", SqlDbType.Int).Value = ticket.SeanceId;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(Tickets ticket)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Tickets] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = ticket.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Tickets Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Tickets] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Tickets
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Number = Convert.ToInt32(reader["Number"]),
                                SeanceNumber = Convert.ToInt32(reader["SeanceNumber"]),
                                Place = Convert.ToInt32(reader["Place"]),
                                Cost = Convert.ToInt32(reader["Cost"]),
                                SeanceId = Convert.ToInt32(reader["SeanceId"])
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

        public int Update(Tickets ticket)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Tickets] SET [Number] = @number, [SeanceNumber] = @seanceNumber, [Place] = @place, [Cost] = @cost, [SeanceId] = @seanceid
                        WHERE [id] = @id";
                    cmd.Parameters.Add("@number", SqlDbType.Int).Value = ticket.Number;
                    cmd.Parameters.Add("@seanceNumber", SqlDbType.Int).Value = ticket.SeanceNumber;
                    cmd.Parameters.Add("@place", SqlDbType.Int).Value = ticket.Place;
                    cmd.Parameters.Add("@cost", SqlDbType.Int).Value = ticket.Cost;
                    cmd.Parameters.Add("@seanceId", SqlDbType.Int).Value = ticket.SeanceId;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
}
