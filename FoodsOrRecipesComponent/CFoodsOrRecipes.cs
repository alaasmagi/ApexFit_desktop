using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodsOrRecipesComponent
{
    public class CFoodsOrRecipes:IFoodsOrRecipes
    {
        private CoreComponent.ICore Core;
        string connectionString;
        public bool AddFood(string trainingName, int energyConsumption)
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
    }
}
