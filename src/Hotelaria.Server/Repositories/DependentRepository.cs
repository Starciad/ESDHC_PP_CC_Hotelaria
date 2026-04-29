using Hotelaria.Server.Models;
using MySqlConnector;

namespace Hotelaria.Server.Repositories
{
    public class DependentRepository
    {
        public async Task<int> Create(Dependent d)
        {
            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(@"
                INSERT INTO dependants (name, birth_date, guest_id)
                VALUES (@n, @b, @g);
                SELECT LAST_INSERT_ID();", conn);

            cmd.Parameters.AddWithValue("@n", d.Name);
            cmd.Parameters.AddWithValue("@b", d.BirthDate);
            cmd.Parameters.AddWithValue("@g", d.GuestId);

            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        public async Task<List<Dependent>> GetByGuest(int guestId)
        {
            var list = new List<Dependent>();

            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(
                "SELECT * FROM dependants WHERE guest_id = @g", conn);

            cmd.Parameters.AddWithValue("@g", guestId);

            using var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                list.Add(new Dependent
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    BirthDate = reader.GetDateTime("birth_date"),
                    GuestId = reader.GetInt32("guest_id")
                });
            }

            return list;
        }

        public async Task Delete(int id)
        {
            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand("DELETE FROM dependants WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}