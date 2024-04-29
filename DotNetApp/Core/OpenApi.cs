using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace DotNetApp.Core;

public static class OpenApi
{
    public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "DotNetApp API",
                Version = "v1",
                Description = "A sample API to demonstrate API documentation",
                TermsOfService = new Uri("https://khodecamp.com"),
                Contact = new OpenApiContact
                {
                    Name = "Thorn Developer",
                    Email = "thorn.developer@khodecamp.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });

            options.EnableAnnotations();
            options.AddServer(new OpenApiServer { Url = "http://localhost:5002", Description = "Localhost" });

            // Define the BearerAuth scheme
            options.AddSecurityDefinition("AccessToken", new OpenApiSecurityScheme
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer" // must be lowercase
            });

            options.AddSecurityDefinition("RefreshToken", new OpenApiSecurityScheme
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer" // must be lowercase
            });

            // Add the security requirements
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "AccessToken"
                        }
                    },
                    new string[] { }
                },
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "RefreshToken"
                        }
                    },
                    new string[] { }
                }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerAndRedocUi(this IApplicationBuilder app)
    {
        app.UseSwagger();

        // Swagger UI configuration
        app.UseSwaggerUI(options =>
        {
            options.EnableFilter();
            options.EnableValidator();
            options.DisplayRequestDuration();
            options.DefaultModelRendering(ModelRendering.Example);
            options.EnablePersistAuthorization();
        });

        // ReDoc configuration
        app.UseReDoc(options =>
        {
            options.RoutePrefix = "redoc";
            options.SpecUrl = "/swagger/v1/swagger.json";
            options.DocumentTitle = "ReDoc";
            options.EnableUntrustedSpec();
            options.ScrollYOffset(10);
            options.ExpandResponses("200,201");
            options.HideDownloadButton();
            options.HideHostname();
        });
        return app;
    }
}