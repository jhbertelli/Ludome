namespace Ludome.Domain.Games
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int YearReleased { get; set; }
        public List<Rating> Ratings { get; set; } = [];
        public List<Developer> Developers { get; set; } = [];
        public List<Publisher> Publishers { get; set; } = [];
        public List<Category> Categories { get; set; } = [];

        public Game(string title, string image, string description, int yearReleased)
        {
            Title = title;
            Image = image;
            Description = description;
            YearReleased = yearReleased;
        }

        public void AddRating(Rating rating)
            => Ratings.Add(rating);

        public void RemoveRating(Guid ratingId)
        {
            var rating = Ratings.FirstOrDefault(rating => rating.Id == ratingId);

            //if (rating is null) throw new Exception();

            Ratings.Remove(rating!);
        }
    }
}
