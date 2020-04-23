using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foods.core;
using foods.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace foods.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;

        }
        public IActionResult OnGet(int id)
        {
            Restaurant = restaurantData.GetById(id);

            if(Restaurant == null){
                RedirectToPage("/NotFound");
            }
            return Page();



        }


        public IActionResult OnPost(int id)
        {
            var restaurant = restaurantData.Delete(id);
            restaurantData.commit();

            if(restaurant == null){
                RedirectToPage("./NotFound");
            }
            TempData["Message"] = $" {restaurant.Name} Deleted !";
            return RedirectToPage("./List");

        }
    }
}