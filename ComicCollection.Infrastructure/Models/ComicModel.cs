namespace ComicCollection.Infrastructure.Models;

public class ComicModel
{
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Editorial { get; set; } = string.Empty;
    public int? PublicationYear { get; set; }
    public string? Genre { get; set; }
}