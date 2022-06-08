namespace UserService
{
    public class Rating
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public int ArtistID { get; set; }
        public string? ArtistName { get; set; }
        public int AlbumID { get; set; }
        public string AlbumCoverImageURL{ get; set; }


        public string? AlbumName { get; set; }
        public int AlbumReleaseYear { get; set; }
        public List<string> Genres { get; set; } = new();
        public int RatingOutOfTen { get; set; }
        public DateTime Date { get; set; }
    }
}