using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foods.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using foods.core;
using Microsoft.Extensions.Logging;

namespace foods.Pages
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData data;
        private readonly ILogger log;

        public ListModel(IConfiguration config, IRestaurantData data, ILogger<ListModel> log)
        {
            this.config = config;
            this.data = data;
            this.log = log;

        }
       
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants;


        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        public void OnGet()
        {

            log.LogError(config["Message"]);
            Message = config["Message"];
            Restaurants = this.data.GetRestaurantsByName(SearchTerm);

        }
    }
}