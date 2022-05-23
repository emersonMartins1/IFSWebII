using Microsoft.EntityFrameworkCore;
using IFSWebII.Model;

namespace IFSWebII.Data
{
    public class IFSDbContext : DbContext
    {
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Prerequisito> Prerequisitos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=IFSWebII;Trusted_Connection=True;User Id=emersonmd;Password=dkvh2o22;");
        }
    }
}
