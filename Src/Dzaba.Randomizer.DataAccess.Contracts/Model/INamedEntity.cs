namespace Dzaba.Randomizer.DataAccess.Contracts.Model
{
    public interface INamedEntity<T>
    {
        T Id { get; set; }
        string Name { get; set; }
    }
}
