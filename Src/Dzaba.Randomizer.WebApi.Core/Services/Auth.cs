using Dzaba.Randomizer.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.DataAccess.EntityFramework;
using Dzaba.Randomizer.Utils;
using Dzaba.Randomizer.WebApi.Jwt;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.WebApi.Core.Services
{
    public interface IAuth
    {
        Task<UserInfo> Register(string email, string password);
        Task<UserInfo> Login(string email, string password);
    }

    internal sealed class Auth : IAuth
    {
        private readonly SignInManager<User> signInManager;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IUserDal userDal;

        public Auth(SignInManager<User> signInManager,
            ITokenGenerator tokenGenerator,
            IUserDal userDal)
        {
            Require.NotNull(signInManager, nameof(signInManager));
            Require.NotNull(tokenGenerator, nameof(tokenGenerator));
            Require.NotNull(userDal, nameof(userDal));

            this.signInManager = signInManager;
            this.tokenGenerator = tokenGenerator;
            this.userDal = userDal;
        }

        public async Task<UserInfo> Login(string email, string password)
        {
            Require.NotEmpty(email, nameof(email));
            Require.NotEmpty(password, nameof(password));

            await SignIn(email, password);
            var user = await userDal.GetUserByNameAsync(email);
            var token = tokenGenerator.Generate(user);

            return new UserInfo
            {
                User = user.ToNamedNavigation(),
                TokenData = token
            };
        }

        private async Task SignIn(string email, string password)
        {
            var result = await signInManager.PasswordSignInAsync(email, password, false, false);
            if (!result.Succeeded)
            {
                throw new IdentityException(BuildErrors(result, email));
            }
        }

        private IEnumerable<IdentityError> BuildErrors(SignInResult result, string email)
        {
            if (result.IsLockedOut)
            {
                yield return new IdentityError
                {
                    Code = nameof(SignInResult.IsLockedOut),
                    Description = $"The user {email} is locked out."
                };
            }

            if (result.IsNotAllowed)
            {
                yield return new IdentityError
                {
                    Code = nameof(SignInResult.IsNotAllowed),
                    Description = $"The user {email} is not allowed to sign in."
                };
            }

            if (result.RequiresTwoFactor)
            {
                yield return new IdentityError
                {
                    Code = nameof(SignInResult.RequiresTwoFactor),
                    Description = $"The user {email} required two factor authentication."
                };
            }
        }

        public async Task<UserInfo> Register(string email, string password)
        {
            Require.NotEmpty(email, nameof(email));
            Require.NotEmpty(password, nameof(password));

            var user = await userDal.CreateAsync(email, password);
            await signInManager.SignInAsync(user, false);
            var token = tokenGenerator.Generate(user);

            return new UserInfo
            {
                User = user.ToNamedNavigation(),
                TokenData = token
            };
        }
    }
}
