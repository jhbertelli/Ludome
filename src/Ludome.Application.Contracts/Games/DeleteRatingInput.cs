namespace Ludome.Application.Contracts.Games
{
    public class DeleteRatingInput
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
    }
}
