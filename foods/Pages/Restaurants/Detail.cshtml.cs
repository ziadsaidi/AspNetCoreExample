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
    public class DetailModel : PageModel
    {
        private IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }


        [TempData]
        public string  Message { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int id)
        {

            Restaurant = restaurantData.GetById(id);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}