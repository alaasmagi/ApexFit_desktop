﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodsOrRecipesComponent
{
   /* public class CFoodsOrRecipes:IFoodsOrRecipes
    {
        private CoreComponent.ICore Core;
        string connectionString;
        public bool AddFood(string trainingName, int energyConsumption)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            int trainingId = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO training_data (training_id, training_name, consumption) VALUES (@trainingId, @trainingName, @energyConsumption)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainingId", trainingId);
                command.Parameters.AddWithValue("@trainingName", trainingName);
                command.Parameters.AddWithValue("@energyConsumption", energyConsumption);
                command.Parameters.AddWithValue("@foodId", foodId);
                command.Parameters.AddWithValue("@foodName", foodName);
                command.Parameters.AddWithValue("@energy", energy);
                command.Parameters.AddWithValue("@c_hydrates", c_hydrates);
                command.Parameters.AddWithValue("@sugars", sugars);
                command.Parameters.AddWithValue("@proteins", proteins);
                command.Parameters.AddWithValue("@lipids", lipids);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool AddRecipe(string recipeName, int energy, int c_hydrates, int sugars, int proteins, int lipids)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            int recipeId = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO recipe_data (recipe_id, recipe_name, energy, c_hydrates, sugars, proteins, lipids) VALUES (@recipeId, @recipeName, @energy, @c_hydrates, @sugars, @proteins, @lipids)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@recipeId", recipeId);
                command.Parameters.AddWithValue("@recipeName", recipeName);
                command.Parameters.AddWithValue("@energy", energy);
                command.Parameters.AddWithValue("@c_hydrates", c_hydrates);
                command.Parameters.AddWithValue("@sugars", sugars);
                command.Parameters.AddWithValue("@proteins", proteins);
                command.Parameters.AddWithValue("@lipids", lipids);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }*/
}
