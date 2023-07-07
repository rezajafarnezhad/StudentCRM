using Microsoft.EntityFrameworkCore;
using StudentCRM.Data.ApplicationDataBaseContext;

namespace StudentCRM.web.Extensions;

public static class AddDbContextServiceExtensions
{
    public static IServiceCollection AddDbContextService(this IServiceCollection services, string ConnectionString)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(ConnectionString));
        return services;
    }
}


