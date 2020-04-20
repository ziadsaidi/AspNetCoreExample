using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foods.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using foods.core;

namespace foods.Pages
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData data;

        public ListModel(IConfiguration config ,IRestaurantData data)
        {
            this.config = config;
            this.data = data;

        }
        public string Message { get; set; }
        public IEnumerable<Restaurant>  Restaurants;
        

   
        public void OnGet()
        {

        
          

           Message = config["Message"];
           Restaurants = this.data.getAll();

        }
    }
}