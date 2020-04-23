using System.Collections.Generic;
using foods.core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace foods.data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly FoodDbContext db;

        public SqlRestaurantData(FoodDbContext db)
        {
            this.db = db;
        }

        public int commit()
        {
           return db.SaveChanges();
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
           var restaurant = GetById(id);
           if(restaurant != null){
              db.Restaurants.Remove(restaurant);
           }
           return restaurant;
        }

        public Restaurant GetById(int? id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
           var query = from r in db.Restaurants
           where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
           orderby r.Name
           select r;

           return query;
        }

        public int GetRestaurantsCount()
        {
            return db.Restaurants.Count();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
           var entity = db.Restaurants.Attach(updatedRestaurant);
           entity.State = EntityState.Modified;
           return  updatedRestaurant;
        }
    }
}