using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using foods.data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace foods
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var host =   CreateWebHostBuilder(args).Build();
          /// create DB migrations 
          MigrateDatabase(host);
          host.Run();
        }

        private static void MigrateDatabase(IWebHost host)
        {

            using(var scope = host.Services.CreateScope())
            {

                //with sqlserver 
                // create Logins()
                //ApplicationPool have its Identity 
                //IIS AppPoll + windows Auth
                //Role DbCreator 
                var db = scope.ServiceProvider.GetRequiredService<FoodDbContext>();
                db.Database.Migrate();

            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
