using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
    #pragma warning disable CS1591 //Ignore warnings for specific members
    public class TravelContext : IdentityDbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {

        }
        public DbSet<Review> Reviews { get; set; }
    }
    #pragma warning restore CS1591 //Ignore warnings for specific members
}