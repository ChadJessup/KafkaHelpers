using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace KafkaHelpers.Web.App
{
    /// <summary>
    /// Program entry point class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main entry point to the application.
        /// </summary>
        /// <param name="args">Startup arguments passed into the application.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        /// <summary>
        /// Builds an <seealso cref="IHostBuilder"/> which sets up this application.
        /// </summary>
        /// <param name="args">The commandline arguments passed into this application.</param>
        /// <returns>The <seealso cref="IHostBuilder"/> that will build the application.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
