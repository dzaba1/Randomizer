using Dzaba.Randomizer.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dzaba.Randomizer.WebApi.Jwt
{
    public interface ITokenGenerator
    {
        TokenData Generate(User user);
    }

    internal sealed class TokenGenerator : ITokenGenerator
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IGuidProvider guidProvider;
        private readonly IJwtOptionsFactory jwtOptionsFactory;

        public TokenGenerator(IDateTimeProvider dateTimeProvider,
            IGuidProvider guidProvider,
            IJwtOptionsFactory jwtOptionsFactory)
        {
            Require.NotNull(dateTimeProvider, nameof(dateTimeProvider));
            Require.NotNull(guidProvider, nameof(guidProvider));
            Require.NotNull(jwtOptionsFactory, nameof(jwtOptionsFactory));

            this.dateTimeProvider = dateTimeProvider;
            this.guidProvider = guidProvider;
            this.jwtOptionsFactory = jwtOptionsFactory;
        }

        public TokenData Generate(User user)
        {
            Require.NotNull(user, nameof(user));
            Require.NotEmpty(user.Name, nameof(user.Name));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, guidProvider.CreateNew().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var options = jwtOptionsFactory.Create();
            var now = dateTimeProvider.Now();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = now.Add(options.Expires);

            var token = new JwtSecurityToken(
                options.ValidIssuer,
                options.ValidAudience,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenResult = new JwtSecurityTokenHandler().WriteToken(token);
            return new TokenData
            {
                Expires = expires,
                Token = tokenResult
            };
        }
    }
}
