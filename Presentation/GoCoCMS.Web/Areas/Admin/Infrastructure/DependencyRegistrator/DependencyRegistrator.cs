using GoCoCMS.Core.DependencyRegistrator;
using GoCoCMS.Web.Areas.Admin.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace GoCoCMS.Web.Areas.Admin.Infrastructure.DependencyRegistrator
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBaseModelFactory, BaseModelFactory>();
            serviceCollection.AddScoped<IBlogCategoryModelFactory, BlogCategoryModelFactory>();
            serviceCollection.AddScoped<IBlogPostModelFactory, BlogPostModelFactory>();
        }
    }
}
