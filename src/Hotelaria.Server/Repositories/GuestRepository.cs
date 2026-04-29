using Hotelaria.Server.Models;
using MySqlConnector;

namespace Hotelaria.Server.Repositories
{
    public class GuestRepository
    {
        public async Task<int> Create(Guest g)
        {
            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(@"
                INSERT INTO guest (name, cpf, phone)
                VALUES (@n, @cpf, @p);
                SELECT LAST_INSERT_ID();", conn);

            cmd.Parameters.AddWithValue("@n", g.Name);
            cmd.Parameters.AddWithValue("@cpf", g.CPF);
            cmd.Parameters.AddWithValue("@p", g.Phone);

            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        public async Task<List<Guest>> GetAll()
        {
            var list = new List<Guest>();

            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand("SELECT * FROM guest", conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                list.Add(new Guest
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    CPF = reader.GetString("cpf"),
                    Phone = reader.GetString("phone")
                });
            }

            return list;
        }

        public async Task Delete(int id)
        {
            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand("DELETE FROM guest WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}