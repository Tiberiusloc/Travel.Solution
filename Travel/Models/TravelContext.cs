using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Review>()
              .HasData(
                  new Review { ReviewId = 1, Name = "Shaniza", City = "Portland", Country = "United States", Rating = 1, Description = "Fentanyl Capital" },
                  new Review { ReviewId = 2, Name = "Tiberius", City = "Houston", Country = "United States", Rating = 2, Description = "Yee haw"}
              );
        }
        public DbSet<Review> Reviews { get; set; }
    }
}