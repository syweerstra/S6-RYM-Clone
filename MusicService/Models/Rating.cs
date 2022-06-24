namespace MusicService.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int AlbumID { get; set; }
        public double RatingOutOfTen { get; set; }
    }
}
