namespace Ludome.Application.Contracts.Games
{
    public class RatingInput
    {
        public Guid GameId { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
    }
}
