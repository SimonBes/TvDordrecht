using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TvDordrecht.Context;
using TvDordrecht.Models;
using TvDordrecht.ViewModels;

namespace TvDordrecht.Controllers
{
	public class HomeController : Controller
	{
		private readonly TvdContext _context;
		private readonly ILogger<HomeController> _logger;

		public HomeController(TvdContext context, ILogger<HomeController> logger)
		{
			_context = context;
			_logger = logger;
		}

		public IActionResult Index()
		{
			DateTime now = DateTime.UtcNow;

			List<NewsItemViewModel> news = [.. _context.WebappNews
				.OrderByDescending(n => n.PubDate)
				.Take(6)
				.Select(n => new NewsItemViewModel
				{
					Id = n.Id,
					Title = n.Title,
					Text = n.Text,
					ImagePath = n.Image.Image,
					DateTime = n.PubDate
				})];

            List<TrainingItemViewModel> training = [.. _context.TrainingSessions
				.Where(t => t.Start > now)
                .OrderBy(t => t.Start)
                .Take(5)
                .Select(n => new TrainingItemViewModel
                {
                    DateTime = n.Start,
                    Discipline = n.Discipline.Title,
					Location = n.Location.Title,
					Trainer = n.Trainer.Username
                })];

     //       List<WhoWhatWhereItemViewModel> whoWhatWhere = [.. _context.RaceEvents
     //           .OrderByDescending(e => e.PubDate)
     //           .Take(6)
     //           .Select(n => new WhoWhatWhereItemViewModel
     //           {
     //               DateTime = n.Title,
     //               Event = n.Text,
					//Distance,
					//Athlete
     //           })];

            HomeIndexViewModel model = new() {
				News = news,
				Training = training,
				WhoWhatWhere = []
			};

            return View(model);
		}
	}
}
