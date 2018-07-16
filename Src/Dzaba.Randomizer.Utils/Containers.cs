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

        public IKernel Kernel { get; }
        public IServiceCollection ServiceCollection { get; }
    }
}
