using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using RegWatcher.RegWatcher;

namespace RegWatcher
{
    public class Program
    {
        /*public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();*/

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .Migrate()
                .SeedingData()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
