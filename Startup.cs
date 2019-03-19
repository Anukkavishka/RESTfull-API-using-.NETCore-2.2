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
using SuperMarket.Domain.Repositories;
using SuperMarket.Domain.Services;
using SuperMarket.Persistence.Contexts;
using SuperMarket.Persistance.Repositories;
using SuperMarket.Services;
using AutoMapper;
using SuperMarket.Persistence.Repositories;

//This class is responsible for configuring all kinds of configurations when the application starts

namespace SuperMarket
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        //ConfigureServices and Configure methods are called at runtime by the framework pipeline
        // to configure how the application should work and which components it must use.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);//defines to use controller classes to handle req,res

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("supermarket-api-in-memory"); //this is where we tell EF to create and use an in memory db 
                //and this is just only for this example since we are using a in memory db

                /* 
            The scoped lifetime tells the ASP.NET Core pipeline that every time it needs to resolve a class that receives an
             instance of AppDbContext as a constructor argument, it should use the same instance of the class.
              If there is no instance in memory, the pipeline will create a new instance, and reuse it throughout all classes
             that need it, during a given request. This way, you don’t need to manually create the 
             class instance when you need to use it.
            
            */
            });
            // this is where the actual implementation is binded to the Typeof Service/Repository class
            //interface ==> concreate implementation
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            //adding AutoMapper dependecny injection
            services.AddAutoMapper();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
