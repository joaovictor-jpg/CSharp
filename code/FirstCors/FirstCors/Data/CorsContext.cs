using FirstCors.Data.Map;
using FirstCors.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FirstCors.Data
{
    public class CorsContext : DbContext
    {

        public CorsContext(DbContextOptions<CorsContext> options) : base(options) {}

        public DbSet<EmployeeModel> employee {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
