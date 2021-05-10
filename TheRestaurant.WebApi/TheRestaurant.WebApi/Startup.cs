using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TheRestaurant.Application.Interfaces.Services;
using TheRestaurant.Application.Services;
using TheRestaurant.Domain.Interfaces.Repository;
using TheRestaurant.Infra.Configuration;
using TheRestaurant.Infra.Repositories;

namespace TheRestaurant.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IRestaurantRepository, MySQLRestaurantRepository>();
            services.AddScoped<IProfessionalRepository, MockProfessionalRepository>();

            var connectionString = Configuration.GetValue<string>("MySQLConnectionString");

            services.AddSingleton(new MySQLConfiguration { ConnectionString = connectionString });

            services.AddCors(options => {
                options.AddPolicy("mypolicy", builder => builder
                 .WithOrigins("http://localhost:4200")
                 .SetIsOriginAllowed((host) => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(p => p.Build());
            app.UseMvc();
        }
    }
}
