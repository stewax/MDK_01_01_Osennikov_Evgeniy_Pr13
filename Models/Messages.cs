using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Osennikov.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        public string ImageSource { get; set; }

        public Messages()
        {

        }
        public Messages(string messageText, DateTime createdAt, int userId)
        {
            MessageText = messageText;
            CreatedAt = createdAt;
            UserId = userId;
            ImageSource = null;
        }
        public Messages(string messageText, DateTime createdAt, int userId, string imageSource) : this(messageText, createdAt, userId)
        {
            ImageSource = imageSource;
        }
    }
}
