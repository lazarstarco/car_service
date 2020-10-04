using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ModelRepository
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarServiceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Model> GetAllModels()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Models";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Model> listToReturn = new List<Model>();

                while (sqlDataReader.Read())
                {
                    Model model = new Model();

                    model.Id = sqlDataReader.GetInt32(0);
                    model.Name = sqlDataReader.GetString(1);
       
                    listToReturn.Add(model);
                }

                return listToReturn;
            }
        }
        public int InsertModel(Model model)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Models (Name) VALUES('" + model.Name + "')";

                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int DeleteModel(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Models WHERE Id = " + id;

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
