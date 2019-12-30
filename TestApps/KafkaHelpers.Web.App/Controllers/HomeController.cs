using KafkaHelpers.Web.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace KafkaHelpers.Web.App.Controllers
{
    /// <summary>
    /// Main controller for this test application.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IOptions<TestOptions> options;
        private readonly TestConsumer consumer;
        private readonly TestProducer producer;
        private readonly TestAdmin admin;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger">The logger.</param>
        /// <param name="consumer"></param>
        /// <param name="producer"></param>
        /// <param name="admin"></param>
        public HomeController(
            IOptions<TestOptions> options,
            ILogger<HomeController> logger,
            TestConsumer consumer,
            TestProducer producer,
            TestAdmin admin)
        {
            this.logger = logger;
            this.options = options;
            this.consumer = consumer;
            this.producer = producer;
            this.admin = admin;

            this.logger.LogDebug($"{nameof(HomeController)}: Was initialized.");
        }

        /// <summary>
        /// Gets the default View.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets the Privacy View.
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Gets the Error View.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
