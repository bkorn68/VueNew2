using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceReference1;
using VueTOView.Common;
using VueTOView.Tests;

namespace VueTOView
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test();

            CreateHostBuilder(args).Build().Run();
        }
        public static void Test()
        {
            ////TODO Insert your credentials for testing
            string loginname = "";
            string password = "";
            Ident ident = LoginTest.TestLogin(loginname, password);

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
