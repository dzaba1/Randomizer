using System.ComponentModel.DataAnnotations;

namespace Dzaba.Randomizer.Contracts
{
    public class LoginUser
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
