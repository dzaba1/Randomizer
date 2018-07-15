using Dzaba.Randomizer.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Dzaba.Randomizer.DataAccess.Contracts
{
    public static class TransformExtensions
    {
        public static NamedNavigation<T> ToNamedNavigation<T>(this INamedEntity<T> entity, string url)
        {
            Require.NotNull(entity, nameof(entity));
            Require.NotEmpty(url, nameof(url));

            return new NamedNavigation<T>
            {
                Id = entity.Id,
                Name = entity.Name,
                Url = url
            };
        }

        public static NamedNavigation<int>[] ToGroupsNavigation(this IEnumerable<Group> groups)
        {
            Require.NotNull(groups, nameof(groups));

            return groups.Select(g => g.ToNamedNavigation(Routes.BuildGroupRoute(g.Id))).ToArray();
        }

        public static NamedNavigation<long>[] ToUsersNavigation(this IEnumerable<User> users)
        {
            Require.NotNull(users, nameof(users));

            return users.Select(u => u.ToNamedNavigation(Routes.BuildUserRoute(u.Id))).ToArray();
        }
    }
}
