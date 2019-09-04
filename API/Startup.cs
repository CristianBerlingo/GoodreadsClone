using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using GoodreadsCloneAPI.Models;
using GoodreadsCloneAPI.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNet.OData.Extensions;
using GoodreadsCloneAPI.Persistence;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace GoodreadsCloneAPI
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

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<GoodreadsCloneContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );

            // Register the service and implementation for the database context
            services.AddScoped<IGoodreadsCloneContext>(provider => provider.GetService<GoodreadsCloneContext>());

            services.AddScoped<IBaseService<Book>, BookService>();
            services.AddScoped<IBaseService<Bookshelf>, BookshelfService>();
            services.AddScoped<IBaseService<User>, UserService>();
            services.AddScoped<IBaseService<Review>, ReviewService>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddOData();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = feature.Error;

                var result = JsonConvert.SerializeObject(new { error = exception.Message });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));

            app.UseMvc(routerBuilder => 
            {
                routerBuilder.EnableDependencyInjection();
                routerBuilder.Expand().Select().Filter().Count().OrderBy();
            });
        }
    }
}
