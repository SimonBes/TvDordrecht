namespace TvDordrecht.ViewModels
{
    public class SwimTestIndexItemViewModel
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

		public int AmountOfParticipants { get; set; }
    }

    public class SwimTestDetailsViewModel
    {
        public DateOnly Date { get; set; }

        public ICollection<SwimTestParticipantViewModel> Participants { get; set; }
    }

    public class SwimTestParticipantViewModel
    {
        public string Name { get; set; }

        public TimeOnly Time100 { get; set; }

        public TimeOnly Time200 { get; set; }

        public TimeOnly Time300 { get; set; }

        public TimeOnly Time400 { get; set; }

        public TimeOnly Time500 { get; set; }

        public TimeOnly? Split100 { get; set; }

        public TimeOnly? Split200 { get; set; }

        public TimeOnly? Split300 { get; set; }

        public TimeOnly? Split400 { get; set; }

        public TimeOnly? Split500 { get; set; }

        public TimeOnly PaceTime { get; set; }
    }
}
