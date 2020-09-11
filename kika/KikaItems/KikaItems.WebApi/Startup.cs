using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KikaItems.BusinessLogic;
using KikaItems.BusinessLogic.Repositories;
using KikaItems.BusinessLogic.Services;
using KikaItems.Contracts;
using KikaItems.Contracts.Interfaces.Repositories;
using KikaItems.Contracts.Interfaces.Services;
using KikaItems.Contracts.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kika.WebApi
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
            services.AddCors();
            services.AddControllers();

            //read appsettings.json file
            Configurations.ReadAppSettingFile();

            services
                .AddScoped<IItemRepository, ItemRepository>()
                .AddScoped<IPriceRepository, PriceRepository>()

                .AddScoped<IItemService, ItemService>()
                .AddScoped<IPriceService, PriceService>()
                
                .AddScoped<KikaDatabaseContext>();

            services.AddDbContext<KikaDatabaseContext>(options =>
                    options.UseSqlServer(Settings.ConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
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
