namespace TvDordrecht.ViewModels
{
    public class HomeIndexViewModel
    {
        public required ICollection<NewsItemViewModel> News { get; set; }

        public required ICollection<TrainingItemViewModel> Training { get; set; }

        public required ICollection<WhoWhatWhereItemViewModel> WhoWhatWhere { get; set; }
    }

    public class TrainingItemViewModel
    {
        public required DateTime DateTime { get; set; }

        public required string Discipline { get; set; }

        public required string Location { get; set; }

        public required string Trainer { get; set; }
    }

    public class WhoWhatWhereItemViewModel
    {
        public required DateTime DateTime { get; set; }

        public required string Event { get; set; }

        public required string Distance { get; set; }

        public required string Athlete { get; set; }
    }
}
