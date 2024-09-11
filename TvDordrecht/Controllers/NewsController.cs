using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TvDordrecht.Context;
using TvDordrecht.Models;

namespace TvDordrecht.Controllers
{
    public class NewsController(TvdContext context, ILogger<NewsController> logger) : Controller
    {
        private readonly TvdContext _context = context;
        private readonly ILogger<NewsController> _logger = logger;

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            WebappNews? news = _context.WebappNews
                .Include(n => n.Image)
                .Include(n => n.Owner)
				.FirstOrDefault(n => n.Id == id);

            if (news == null)
                return NotFound();

            NewsDetailsViewModel model = new()
            {
                Title = news.Title,
                Text = news.Text,
                ImagePath = news.Image.Image,
                DateTime = news.PubDate,
                Owner = news.Owner.Username
            };

            return View(model);
        }
    }
}
