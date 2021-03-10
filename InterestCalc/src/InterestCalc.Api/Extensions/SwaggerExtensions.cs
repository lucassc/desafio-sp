using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace InterestCalc.Api.Extensions
{
    public static class SwaggerExtensions
    {
        private const string API_NAME = "Calculo de Juros Api";

        public static IServiceCollection AddSwaggerGen(this IServiceCollection services) =>
            services.AddSwaggerGen(SwaggerOptions);

        public static IApplicationBuilder UseSwaggerGen(this IApplicationBuilder app) =>
            app.UseSwagger().UseSwaggerUI(SwaggerUiConfig());

        private static readonly Action<SwaggerGenOptions> SwaggerOptions = options =>
            options.SwaggerDoc("v1", SwaggerInfo);

        private static readonly OpenApiInfo SwaggerInfo = new OpenApiInfo
        {
            Title = API_NAME,
            Version = "v1",
            Description = API_NAME,
        };

        private static Action<SwaggerUIOptions> SwaggerUiConfig() =>
            c => c.SwaggerEndpoint("/swagger/v1/swagger.json", API_NAME);
    }
}