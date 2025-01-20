using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecipeIngredientEntity : BaseEntity
    {
        public Guid RecipeId { get; set; }
        public Guid FoodId { get; set; }
        public int Amount { get; set; }
    }
}
