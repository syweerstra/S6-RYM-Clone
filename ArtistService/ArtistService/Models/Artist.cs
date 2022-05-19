namespace ArtistService.Models
{
    public class Artist
    {

        public int ID { get; set; }
        public string? Name { get; set; }
        public string? BornIn { get; set; }
        public string? CurrentlyIn { get; set; }
        public string? ArtistImageURL { get; set; }

        public List<Artist> MemberOf { get; set; } = new();
        public List<Album> Albums { get; set; } = new();
        public List<Genre> Genres { get; set; } = new();
    }
}