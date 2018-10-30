//using System;
using GoCoCMS.Core.DependencyRegistrator;
using GoCoCMS.Web.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace GoCoCMS.Web.Infrastructure.DependencyRegistrator
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICategoryModelFactory, CategoryModelFactory>();
            serviceCollection.AddScoped<IPostModelFactory, PostModelFactory>();
        }
    }
}
