using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app_mvc_core_identity.Controllers
{
    public class TesteController : Controller
    {
        private readonly ILogger<TesteController> _logger;

        public TesteController(ILogger<TesteController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogError("Esse erro aconteceu");
            return View();
        }
    }
}