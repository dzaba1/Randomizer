using Dzaba.Randomizer.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ninject;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Dzaba.Randomizer.WebApi.Jwt
{
    public static class Bootstrapper
    {
        public static void RegisterJwtAuth(this Containers container)
        {
            Require.NotNull(container, nameof(container));

            container.Kernel.RegisterTransient<IJwtOptionsFactory, JwtOptionsFactory>();
            container.Kernel.RegisterTransient<ITokenGenerator, TokenGenerator>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            container.ServiceCollection.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    var options = container.Kernel.Get<IJwtOptionsFactory>().Create();

                    cfg.RequireHttpsMetadata = options.RequireHttpsMetadata;
                    cfg.SaveToken = options.SaveToken;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = options.ValidIssuer,
                        ValidAudience = options.ValidAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key)),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
        }
    }
}
