namespace Dzaba.Randomizer.Utils
{
    public static class Bootstrapper
    {
        public static void RegsiterUtils(this Containers container)
        {
            Require.NotNull(container, nameof(container));

            container.Kernel.RegisterTransient<IDateTimeProvider, DateTimeProvider>();
            container.Kernel.RegisterTransient<IGuidProvider, GuidProvider>();
        }
    }
}
