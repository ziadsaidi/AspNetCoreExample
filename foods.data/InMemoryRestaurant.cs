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
        public IEnumerable<Restaurant> getAll()
        {
            return from r in this._restaurants
                  orderby r.Name
                  select r;
            
        }
    }
}
