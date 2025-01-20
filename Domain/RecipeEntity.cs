using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecipeEntity : BaseEntity
    {
        public string Name { get; set; } = default;
        public int Energy { get; set; }
        public int CHydrates { get; set; }
        public int Sugars { get; set; }
        public int Proteins { get; set; }
        public int Lipids { get; set; }
    }
}
