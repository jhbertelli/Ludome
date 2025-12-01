namespace Ludome.Application.Contracts.Games
{
    public class RatingOutput
    {
        public Guid Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Score { get; set; }
        public string UserNickname { get; set; } = string.Empty;
        public bool IsMine { get; set; }
        public string? Comment { get; set; }
    }
}
