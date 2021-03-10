using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace InterestCalc.Api
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .ConfigureServices((hostContect, _) =>
                    {
                        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(hostContect.Configuration["Culture"]);
                        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture(hostContect.Configuration["Culture"]);
                    });
    }
}