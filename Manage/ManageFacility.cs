using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Manage
{
    public class ManageFacility : IManage<Facility>
    {
        private const string tablename = "DemoFacility";

        public List<Facility> GetAll()
        {
            List<Facility> list = StartReader($"select * from {tablename}");
            return list;
        }

        public Facility GetFromId(int objNr)
        {
            Facility facility = StartReader($"select * from {tablename} where Facility_Id = {objNr}")[0];
            return facility;
        }

        public bool Create(Facility obj)
        {
            int rowsAffected = StartNonQuery($"insert into {tablename} values ({obj.Facility_Id},'{obj.Name}','{obj.Type}')");
            return (rowsAffected == 1);
        }

        public bool Update(Facility obj, int objNr)
        {
            int rowsAffected = StartNonQuery($"UPDATE {tablename} SET Name='{obj.Name}', Type='{obj.Type}' WHERE Facility_Id={objNr}");
            return (rowsAffected == 1);
        }

        public Facility Delete(int objNr)
        {
            Facility facility = GetFromId(objNr);
            StartNonQuery($"DELETE FROM {tablename} WHERE Facility_Id={objNr}");
            return facility;
        }

        /// <summary>
        /// Connecter til lokal SQL DB og laver det serieliserede svar om til en list med objekter
        /// </summary>
        /// <param name="queryString">Tager imod en T-SQL string</param>
        /// <returns>Returnere en liste med objekter</returns>
        public List<Facility> StartReader(string queryString)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HotelDemo; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            List<Facility> list = new List<Facility>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string address = reader.GetString(2);

                    list.Add(new Facility(id, name, address));
                }
                command.Connection.Close();

                return list;
            }
        }

        /// <summary>
        /// Eksekvere en T-SQL string på en lokal SQL DB
        /// </summary>
        /// <param name="queryString">Tager imod en T-SQL string</param>
        /// <returns>Returnerer antal rækker ændret i DB</returns>
        public int StartNonQuery(string queryString)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelDemo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                int affectedrows = command.ExecuteNonQuery();
                command.Connection.Close();

                return affectedrows;
            }
        }
    }
}
