using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserMainEntity : BaseEntity
    {
        public string Email { get; set; } = default;
        public string FirstName { get; set; } = default;
        public string PasswordHash { get; set; } = default;
        public string Salt { get; set; } = default;
        public bool PremiumUnlock { get; set; }
        public Guid RecoveryId { get; set; }
        public string RecoveryAns { get; set; } = default;
    }
}
