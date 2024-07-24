using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodsOrRecipesComponent
{
    public interface IFoodsOrRecipes
    {
        bool AddFood(string trainingName, int energyConsumption);
    }
}
