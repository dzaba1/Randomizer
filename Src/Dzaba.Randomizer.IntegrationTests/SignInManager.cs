using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Dzaba.Randomizer.WebApi.Core.Services;
using System;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.IntegrationTests
{
    internal sealed class SignInManager : ISignInManager
    {
        private IUserDal userDal;

        public SignInManager(IUserDal userDal)
        {
            Require.NotNull(userDal, nameof(userDal));

            this.userDal = userDal;
        }

        public async Task PasswordSignInAsync(string userName, string password, bool isPersistent)
        {
            var user = await userDal.GetUserByNameAsync(userName);
            if (user == null)
            {
                throw new InvalidOperationException($"The user {userName} doesn't exist.");
            }

            if (user.PasswordHash != password)
            {
                throw new InvalidOperationException($"The password for user {userName} doesn't match.");
            }
        }

        public Task SignInAsync(User user, bool isPersistent)
        {
            return Task.CompletedTask;
        }
    }
}
