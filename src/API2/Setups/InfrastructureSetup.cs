using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API2.Application.Common.Interfaces;
using API2.Infrastructure.Identity;
using API2.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API2.Setups
{
    public static class InfrastructureSetup
    {
        public static IServiceCollection AddInfrastructureSetup(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("StudentsDbConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddTransient<IIdentityService, IdentityService>();
            //services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
