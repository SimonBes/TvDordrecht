using Microsoft.AspNetCore.Mvc;
using TvDordrecht.Context;
using TvDordrecht.Models;

namespace TvDordrecht.Controllers
{
    public class SwimTestsController(TvdContext context, ILogger<SwimTestsController> logger) : Controller
    {
        private readonly TvdContext _context = context;
        private readonly ILogger<SwimTestsController> _logger = logger;

        public IActionResult Index()
        {
            List<SwimTestIndexItemViewModel> model = [.. _context.SwimtestSwimtests
                .OrderByDescending(st => st.Date)
                .Select(st => new SwimTestIndexItemViewModel
                {
                    Id = st.Id,
                    Date = st.Date,
					AmountOfParticipants = st.SwimtestRecords.Count
                })];

            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            SwimtestSwimtest swimTest = _context.SwimtestSwimtests.Find(id);

            if (swimTest == null)
                return NotFound();

            SwimTestDetailsViewModel model = new()
            {
                Date = swimTest.Date,
                Participants = [.. _context.SwimtestRecords.Where(sr => sr.SwimTestId == id).Select(sr => new SwimTestParticipantViewModel
                {
                    Name = sr.User.FirstName + " " + sr.User.LastName,
                })]
            };

            return View(model);
        }
    }
}
