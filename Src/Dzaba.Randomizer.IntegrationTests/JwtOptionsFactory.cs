using Dzaba.Randomizer.WebApi.Jwt;
using System;

namespace Dzaba.Randomizer.IntegrationTests
{
    internal sealed class JwtOptionsFactory : IJwtOptionsFactory
    {
        public JwtOptions Create()
        {
            return new JwtOptions
            {
                Expires = TimeSpan.FromDays(1),
                Key = "fdsdfsdfs87df68s6fnbjks4kj4b5kj34b5345",
                RequireHttpsMetadata = false,
                SaveToken = true,
                ValidAudience = "dzaba",
                ValidIssuer = "dzaba"
            };
        }
    }
}
