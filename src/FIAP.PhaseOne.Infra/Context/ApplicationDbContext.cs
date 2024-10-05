using Microsoft.EntityFrameworkCore;

namespace FIAP.PhaseOne.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
              
        }
    }
}
