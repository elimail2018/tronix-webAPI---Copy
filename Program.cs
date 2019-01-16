using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using unitronicsWebApi.Model;

namespace unitronicsWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {


            using (var context = new UnitronicsContext())

            {
                LocalDB.CreateDatabase("testMDF", "C:\\Develop\\WORK-PROJECTS\\UNITRONICS\\WEBAPI\\tronix-webAPI\\MDF\\mdftest.mdf");
            }

     


            var host = CreateWebHostBuilder(args).Build();
            //using (var scope = host.Services.CreateScope())
            //{
            //    var db = scope.ServiceProvider.GetService<UnitronicsContext>();
            //    db.Database.EnsureCreated();
            //}

            host.Run();

          

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();



    }
}
