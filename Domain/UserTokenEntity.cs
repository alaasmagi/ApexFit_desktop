using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserTokenEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string TokenEnc { get; set; } = default;
    }
}
