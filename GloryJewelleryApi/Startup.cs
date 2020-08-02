using GloryJewelleryApi.Models;
using GloryJewelleryApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace GloryJewelleryApi
{
    public class Startup
    {
        readonly string _myAllowSpecificOrigins = "_myAllowSpecificOrigins";

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
                options.AddPolicy(_myAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins(
                        "http://localhost:3000",
                        "https://localhost:3000",
                        "http://localhost:8000",
                        "http://localhost:8080",
                        "https://localhost:8000",
                        "https://localhost:8080", "https://haberibul.com",
                        "http://gloryjewelleryy.com",
                        "https://www.gloryjewelleryy.com",
                        "http://www.gloryjewelleryy.com",
                        "http://m.gloryjewelleryy.com",
                        "https://m.gloryjewelleryy.com",
                        "http://gloryjewelleryy:8000",

                        "https://gloryjewellerys.web.app",

                        "https://gloryjewellerys.firebaseapp.com"
                    )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.Configure<JewelleryDatabaseSettings>(Configuration.GetSection(nameof(JewelleryDatabaseSettings)));

            services.AddSingleton<IJewelleryDatabaseSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<JewelleryDatabaseSettings>>().Value);

            services.AddControllers();
            services.AddScoped<IJewelleryService, JewelleryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
