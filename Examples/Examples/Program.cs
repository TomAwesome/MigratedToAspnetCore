using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Examples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((host, configurationBuilder) =>
                {
                    if(host.HostingEnvironment.IsDevelopment())
                    {
                        configurationBuilder.AddUserSecrets(Assembly.GetExecutingAssembly());
                    }
                })
                .ConfigureServices(services =>
                {
                    //services.Scan(scan =>
                    //{
                    //    scan.FromCallingAssembly().AddClasses().AsMatchingInterface().WithTransientLifetime();
                    //});

                    services.AddTransient<IRandomForecastGenerator, RandomForecastGenerator>();
                    services.AddTransient<IRandomForecastGenerator, RandomForecastGenerator>(provider => new RandomForecastGenerator());
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddLog4Net("log4net.config");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
