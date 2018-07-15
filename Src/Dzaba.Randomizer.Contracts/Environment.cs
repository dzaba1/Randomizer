namespace Dzaba.Randomizer.Contracts
{
    public class Environment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public NamedNavigation<int>[] Groups { get; set; }

        public NamedNavigation<long>[] Users { get; set; }
    }
}
