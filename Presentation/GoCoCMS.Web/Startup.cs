using AutoMapper;
using GoCoCMS.Core.Mapper;
using GoCoCMS.Data;
using GoCoCMS.Data.Repositories;
using GoCoCMS.Service;
using GoCoCMS.Web.Areas.Admin.Factories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GoCoCMS.Web
{
    public class Startup
    {
        #region Ctor

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // register dependency injection
            AddDependencyInjection(services);

            // register auto mapper
            AddAutoMapper(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #endregion

        #region Utilities

        public void AddDependencyInjection(IServiceCollection services)
        {
            // Db context
            services.AddDbContext<GoCoCmsContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"))
            );
            services.AddScoped<IDbContext, GoCoCmsContext>();

            // repository
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // service
            services.AddScoped<ICategoryService, CategoryService>();

            // model factory
            services.AddScoped<ICategoryModelFactory, CategoryModelFactory>();
            services.AddScoped<IBaseModelFactory, BaseModelFactory>();
        }

        public void AddAutoMapper(IServiceCollection services)
        {
            // get all instances of IMapperProfile
            var mapperProfileType = typeof(IMapperProfile);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => mapperProfileType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

            // mapping config
            var mappingConfig = new MapperConfiguration(mc =>
            {
                foreach (var type in types)
                    mc.AddProfile(type);
            });
            
            // init auto mapper
            AutoMapperConfiguration.Init(mappingConfig);
        }

        #endregion
    }
}
