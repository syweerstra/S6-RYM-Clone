namespace MusicService.Models
{
    public class Album
    {
        public string? Name { get; set; }
        public Artist? Artist { get; set; }
        public string Types { get; set; } 

        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public int AmountOfRatings { get; set; }
        public List<Genre> Genres { get; set; } = new();
        public List<Song> Songs { get; set; } = new();
        public List<string> Descriptors { get; set; } = new();
        public List<string> Languages { get; set; } = new();
        

    }
}