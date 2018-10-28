using AutoMapper;
using GoCoCMS.Core.DependencyRegistrator;
using GoCoCMS.Core.Mapper;
using GoCoCMS.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GoCoCMS.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // dependency for db context
            services.AddDbContext<GoCoCmsContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        }

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            // find dependency registrator
            var dependencyRegistratorType = typeof(IDependencyRegistrator);
            var dependencyRegistratorImplementTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => dependencyRegistratorType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

            // get instance
            var instances = dependencyRegistratorImplementTypes.Select(dependencyRegistrator =>
                (IDependencyRegistrator) Activator.CreateInstance(dependencyRegistrator));

            // register instance of type
            foreach (var instance in instances)
                instance.Register(services);
        }

        public static void AddAutoMapper(this IServiceCollection services)
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
    }
}
