using GoCoCMS.Core.DependencyRegistrator;
using GoCoCMS.Web.Areas.Admin.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace GoCoCMS.Web.Areas.Admin.Infrastructure.DependencyRegistrator
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICategoryModelFactory, CategoryModelFactory>();
            serviceCollection.AddScoped<IBaseModelFactory, BaseModelFactory>();
        }
    }
}
