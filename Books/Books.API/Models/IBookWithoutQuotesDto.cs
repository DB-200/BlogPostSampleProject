namespace Books.API.Models
{
    public interface IBookWithoutQuotesDto
    {
        string Author { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        string Title { get; set; }
        string Genre { get; set; }
    }
}