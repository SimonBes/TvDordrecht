using Microsoft.AspNetCore.Mvc;
using TvDordrecht.Context;

namespace TvDordrecht.Controllers
{
    public class CompetitionsController(TvdContext context, ILogger<CompetitionsController> logger) : Controller
    {
        private readonly TvdContext _context = context;
        private readonly ILogger<CompetitionsController> _logger = logger;

        public IActionResult Index()
        {
            return View();
        }
    }
}
