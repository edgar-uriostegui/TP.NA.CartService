namespace CartService.Application.Extensions
{
    using Carter;
    using Microsoft.AspNetCore.Builder;

    /// <summary>
    /// Web application extension class
    /// </summary>
    public static class WebApplicationExtension
    {
        /// <summary>
        /// Configure application properties at application layer level
        /// </summary>
        /// <param name="app">Web application</param>
        public static void ConfigureApp(this WebApplication app) 
        {
            app.MapCarter();
        }
    }
}
