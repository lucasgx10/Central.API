using Central.Models;
using Microsoft.EntityFrameworkCore;

namespace Central.Data
{
    public class AppDataContext: DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseNpgsql("Server=129.148.38.17;Port=5432;Database=Central;User Id=postgres;Password=docker;");
    }
}
