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

                    if (hostingEnvironment.EnvironmentName == "Development")
                    {
                        if (!context.ApplicationRoles.Any())
                            DataSeeder.InitRoles(context);
                        if (!context.FileExtensions.Any())
                            DataSeeder.InitFileExtensions(context);
                        if (!context.Steps.Any())
                            DataSeeder.InitSteps(context);
                        if (!context.DocumentTypes.Any())
                            DataSeeder.InitDocumentTypes(context);
                        if (!context.Positions.Any())
                            DataSeeder.InitPositions(context);
                        if (!context.FormKinds.Any())
                            DataSeeder.InitFormKinds(context);
                        if (!context.DangerKinds.Any())
                            DataSeeder.InitDangerKinds(context);
                        if (!context.CheckingKinds.Any())
                            DataSeeder.InitCheckingKinds(context);
                    }
                }

                return webHost;
            }
        }
    }

}
