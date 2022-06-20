using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQLibrary.Models
{
    public class UserCreatedMessage
    {
        public Guid UserID { get; set; }
        public string Username  { get; set; }
    }
}
