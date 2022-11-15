using Locadora.TemTudo.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Locadora.TemTudo.Api.Services
{
    //Responsável por executar todas as migrations criadas no banco de dados sqlserver criado pelo docker-compose.yml
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
