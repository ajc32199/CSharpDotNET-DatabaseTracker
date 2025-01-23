using Microsoft.EntityFrameworkCore;

namespace MemberModule.Models
{
    public class MembersDBContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public MembersDBContext(DbContextOptions<MembersDBContext> options)
            : base(options)
        {
             
        }
    }
}
