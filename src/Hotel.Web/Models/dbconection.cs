using MySqlConnector;

namespace Hotelaria.Server.Models
{
    public static class Db
    {
        public static string ConnectionString =
            "server=mysql;port=3306;database=meubanco;user=admin;password=123456";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}