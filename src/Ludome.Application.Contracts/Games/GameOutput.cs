namespace Ludome.Application.Contracts.Games
{
    public class GameOutput
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Rating { get; set; }
        public long ReviewsCount { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}