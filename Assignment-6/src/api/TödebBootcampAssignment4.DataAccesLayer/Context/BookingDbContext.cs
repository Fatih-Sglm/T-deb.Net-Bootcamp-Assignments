using Microsoft.EntityFrameworkCore;
using TödebBootcampAssignment4.EntityLayer.Entities;

namespace TödebBootcampAssignment4.DataAccesLayer.Context
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Room_Type> Room_Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=DESKTOP-J7GFEGO\\SQLEXPRESS;Database=TödebDb;Trusted_Connection=True;"));
        }

    }
}
