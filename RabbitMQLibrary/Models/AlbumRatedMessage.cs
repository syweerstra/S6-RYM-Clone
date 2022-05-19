using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQLibrary.Models
{
    public class AlbumRatedMessage
    {
        public bool AlreadyRated { get; set; }
        public int AlbumID { get; set; }
        public int RatingOutOfTen { get; set; }
    }
}
