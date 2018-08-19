using Dzaba.Randomizer.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Dzaba.Randomizer.WebApi.Core
{
    public static class Extensions
    {
        public static void CopyErrorsFrom(this ModelStateDictionary modelState, IEnumerable<IdentityError> errors)
        {
            Require.NotNull(modelState, nameof(modelState));
            Require.NotNull(errors, nameof(errors));

            foreach (var error in errors)
            {
                modelState.AddModelError(error.Code, error.Description);
            }
        }
    }
}
