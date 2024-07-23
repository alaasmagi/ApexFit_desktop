using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepComponent
{
    public class CSleep:ISleep
    {
        private CoreComponent.ICore Core;
        private SecurityLayer.ISecurity Security;
        private string connectionString;

        public bool AddSleepToHistory(int userId, int date, int totalSleep, int remSleep, int deepSleep, int lightSleep, int awakeTime)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO user_sleep_history (user_id, date, total_sleep, rem_sleep, deep_sleep, light_sleep, awake_time) VALUES (@userId, @date, @totalSleep, @remSleep, @deepSleep, @lightSleep, @awakeTime)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@totalSleep", totalSleep);
                command.Parameters.AddWithValue("@remSleep", remSleep);
                command.Parameters.AddWithValue("@deepSleep", deepSleep);
                command.Parameters.AddWithValue("@lightSleep", lightSleep);
                command.Parameters.AddWithValue("@awakeTime", awakeTime);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public int[] GetSleepHistoryData(int userId, int date, string columnName)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            List<int> sleepHistory = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT {columnName} FROM user_sleep_history WHERE user_id = @userId AND date = @date";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@date", date);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                sleepHistory.Add(reader.GetInt16(i));
                            }
                        }
                    }
                }
            }

            return sleepHistory.ToArray();
        }
    }
}
