using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TrainingsComponent
{
    public class CTrainings:ITrainings
    {
        private CoreComponent.ICore Core;
        private SecurityLayer.ISecurity Security;
        private string connectionString;

        public int GenerateTrainingId()
        {
            Random random = new Random();

            int trainingIdOutput = random.Next(1000, 99999);
            return trainingIdOutput;
        }

        public bool AddTraining(string trainingName, int energyConsumption)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            int trainingId = GenerateTrainingId();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO training_data (training_id, training_name, consumption) VALUES (@trainingId, @trainingName, @energyConsumption)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainingId", trainingId);
                command.Parameters.AddWithValue("@trainingName", trainingName);
                command.Parameters.AddWithValue("@energyConsumption", energyConsumption);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public int TrainingNameExists(string trainingName)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();
            int trainingIdOutput = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT training_id FROM training_data WHERE training_name = @trainingName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainingName", trainingName);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    int.TryParse(result.ToString(), out trainingIdOutput);
                }
                return trainingIdOutput;
            }
        }

        public List<string> GetTrainingNames()
        {
            List<string> trainingNames = new List<string>();

            CoreComponent.ICore Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT training_name FROM training_data";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string trainingName = reader["training_name"].ToString();
                    trainingNames.Add(trainingName);
                }
                reader.Close();
            }
            return trainingNames;
        }

        public Object GetTrainingData(int trainingId, string columnName)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString(); ;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT {columnName} FROM training_data WHERE training_id = @trainingId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainingId", trainingId);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result == null)
                {
                    return null;
                }
                return result;
            }
        }

        public int[] GetTrainingHistoryData(int userId, int date, string columnName)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            List<int> trainingHistory = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT {columnName} FROM user_training_history WHERE user_id = @userId AND date = @date";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@date", date);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                trainingHistory.Add(reader.GetInt16(i));
                            }
                        }
                    }
                }
            }

            return trainingHistory.ToArray(); 
        }

        public bool AddTrainingToHistory(int userId, int date, int trainingId, int duration)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            int energyConsumption = (int)Math.Round((double)duration * ((double)GetTrainingData(trainingId, "consumption") / 60));
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO user_training_history (user_id, date, training_id, total_consumption, duration) VALUES (@userId, @date, @trainingId, @totalConsumption, @duration)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@trainingId", trainingId);
                command.Parameters.AddWithValue("@totalConsumption", energyConsumption);
                command.Parameters.AddWithValue("@duration", duration);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }
        
        public bool DeleteTraining(int trainingId)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"DELETE FROM user_training_history WHERE training_id = @trainingId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainingId", trainingId);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
