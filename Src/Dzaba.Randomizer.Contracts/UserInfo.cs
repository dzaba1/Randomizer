namespace Dzaba.Randomizer.Contracts
{
    public class UserInfo
    {
        public NamedNavigation<long> User { get; set; }
        public TokenData TokenData { get; set; }
    }
}
