using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(Index));
            }
        }

        public IActionResult Error()
        {
            try
            {
                return View("Error");
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(Error));
            }
        }

        private IActionResult HandleException(Exception exception, string actionName)
        {
            _logger.LogError(exception, "An error occurred while executing {ActionName}.", actionName);
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            return View("Error");
        }
    }
}