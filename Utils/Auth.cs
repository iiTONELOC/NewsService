namespace NewsService.Utils
{
    // can be used on its own but the AuthService class provides an
    // Authorize method that can be used as a middleware
    class Auth
    {
        private readonly string[]? ACCESS_KEYS;

        public Auth()
        {
            ACCESS_KEYS = Environment
                .GetEnvironmentVariable("ACCESS_KEYS")?
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
        }

        public bool IsAuthorized(string? key)
        {
            return ACCESS_KEYS?.Contains(key) ?? false;
        }

    }

    // AuthMiddleware
    public static class AuthService
    {
        private static readonly Auth auth = new();
        public static bool IsAuthorized(string? key) => auth
            .IsAuthorized(key);

        public static Task Authorize(HttpContext context, Func<Task> next)
        {
            // extract the token from the Authorization header
            // can use Bearer or just the token
            var key = context.Request.Headers["Authorization"]
            .ToString()
            .Replace("Bearer ", "");

            // if the key is not authorized, return a 401
            if (auth.IsAuthorized(key))
            {
                return next();
            }
            else
            {
                context.Response.StatusCode = 401;
                return context.Response.WriteAsync("Unauthorized");
            }
        }
    }
}
