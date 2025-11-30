namespace Ludome.Domain.Games
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public User CreatorUser { get; set; }
        public Guid CreatorUserId { get; set; }

        public Rating(int score, User creatorUser)
        {
            if (score < 0 || score > 10)
                throw new ArgumentOutOfRangeException(nameof(score));

            Score = score;
            CreatorUser = creatorUser;
        }

        protected Rating()
        {
        }
    }
}
