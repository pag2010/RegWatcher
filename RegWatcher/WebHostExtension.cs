using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher
{
    using global::RegWatcher.Data;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace RegWatcher
    {
        public static class WebHostExtension
        {
            public static IWebHost Migrate(this IWebHost webHost)
            {
                using (var serviceScope = webHost.Services.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<DataContext>();
                    try
                    {
                        context.Database.Migrate();
                    }
                    catch
                    {

                    }
                }

                return webHost;
            }

            public static IWebHost SeedingData(this IWebHost webHost)
            {
                using (var serviceScope = webHost.Services.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<DataContext>();
                    var hostingEnvironment = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();

                    if (hostingEnvironment.EnvironmentName == "Development" && !context.ApplicationRoles.Any())
                    {
                        DataSeeder.InitData(context);
                    }
                }

                return webHost;
            }
        }
    }

}
