using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecipeEntity : BaseEntity
    {
        [MaxLength(128)]
        public string Name { get; set; } = string.Empty;
        public int Energy { get; set; }
        public int CHydrates { get; set; }
        public int Sugars { get; set; }
        public int Proteins { get; set; }
        public int Lipids { get; set; }
    }
}
