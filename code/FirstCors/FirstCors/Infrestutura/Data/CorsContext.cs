using FirstCors.Domain.Model;
using FirstCors.Infrestutura.Data.Map;
using Microsoft.EntityFrameworkCore;

namespace FirstCors.Infrestutura.Data
{
    public class CorsContext : DbContext
    {

        public CorsContext(DbContextOptions<CorsContext> options) : base(options) { }

        public DbSet<EmployeeModel> employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
