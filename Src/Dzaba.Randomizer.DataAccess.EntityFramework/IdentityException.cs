using Dzaba.Randomizer.Utils;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Dzaba.Randomizer.DataAccess.EntityFramework
{

    [Serializable]
    public class IdentityException : Exception
    {
        public IdentityError[] Errors { get; }

        public IdentityException(IEnumerable<IdentityError> errors)
        {
            Require.NotNull(errors, nameof(errors));

            Errors = errors.ToArray();
        }

        public IdentityException(IEnumerable<IdentityError> errors, string message)
            : base(message)
        {
            Require.NotNull(errors, nameof(errors));

            Errors = errors.ToArray();
        }

        public IdentityException(IEnumerable<IdentityError> errors, string message, Exception inner)
            : base(message, inner)
        {
            Require.NotNull(errors, nameof(errors));

            Errors = errors.ToArray();
        }

        protected IdentityException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }
}
