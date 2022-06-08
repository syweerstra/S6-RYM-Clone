namespace UserService.DTOs
{
    public class GetAlbumRatingDTO 
    {
        public Guid UserID { get; set; }
        public int AlbumID { get; set; }
    }
}
