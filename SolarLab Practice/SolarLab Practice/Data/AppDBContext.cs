using Microsoft.EntityFrameworkCore;
using SolarLab_Practice.Models;

namespace SolarLab_Practice {
    public class AppDBContext : DbContext {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Person> Person { get; set; }
    }
}
