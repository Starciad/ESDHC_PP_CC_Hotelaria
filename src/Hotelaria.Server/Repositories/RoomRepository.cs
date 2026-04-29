using Hotelaria.Server.Models;
using MySqlConnector;

namespace Hotelaria.Server.Repositories
{
    public class RoomRepository
    {
        public async Task<int> Create(Room r)
        {
            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(@"
                INSERT INTO room (description, price, capacity)
                VALUES (@d, @p, @c);
                SELECT LAST_INSERT_ID();", conn);

            cmd.Parameters.AddWithValue("@d", r.Description);
            cmd.Parameters.AddWithValue("@p", r.Price);
            cmd.Parameters.AddWithValue("@c", r.Capacity);

            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        public async Task<List<Room>> GetAll()
        {
            var list = new List<Room>();

            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand("SELECT * FROM room", conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                list.Add(new Room
                {
                    Id = reader.GetInt32("id"),
                    Description = reader.GetString("description"),
                    Price = reader.GetDouble("price"),
                    Capacity = reader.GetInt32("capacity")
                });
            }

            return list;
        }

        public async Task Delete(int id)
        {
            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand("DELETE FROM room WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}