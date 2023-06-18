using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Config
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {

        public DbSet<FinancialSystem> FinancialSystems { get; set; }
        public DbSet<UserFinancialSystem> UserFinancialSystems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public ContextBase( DbContextOptions options ) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            //return "Data Source=NBQSP-FC693;Initial Catalog=FINANCEIRO;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            return "Data Source=NBQSP-FC693;Initial Catalog=FINANCEIRO;Integrated Security=True"; // Evitar
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
