using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Manage
{
    public class ManageHotel : IManage<Hotel>
    {
        private const string tablename = "DemoHotel";

        public List<Hotel> GetAll()
        {
            List<Hotel> list = StartReader($"select * from {tablename}");
            return list;
        }

        public Hotel GetFromId(int objNr)
        {
            Hotel hotel = StartReader($"select * from {tablename} where Hotel_No = {objNr}")[0];
            return hotel;
        }

        public bool Create(Hotel obj)
        {
            int rowsAffected = StartNonQuery($"insert into {tablename} values ({obj.Hotel_No},'{obj.Name}','{obj.Address}')");
            return (rowsAffected == 1);
        }

        public bool Update(Hotel obj, int objNr)
        {
            int rowsAffected = StartNonQuery($"UPDATE {tablename} SET Name='{obj.Name}', Address='{obj.Address}' WHERE Hotel_No={objNr}");
            return (rowsAffected == 1);
        }

        public Hotel Delete(int objNr)
        {
            Hotel hotel = GetFromId(objNr);
            StartNonQuery($"DELETE FROM {tablename} WHERE Hotel_No={objNr}");
            return hotel;
        }

        /// <summary>
        /// Connecter til lokal SQL DB og laver det serieliserede svar om til en list med objekter
        /// </summary>
        /// <param name="queryString">Tager imod en T-SQL string</param>
        /// <returns>Returnere en liste med objekter</returns>
        public List<Hotel> StartReader(string queryString)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HotelDemo; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            List<Hotel> list = new List<Hotel>();

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

                    list.Add(new Hotel(id, name, address));
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
