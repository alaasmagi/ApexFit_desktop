using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserMainEntity : BaseEntity
    {
        [MaxLength(256)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(128)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(256)]
        public string PasswordHash { get; set; } = string.Empty;
        [MaxLength(256)]
        public string Salt { get; set; } = default;
        public bool PremiumUnlock { get; set; }
        public Guid RecoveryId { get; set; }
        public string RecoveryAns { get; set; } = default;
    }
}
