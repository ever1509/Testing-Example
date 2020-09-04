using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API2.Setups
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            var contact = new OpenApiContact()
            {
                Name = "Demo API",
                Email = "test@test.com"
            };

            var license = new OpenApiLicense()
            {
                Name = "Demo API",
                Url = new Uri("https://demoapi.com")
            };

            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = "Demo API",
                Description = "Demo API",
                TermsOfService = new Uri("https://demoapi.com"),
                Contact = contact,
                License = license
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("DemoAPI", info);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                //Adding configuration of jwt for swagger UI ----------------------------------

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }},
                        new List<string>()
                    }
                });
                //----------------------------------------

            });

            return services;
        }
    }
}
