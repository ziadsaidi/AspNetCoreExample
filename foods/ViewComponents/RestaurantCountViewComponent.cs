using foods.data;
using Microsoft.AspNetCore.Mvc;

namespace foods.ViewComponents
{
    public class RestaurantCountViewComponent:ViewComponent
    {
        private IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {

            this.restaurantData = restaurantData;
            
        }
        

        public IViewComponentResult Invoke(){

            var  count = restaurantData.GetRestaurantsCount();

            return View(count);

        }
}
}