using InterestCalc.Api.Extensions;
using InterestCalc.Api.Filters;
using InterestCalc.Api.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InterestCalc.Api
{
    public class Startup
    {
        public readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) =>
            _configuration = configuration;

        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddDomainDependencies()
                .AddInfrastructureDependencies(_configuration)
                .AddSwaggerGen()
                .AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)));

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerGen()
               .UseRouting()
               .UseAuthorization()
               .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}