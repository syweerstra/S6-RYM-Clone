namespace ArtistService.Models
{
    public class Album
    {
        public int ID { get; set; } 
        public string? Name { get; set; } 
        public int ReleaseYear { get; set; } 
        public int AmountOfReviews { get; set; } 
        public int AmountOfRatings { get; set; } 
        public double AverageRating { get; set; } 
        public string AlbumCoverImageURL { get; set; } 
    }
}
