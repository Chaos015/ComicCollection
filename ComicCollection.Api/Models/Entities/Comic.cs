namespace ComicCollection.Api.Models.Entities
{
    public class Comic
    { 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
        public int? PublicationYear { get; set; }
        public string? genre { get; set; } = string.Empty;
    }
}
