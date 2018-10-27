using Microsoft.Extensions.DependencyInjection;

namespace GoCoCMS.Core.DependencyRegistrator
{
    public interface IDependencyRegistrator
    {
        void Register(IServiceCollection serviceCollection);
    }
}
