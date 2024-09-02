using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodsOrRecipesComponent
{
    public interface IFoodsOrRecipes
    {
        bool AddFood(string foodName, int energy, int c_hydrates, int sugars, int proteins, int lipids);
        bool AddRecipe(string recipeName, int energy, int c_hydrates, int sugars, int proteins, int lipids);
    }
}
