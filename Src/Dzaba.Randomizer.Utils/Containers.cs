using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace Dzaba.Randomizer.Utils
{
    public class Containers
    {
        public Containers()
        {
            Kernel = new StandardKernel();
            ServiceCollection = new ServiceCollection();
        }

        public Containers(IServiceCollection serviceCollection)
        {
            Require.NotNull(serviceCollection, nameof(serviceCollection));

            Kernel = new StandardKernel();
            ServiceCollection = serviceCollection;
        }

        public IKernel Kernel { get; }
        public IServiceCollection ServiceCollection { get; }
    }
}
