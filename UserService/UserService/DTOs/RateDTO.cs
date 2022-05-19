namespace UserService.DTOs
{
    public class RateDTO
    {
        public int UserID { get; set; }
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public int RatingOutOfTen { get; set; }
        public string? ArtistName { get; set; }
        public string AlbumCoverImageURL { get; set; }


        public string? AlbumName { get; set; }
        public int AlbumReleaseYear { get; set; }
    }
}   
