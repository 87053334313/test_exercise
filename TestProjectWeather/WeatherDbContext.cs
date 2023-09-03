using Microsoft.EntityFrameworkCore;

namespace TestProjectWeather
{
    public class WeatherDbContext : DbContext
    {

        protected readonly IConfiguration Configuration;
        public WeatherDbContext(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        public DbSet<WeatherForecast> table { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
