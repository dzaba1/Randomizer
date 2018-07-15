using Ninject;
using System;

namespace Dzaba.Randomizer.Utils
{
    public static class IocExtensions
    {
        public static void RegisterTransient<TInt, TImpl>(this IKernel container)
            where TImpl : TInt
        {
            Require.NotNull(container, nameof(container));

            container.Bind<TInt>().To<TImpl>().InTransientScope();
        }

        public static void RegisterSingleton<TInt, TImpl>(this IKernel container)
            where TImpl : TInt
        {
            Require.NotNull(container, nameof(container));

            container.Bind<TInt>().To<TImpl>().InSingletonScope();
        }

        public static void RegisterFactoryMethod<T>(this IKernel container)
        {
            Require.NotNull(container, nameof(container));

            container.Bind<Func<T>>()
                .ToMethod(c => () => c.Kernel.Get<T>())
                .InTransientScope();
        }
    }
}
