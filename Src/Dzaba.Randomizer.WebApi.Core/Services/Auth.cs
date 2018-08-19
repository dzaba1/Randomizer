using Dzaba.Randomizer.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using Dzaba.Randomizer.Utils;
using Dzaba.Randomizer.WebApi.Jwt;
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
        private readonly ISignInManager signInManager;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IUserDal userDal;

        public Auth(ISignInManager signInManager,
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

            await signInManager.PasswordSignInAsync(email, password, false);
            var user = await userDal.GetUserByNameAsync(email);
            var token = tokenGenerator.Generate(user);

            return new UserInfo
            {
                User = user.ToNamedNavigation(),
                TokenData = token
            };
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
