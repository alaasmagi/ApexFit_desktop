using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecoveryQuestionEntity : BaseEntity
    {
        [MaxLength(256)]
        public string Question { get; set; } = string.Empty;
    }
}
