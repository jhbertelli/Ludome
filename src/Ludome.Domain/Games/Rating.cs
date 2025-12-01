namespace Ludome.Domain.Games
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public User CreatorUser { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Comment { get; set; }

        public Rating(int score, User creatorUser, string? comment)
        {
            if (score < 0 || score > 10)
                throw new ArgumentOutOfRangeException(nameof(score));

            Score = score;
            CreatorUser = creatorUser ?? throw new ArgumentException(nameof(creatorUser));
            Comment = comment;
        }

        protected Rating()
        {
        }
    }
}
