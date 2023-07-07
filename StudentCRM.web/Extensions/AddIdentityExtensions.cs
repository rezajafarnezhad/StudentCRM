using Microsoft.AspNetCore.Identity;
using StudentCRM.Data.ApplicationDataBaseContext;

namespace StudentCRM.web.Extensions;

public static class AddIdentityExtensions
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>(opt =>
        {
            opt.Password.RequireDigit= true;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequiredLength = 6;
            opt.Password.RequireNonAlphanumeric = false;

        })
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddRoleValidator<RoleValidator<IdentityRole>>()
            .AddSignInManager<SignInManager<IdentityUser>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()

            ;
           
        return services;
    }
}


