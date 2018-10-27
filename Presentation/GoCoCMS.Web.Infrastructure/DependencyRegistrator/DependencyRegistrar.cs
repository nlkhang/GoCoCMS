using GoCoCMS.Core.DependencyRegistrator;
using GoCoCMS.Data;
using GoCoCMS.Data.Repositories;
using GoCoCMS.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GoCoCMS.Web.Infrastructure.DependencyRegistrator
{
    public class DependencyRegistrar : IDependencyRegistrator
    {
        public void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDbContext, GoCoCmsContext>();

            // repository
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // service
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
