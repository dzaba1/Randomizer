namespace Dzaba.Randomizer.Contracts
{
    public static class Routes
    {
        public const string EnvironmentsControllerRoute = "api/environments";
        public const string GroupsControllerRoute = "api/groups";
        public const string UsersControllerRoute = "api/users";

        public static string BuildEnvironmentRoute(int id)
        {
            return EnvironmentsControllerRoute + "/" + id;
        }

        public static string BuildGroupRoute(int id)
        {
            return GroupsControllerRoute + "/" + id;
        }

        public static string BuildUserRoute(long id)
        {
            return UsersControllerRoute + "/" + id;
        }
    }
}
