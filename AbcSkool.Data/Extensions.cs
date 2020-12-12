using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Data
{
    public static class Extensions
    {
        /// <summary>
        /// Updates the database schema to the latest migation
        /// </summary>
        /// <param name="app"></param>
        public static void RunMigrations(this IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService(typeof(AbcSkoolDbContext)) as AbcSkoolDbContext;
                context.Database.Migrate();
            }

        }

        public static void SeedDatabase(this IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService(typeof(AbcSkoolDbContext)) as AbcSkoolDbContext;
                //context.Database.Migrate();
            }

        }
    }
}
