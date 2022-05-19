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
        public int ReleaseDate { get; set; }
        [Required]
        public List<SongDTO> Songs { get; set; } = new();

        public string GenreIDs { get; set; }
        public string Descriptors { get; set; } 
        public string Languages { get; set; } 
    }
}
