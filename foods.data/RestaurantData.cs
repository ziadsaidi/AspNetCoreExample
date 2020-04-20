using System;
using System.Collections.Generic;
using foods.core;

namespace foods.data
{
    public interface IRestaurantData
    {

    IEnumerable<Restaurant> getAll();

    }
}
