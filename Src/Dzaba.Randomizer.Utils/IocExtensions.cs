using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.Syntax;
using System;
using System.Linq;

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

        public static void RegisterSingletonInstance<T>(this IKernel container, T instance)
        {
            Require.NotNull(container, nameof(container));
            Require.NotNull(instance, nameof(instance));

            container.Bind<T>().ToConstant(instance).InSingletonScope();
        }

        public static void CopyTo(this IServiceCollection serviceCollection, IKernel container)
        {
            Require.NotNull(serviceCollection, nameof(serviceCollection));
            Require.NotNull(container, nameof(container));

            foreach (var descriptor in serviceCollection)
            {
                if (descriptor.ImplementationInstance != null)
                {
                    var bind = container.Bind(descriptor.ServiceType)
                        .ToConstant(descriptor.ImplementationInstance);

                    SetLifetime(bind, descriptor.Lifetime);
                }

                if (descriptor.ImplementationFactory != null)
                {
                    var bind = container.Bind(descriptor.ServiceType)
                        .ToMethod(c => descriptor.ImplementationFactory(c.Kernel));

                    SetLifetime(bind, descriptor.Lifetime);
                }

                if (descriptor.ImplementationType != null)
                {
                    var bind = container.Bind(descriptor.ServiceType)
                        .To(descriptor.ImplementationType);

                    SetLifetime(bind, descriptor.Lifetime);
                }
            }
        }

        private static void SetLifetime(IBindingWhenInNamedWithOrOnSyntax<object> bind, ServiceLifetime lifetime)
        {
            switch (lifetime)
            {
                case ServiceLifetime.Transient:
                    bind.InTransientScope();
                    break;
                case ServiceLifetime.Scoped:
                    bind.InThreadScope();
                    break;
                case ServiceLifetime.Singleton:
                    bind.InSingletonScope();
                    break;
                default: throw new ArgumentException($"Unknown value of lifetime: {lifetime}", nameof(lifetime));
            }
        }

        public static void Remove<T>(this IServiceCollection serviceCollection)
        {
            Require.NotNull(serviceCollection, nameof(serviceCollection));

            var type = typeof(T);
            var item = serviceCollection.FirstOrDefault(d => d.ServiceType == type);
            if (item != null)
            {
                serviceCollection.Remove(item);
            }
        }

        public static void RegisterTransientOverride<TService, TImpl>(this IServiceCollection serviceCollection)
            where TImpl : class, TService
            where TService : class
        {
            Require.NotNull(serviceCollection, nameof(serviceCollection));

            serviceCollection.Remove<TService>();
            serviceCollection.AddTransient<TService, TImpl>();
        }
    }
}
