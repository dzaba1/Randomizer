using Microsoft.AspNetCore.Mvc;

namespace Dzaba.Randomizer.IntegrationTests
{
    public static class Utils
    {
        public static T Content<T>(this IActionResult result)
        {
            var okResult = (OkObjectResult)result;
            return (T)okResult.Value;
        }
    }
}
