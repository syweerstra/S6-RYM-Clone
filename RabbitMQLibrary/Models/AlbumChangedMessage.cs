using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQLibrary.Models
{
    public class AlbumChangedMessage
    {
        public int ID { get; set; }
        public int ArtistID { get; set; }
        public string? Name { get; set; }
        public string AlbumCoverImageURL { get; set; }

        public int ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public int AmountOfRatings { get; set; }
    }
}
