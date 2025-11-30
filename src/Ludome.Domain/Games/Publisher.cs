namespace Ludome.Domain.Games
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; } = [];

        public Publisher(string name)
        {
            Name = name;
        }
    }
}
