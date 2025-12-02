namespace Ludome.Application.Contracts.Games
{
    public class SearchGamesInput : GetPopularGamesInput
    {
        public string Search { get; set; } = string.Empty;
        public SearchSort SortBy { get; set; }
    }

    public enum SearchSort
    {
        Reviews,
        NameAsc,
        NameDesc
    }
}
