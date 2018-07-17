using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Dal
{
    internal sealed class UserDal : IUserDal
    {
        private readonly Func<UserManager<User>> userManagerFactory;

        public UserDal(Func<UserManager<User>> userManagerFactory)
        {
            Require.NotNull(userManagerFactory, nameof(userManagerFactory));

            this.userManagerFactory = userManagerFactory;
        }

        public async Task<long> CreateAsync(string name, string password)
        {
            Require.NotWhiteSpace(name, nameof(name));
            Require.NotWhiteSpace(password, nameof(password));

            using (var userManager = userManagerFactory())
            {
                var entity = new User
                {
                    Name = name
                };

                var result = await userManager.CreateAsync(entity);

                if (result.Succeeded)
                {
                    return entity.Id;
                }
                else
                {
                    throw new IdentityException(result.Errors);
                }
            }
        }
    }
}
