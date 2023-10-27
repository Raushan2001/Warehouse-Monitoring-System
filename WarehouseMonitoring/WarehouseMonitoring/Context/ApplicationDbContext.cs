using Microsoft.EntityFrameworkCore;
using WarehouseMonitoring.Models;

namespace WarehouseMonitoring.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Harvest> Harvests { get; set; }
        public DbSet<CroupType> CroupTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomDetail> RoomDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Harvest>().ToTable("Harvests");
            modelBuilder.Entity<CroupType>().ToTable("CroupTypes");
            modelBuilder.Entity<Room>().ToTable("Rooms");
            modelBuilder.Entity<RoomDetail>().ToTable("RoomDetails");
        }
    }
}
