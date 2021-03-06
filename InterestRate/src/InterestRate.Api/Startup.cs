using InterestRate.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InterestRate.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddSwaggerGen()
                .AddControllers();

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