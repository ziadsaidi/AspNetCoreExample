using System.Collections.Generic;
using foods.core;
using System.Linq;

namespace foods.data
{
    public class InMemoryRestaurant : IRestaurantData
    {


     private readonly List<Restaurant> _restaurants;
        public InMemoryRestaurant  ()
        {
            this._restaurants = new  List<Restaurant>(){
                new Restaurant{Id=1,Name="name1",Location="Tunis",Cuisine = CuisineType.Indian},
                new Restaurant{Id=2,Name="name2",Location="Nabeul",Cuisine = CuisineType.Italian},
                new Restaurant{Id=3,Name="name4",Location="Monastir",Cuisine = CuisineType.Mexican},
                new Restaurant{Id=4,Name="name7",Location="Paris",Cuisine = CuisineType.Italian}
            };
            
        }

        public int commit()
        {
           return 0;
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
           _restaurants.Add(newRestaurant);
           newRestaurant.Id = _restaurants.Max(r => r.Id)+1;
           return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
           var restaurant = _restaurants.FirstOrDefault(r => r.Id ==id) ;
           if(restaurant != null){
               _restaurants.Remove(restaurant);
           }

           return restaurant;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public Restaurant GetById(int? id)
        {
            return _restaurants.SingleOrDefault(r=>r.Id == id );
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name =null)
        {
            return from r in this._restaurants
            where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                  orderby r.Name
                  select r;
            
        }

        public int GetRestaurantsCount()
        {
             return this._restaurants.Count;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
           var  restaurant = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
           if(restaurant != null){
               restaurant.Name = updatedRestaurant.Name;
               restaurant.Location =updatedRestaurant.Location;
               restaurant.Cuisine = updatedRestaurant.Cuisine;
           }

           return restaurant;
        }
    }
}
