using Entitites.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrascture.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) {}

        public DbSet<Message> Messages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ObterStringConexao(), ServerVersion.Parse("8.0.28"));
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUser").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Server=localhost;initial catalog=DB_API_DDD;uid=root;pwd=System256715;Connect Timeout=15";
            //return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=API_DDD_2022;Integrated Security=False;User ID=sa;Password=System256715;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        }
    }
}
