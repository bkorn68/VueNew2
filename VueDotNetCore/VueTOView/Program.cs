using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceReference1;
using ServiceReference2;
using VueTOView.Common;
using VueTOView.Converters;
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
            VueTOView.Common.Environment environment = Common.Environment.Live;
            int mandatorId = 1;
            ServiceReference1.Ident ident1 = LoginTest.TestLogin(loginname, password, environment);
            if(ident1 != null)
            {
                ServiceReference2.Ident ident2 = IdentConverter.ConvertFromReference1To2(ident1);
                if((ident2.MandatorIds != null) && (ident2.MandatorIds.Length > 0))
                {
                    mandatorId = ident2.MandatorIds[0];
                }
                List<Technician> tourtechnicians =GetTechniciansTest.TestGetTourTechnicians(ident2, mandatorId, environment);
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
