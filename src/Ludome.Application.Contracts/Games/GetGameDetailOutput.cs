namespace Ludome.Application.Contracts.Games
{
    public class GetGameDetailOutput
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double AverageRating { get; set; }
        public int ReviewsCount { get; set; }
        public string Image { get; set; } = string.Empty;
        public IEnumerable<string> Categories { get; set; } = [];
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public IEnumerable<string> Developers { get; set; } = [];
        public IEnumerable<string> Publishers { get; set; } = [];
    }
}
