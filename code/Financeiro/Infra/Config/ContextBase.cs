using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Config
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {

        public DbSet<FinancialSystem> FinancialSystem { get; set; }
        public DbSet<UserFinancialSystem> UserFinancialSystem { get; set; }
        public DbSet<Category> Categorie { get; set; }
        public DbSet<Expense> Expense { get; set; }

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

            return "Data Source=DESKTOP-VNAK46F\\SQLEXPRESS;Initial Catalog=FINANCEIRO;Integrated Security=True;TrustServerCertificate=True"; // Evitar

            //return "Server=localhost;initial catalog=FINANCEIRO;uid=root;pwd=System256715;Connect Timeout=15";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
            /* if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ObterStringConexao(), ServerVersion.Parse("8.0.28"));
                base.OnConfiguring(optionsBuilder);
            }*/
        }
    }
}
