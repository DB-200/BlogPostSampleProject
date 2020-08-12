using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Books.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
                            .ConfigureNLog("nlog.config")
                            .GetCurrentClassLogger();

            try
            {
                logger.Info("Initializing application...");
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope()) // run against current service scope
                {
                    // database migration via code bootstrap
                    try
                    {
                        var context = scope.ServiceProvider.GetService<BookInfoContext>();

                        // For demo purposes, start with a clean database each time
                        context.Database.EnsureDeleted();
                        context.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "Exception occurred whilst migrating the database.");
                    }
                };

                logger.Info("Running host...");
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception occurred during initialization.");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseNLog();
                });
                  
    }
}
