using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foods.core;
using foods.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace foods.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Restaurant = restaurantData.GetById(id);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();

        }


        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
             Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
              return Page();
            }

            if(Restaurant.Id > 0)
            {
               Restaurant = restaurantData.Update(Restaurant);
            }
            else{
                 Restaurant = restaurantData.Create(Restaurant);
            }
               
                restaurantData.commit();
                //pagePath , routesValues
                TempData["Message"] = "Restaurant Saved!";
                return RedirectToPage("./Detail", new { id = Restaurant.Id });

            }
           
    }






}