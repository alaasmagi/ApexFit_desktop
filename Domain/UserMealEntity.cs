using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserMealEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public EMealType MealType { get; set; }
        public DateTime Date {  get; set; }
        public Guid? FoodId { get; set; }
        public Guid? RecipeId { get; set; }
        public int Amount { get; set; }
        public int EnergyIntake { get; set; }
        public int TotalCHydrates { get; set; }
        public int TotalSugars { get; set; }
        public int TotalProteins { get; set; }
        public int TotalLipids { get; set; }
    }
}
