using Microsoft.EntityFrameworkCore;

namespace CodeTaskSeb.Models
{
    public class CodeTaskSebContext : DbContext
    {
        public CodeTaskSebContext(DbContextOptions<CodeTaskSebContext> options)
            : base(options)
        {                
        }

        public DbSet<CustomerContact> Contacts { get; set; } = null!;
    }
}
