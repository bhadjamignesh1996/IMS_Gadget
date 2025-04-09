using Microsoft.OpenApi.Models;

namespace IMS_Gadget.Extensions
{
    public static class Swagger
    {

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMSGadget", Version = "v1" });

                c.AddSecurityDefinition("TOKEN_NO", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "TOKEN_NO",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "basic"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                            new OpenApiSecurityScheme{
                                Reference = new OpenApiReference {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "TOKEN_NO"
                                }
                            }, new List<string>()
                    }
                });
            });

            return services;
        }
    }
}
