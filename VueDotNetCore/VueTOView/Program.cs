namespace VueTOView
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public static class Program
    {
        public static void Main(string[] args)
        {
            // Test();
            CreateHostBuilder(args).Build().Run();
        }

        // public static void Test()
        // {
        //    ////TODO Insert your credentials for testing
        //    string loginname = "";
        //    string password = "";
        //    VueTOView.Common.Environment environment = Common.Environment.Live;
        //    int mandatorId = 1;
        //    ServiceReference1.Ident ident1 = LoginTest.TestLogin(loginname, password, environment);
        //    if(ident1 != null)
        //    {
        //        ServiceReference2.Ident ident2 = IdentConverter.ConvertFromReference1To2(ident1);
        //        if((ident2.MandatorIds != null) && (ident2.MandatorIds.Length > 0))
        //        {
        //            mandatorId = ident2.MandatorIds[0];
        //        }
        //        List<Technician> tourtechnicians =GetTechniciansTest.TestGetTourTechnicians(ident2, mandatorId, environment);
        //        Technician technician = tourtechnicians.Where(e => (e.Name.StartsWith("Stephan Nitsch"))).FirstOrDefault();
        //        if(technician != null)
        //        {
        //            ID technicianID = technician.ID;
        //            DateTime date = Convert.ToDateTime("01/10/2020");
        //            List<TechnicianRequirement> tours = GetToursTest.TestGetTourOfTechnician(ident2, mandatorId, technicianID, date, environment);
        //        }

        // }

        // }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
