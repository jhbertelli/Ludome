namespace Ludome.Domain.Games
{
    public class Developer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; } = [];

        public Developer(string name)
        {
            Name = name;
        }
    }
}
