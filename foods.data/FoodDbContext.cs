using foods.core;
using Microsoft.EntityFrameworkCore;

namespace foods.data
{
    public class FoodDbContext:DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options):base(options)
        {
            
        }
     public DbSet<Restaurant> Restaurants { get; set; }

    }
}