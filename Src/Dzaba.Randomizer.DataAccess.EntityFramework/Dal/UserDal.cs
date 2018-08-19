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
        private readonly UserManager<User> userManager;

        public UserDal(UserManager<User> userManager)
        {
            Require.NotNull(userManager, nameof(userManager));

            this.userManager = userManager;
        }

        public async Task<User> CreateAsync(string email, string password)
        {
            Require.NotWhiteSpace(email, nameof(email));
            Require.NotWhiteSpace(password, nameof(password));

            var entity = new User
            {
                Name = email,
                Email = email
            };

            var result = await userManager.CreateAsync(entity);

            if (result.Succeeded)
            {
                return entity;
            }

            throw new IdentityException(result.Errors);
        }

        public Task<User> GetUserByNameAsync(string name)
        {
            Require.NotEmpty(name, nameof(name));

            return userManager.FindByNameAsync(name);
        }
    }
}
