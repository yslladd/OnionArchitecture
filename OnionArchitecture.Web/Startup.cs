using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnionArchitecture.Application;
using OnionArchitecture.Application.Interface;
using OnionArchitecture.Domain.Interfaces.Repositories;
using OnionArchitecture.Domain.Interfaces.Services;
using OnionArchitecture.Domain.Services;
using OnionArchitecture.Infra.Data.DataContext;
using OnionArchitecture.Infra.Data.Repositories;

namespace OnionArchitecture.Web
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
            //adding dependency injection
            #region Dependency Injection
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<ITaskAppService, TaskAppService>();

            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            #endregion

            services.AddDbContext<OAContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OAConnectionString")));
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            ////referencing data for migrations
            //using (var migrationSvcScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
            //    .CreateScope())
            //{
            //    migrationSvcScope.ServiceProvider.GetService<OnionArchitectureContext>().Database.Migrate();
            //    // you can also add the data here... let me know if you need I will post it
            //}


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
