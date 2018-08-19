using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.DataAccess.EntityFramework;
using Dzaba.Randomizer.Utils;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.WebApi.Core.Services
{
    public interface ISignInManager
    {
        Task SignInAsync(User user, bool isPersistent);
        Task PasswordSignInAsync(string userName, string password, bool isPersistent);
    }

    internal sealed class SignInManager : ISignInManager
    {
        private readonly SignInManager<User> signInManager;

        public SignInManager(SignInManager<User> signInManager)
        {
            Require.NotNull(signInManager, nameof(signInManager));

            this.signInManager = signInManager;
        }

        public Task SignInAsync(User user, bool isPersistent)
        {
            Require.NotNull(user, nameof(user));

            return signInManager.SignInAsync(user, isPersistent);
        }

        public async Task PasswordSignInAsync(string userName, string password, bool isPersistent)
        {
            Require.NotEmpty(userName, nameof(userName));
            Require.NotEmpty(password, nameof(password));

            var result = await signInManager.PasswordSignInAsync(userName, password, isPersistent, false);

            if (!result.Succeeded)
            {
                throw new IdentityException(BuildErrors(result, userName));
            }
        }

        private IEnumerable<IdentityError> BuildErrors(SignInResult result, string userName)
        {
            if (result.IsLockedOut)
            {
                yield return new IdentityError
                {
                    Code = nameof(SignInResult.IsLockedOut),
                    Description = $"The user {userName} is locked out."
                };
            }

            if (result.IsNotAllowed)
            {
                yield return new IdentityError
                {
                    Code = nameof(SignInResult.IsNotAllowed),
                    Description = $"The user {userName} is not allowed to sign in."
                };
            }

            if (result.RequiresTwoFactor)
            {
                yield return new IdentityError
                {
                    Code = nameof(SignInResult.RequiresTwoFactor),
                    Description = $"The user {userName} requires two factor authentication."
                };
            }
        }
    }
}
