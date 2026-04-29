using Hotelaria.Server.Models;
using MySqlConnector;

namespace Hotelaria.Server.Repositories
{
    public class EmployeeRepository
    {
        public async Task<int> Create(Employee e)
        {
            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(@"
                INSERT INTO employees (name, cpf, admission_date, salary, pis, is_admin)
                VALUES (@n, @cpf, @d, @s, @p, @a);
                SELECT LAST_INSERT_ID();", conn);

            cmd.Parameters.AddWithValue("@n", e.Name);
            cmd.Parameters.AddWithValue("@cpf", e.CPF);
            cmd.Parameters.AddWithValue("@d", e.AdmissionDate);
            cmd.Parameters.AddWithValue("@s", e.Salary);
            cmd.Parameters.AddWithValue("@p", e.PIS);
            cmd.Parameters.AddWithValue("@a", e.IsAdmin);

            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        public async Task<List<Employee>> GetAll()
        {
            var list = new List<Employee>();

            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand("SELECT * FROM employees", conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                list.Add(new Employee
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    CPF = reader.GetString("cpf"),
                    AdmissionDate = reader.GetDateTime("admission_date"),
                    Salary = reader.GetDecimal("salary"),
                    PIS = reader.GetString("pis"),
                    IsAdmin = reader.GetBoolean("is_admin")
                });
            }

            return list;
        }

        public async Task Delete(int id)
        {
            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand("DELETE FROM employees WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}