using System.ComponentModel.DataAnnotations;

namespace MusicService.DTOs
{
    public class SongDTO
    {
        [Required]
        public int OrderNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int DurationInSeconds { get; set; }
    }
}
