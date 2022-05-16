using MusicService.Models;
using System.ComponentModel.DataAnnotations;

namespace MusicService.DTOs
{
    public class AddMusicDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ArtistID  { get; set; }
        [Required]
        public string Types { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public List<SongDTO> Songs { get; set; } = new();

        public List<int> GenreIDs { get; set; } = new();
        public List<string> Descriptors { get; set; } = new();
        public List<string> Languages { get; set; } = new();
    }
}
