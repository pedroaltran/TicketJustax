using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using TicketsAPI.Api.Filters;
using TicketsAPI.Api.Middlewares;
using TicketsAPI.IoC;

namespace TicketsAPI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowCors",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyMethod()
                                             .AllowAnyHeader();
                                  });
            });

            services.AddAuthentication("Bearer")
                  .AddJwtBearer("Bearer", config =>
                  {
                      config.Authority = Configuration.GetSection("UrlIdentityServer").Value;
                      config.Audience = "jtx_private_api";
                      config.RequireHttpsMetadata = false;
                  });

            services.AddAuthorization();

            services.AddInfraestructure();

            services.AddControllers(options =>
            {
                options.Filters.Add(new RequestFilter());
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseCors("AllowCors");

            app.UseHttpsRedirection();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
