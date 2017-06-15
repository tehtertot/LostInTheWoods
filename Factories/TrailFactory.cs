using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using lostInTheWoods.Models;

namespace lostInTheWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=woods;SslMode=None";
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(Trail t) {
            using (IDbConnection dbConnection = Connection) {
                string query = "INSERT INTO trail (name, description, trail_length, elevation, longitude, latitude, created_at, updated_at) VALUES (@Name, @Description, @Trail_Length, @Elevation, @Longitude, @Latitude, now(), now());";
                dbConnection.Open();
                dbConnection.Execute(query, t);
            }
        }
        public List<Trail> All() {
            using (IDbConnection dbConnection = Connection) {
                string query = "SELECT * FROM trail";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query).ToList();
            }
        }
        public Trail GetById(int id) {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trail WHERE id=@Id", new {ID = id}).FirstOrDefault();
            }
        }
    }
}