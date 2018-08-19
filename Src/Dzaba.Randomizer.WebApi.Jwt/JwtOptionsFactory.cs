﻿using Dzaba.Randomizer.Utils;
using Microsoft.Extensions.Configuration;
using System;

namespace Dzaba.Randomizer.WebApi.Jwt
{
    public interface IJwtOptionsFactory
    {
        JwtOptions Create();
    }

    internal sealed class JwtOptionsFactory : IJwtOptionsFactory
    {
        private readonly IConfiguration configuration;

        public JwtOptionsFactory(IConfiguration configuration)
        {
            Require.NotNull(configuration, nameof(configuration));

            this.configuration = configuration;
        }

        public JwtOptions Create()
        {
            return new JwtOptions
            {
                SaveToken = true,
                RequireHttpsMetadata = bool.Parse(configuration["JwtRequireHttpsMetadata"]),
                ValidIssuer = configuration["JwtIssuer"],
                ValidAudience = configuration["JwtIssuer"],
                Key = configuration["JwtKey"],
                Expires = TimeSpan.FromDays(double.Parse(configuration["JwtExpireDays"]))
            };
        }
    }
}
