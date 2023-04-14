using Microsoft.EntityFrameworkCore;

namespace TechBlogAPI.DAL
{
    public class ContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // connection string tanimlamak icin bole bir yapi kurduk 
        {
            optionsBuilder.UseSqlServer("server=HOME-PC\\MSSQLSERVER01; Connect Timeout = 30 ; database=CoreBlogAPIDb; integrated security=true; TrustServerCertificate=True; ");//Bu fonksiyon icin entitiyframework.core.sqlserver yuklenmesi gereklidir. 
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
