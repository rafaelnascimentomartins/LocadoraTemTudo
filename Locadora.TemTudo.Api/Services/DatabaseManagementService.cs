using Locadora.TemTudo.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Locadora.TemTudo.Api.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider.GetService<LocadoraContext>();

                serviceDb.Database.Migrate();
            }
        }
    }
}
