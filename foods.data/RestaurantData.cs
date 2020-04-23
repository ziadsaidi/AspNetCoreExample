using System;
using System.Collections.Generic;
using foods.core;

namespace foods.data
{
    public interface IRestaurantData
    {

    IEnumerable<Restaurant> GetRestaurantsByName(string name);
    Restaurant GetById(int? id);

    Restaurant Update (Restaurant updatedRestaurant);

    Restaurant Create(Restaurant newRestaurant);


    Restaurant Delete(int id);

   //saveChanges()
    int commit();
    int GetRestaurantsCount();

    }
}
