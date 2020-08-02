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
        readonly string MyAllowSpecificOrigins = "MyAllowSpecificOrigins";

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
                options.AddPolicy(MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins(
                        "http://localhost:3000",
                        "http://localhost:3000/editor/new",
                        "https://localhost:3000",
                        "http://localhost:8000",
                        "http://localhost:8080",
                        "https://localhost:8000",
                        "https://localhost:8080",
                        "http://localhost:5000",
                        "http://localhost:5001",
                        "https://localhost:5000",
                        "https://localhost:5001",
                        "https://gloryjewelleryy.com",
                        "http://gloryjewelleryy.com",
                        "https://m.gloryjewelleryy.com",
                        "http://m.gloryjewelleryy.com",
                        "https://e-ticaret-git-master.bkalafat.vercel.app",
                        "https://e-ticaret.vercel.app",
                        "https://e-ticaret.bkalafat.vercel.app",
                        "https://gloryjewellerys.com",
                        "http://gloryjewellerys.com",
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

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
