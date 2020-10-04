using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class MakerRepository
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarServiceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Maker> GetAllMakers()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Makers";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Maker> listToReturn = new List<Maker>();

                while (sqlDataReader.Read())
                {
                    Maker maker = new Maker();

                    maker.Id = sqlDataReader.GetInt32(0);
                    maker.Name = sqlDataReader.GetString(1);
                    maker.City = sqlDataReader.GetString(2);
                    maker.Country = sqlDataReader.GetString(3);
                    maker.Email = sqlDataReader.GetString(4);

                    listToReturn.Add(maker);
                }

                return listToReturn;
            }
        }
        public int InsertMaker(Maker maker)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Makers (Name, City, Country, Email) VALUES(" + string.Format(
                    "'{0}', '{1}', '{2}', '{3}'", maker.Name, maker.City, maker.Country, maker.Email) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int DeleteMaker(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Makers WHERE Id = " + id;

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
