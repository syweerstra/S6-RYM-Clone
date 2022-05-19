namespace MusicService.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public Artist? Artist { get; set; }
        public string Types { get; set; } 
        public string AlbumCoverImageURL { get; set; } 

        public int ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public int AmountOfRatings { get; set; }
        public List<double> Ratings { get; set; } = new();
        public string Genres { get; set; } 
        public List<Song> Songs { get; set; } = new();
        public string Descriptors { get; set; } 
        public string Languages { get; set; }
        

    }
}