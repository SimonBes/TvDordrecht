namespace TvDordrecht.ViewModels
{
    public class NewsItemViewModel
    {
        public required int Id { get; set; }

        public required string Title { get; set; }

        public required string Text { get; set; }

        public required string ImagePath { get; set; }

		public required DateTime? DateTime { get; set; }
	}

    public class NewsDetailsViewModel
    {
        public required string Title { get; set; }

        public required string Text { get; set; }

        public required string ImagePath { get; set; }

        public required DateTime? DateTime { get; set; }

        public required string Owner { get; set; }

    }
}
