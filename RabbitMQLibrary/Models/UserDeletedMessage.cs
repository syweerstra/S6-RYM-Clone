using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQLibrary.Models
{
    public class UserDeletedMessage
    {
        public Guid UserID { get; set; }
        public List<int> AlbumsRatedIDs { get; set; }

        public UserDeletedMessage(Guid userID, List<int> albumsRatedIDs)
        {
            UserID = userID;
            AlbumsRatedIDs = albumsRatedIDs;
        }
    }
}
