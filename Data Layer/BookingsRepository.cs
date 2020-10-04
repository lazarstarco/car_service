using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class BookingsRepository
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarServiceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Bookings> GetAllBookings()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Bookings";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Bookings> listToReturn = new List<Bookings>();

                while (sqlDataReader.Read())
                {
                    Bookings bookings = new Bookings();

                    bookings.MakerId = sqlDataReader.GetInt32(0);
                    bookings.ModelId = sqlDataReader.GetInt32(1);
                    bookings.UserId = sqlDataReader.GetInt32(2);
                    bookings.Date = sqlDataReader.GetString(3);
                    bookings.Defect = sqlDataReader.GetString(4);
                    bookings.Repaired = sqlDataReader.GetInt32(5) == 1 ? true : false;

                    listToReturn.Add(bookings);
                }

                return listToReturn;
            }
        }
        public int InsertBookings(Bookings bookings)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Bookings (MakerId, ModelId, UserId, Date, Defect, Repaired) VALUES(" + string.Format(
                    "{0}, {1}, {2}, '{3}', '{4}', {5}", bookings.MakerId, bookings.ModelId, bookings.UserId, bookings.Date, bookings.Defect,
                    bookings.Repaired ? 1 : 0) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int UpdateBookings(string defect, int repaired, string[] id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Bookings SET Defect = '" + defect +
                    "', Repaired = " + repaired + " WHERE MakerId = " + id[0] + " AND ModelId = " + id[1] + " AND UserId = " + id[2];

                return sqlCommand.ExecuteNonQuery();

            }
        }
        public int DeleteBookings(Bookings bookings)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Bookings WHERE MakerId = " + bookings.MakerId + " AND ModelId = " +
                    bookings.ModelId + " AND UserId = " + bookings.UserId + " AND Date = " + bookings.Date;

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
