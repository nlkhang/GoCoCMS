using Microsoft.AspNetCore.Identity;

namespace GoCoCMS.Data.Domain.Identity
{
    public class UserRole : IdentityUserRole<long>
    {
        public long Id { get; set; }
        public override long UserId { get; set; }
        public virtual User User { get; set; }
        public override long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
