using Microsoft.EntityFrameworkCore;

namespace Deploy.Cachorro.Repository
{
    public class CachorroContext : DbContext
    {
        public CachorroContext(DbContextOptions<CachorroContext> options) : base(options)
        {
            
        }

        public DbSet<Domain.Cachorro> Cachorros { get; set; }
        public DbSet<Domain.Tutor> Tutores { get; set; }
    }
}
