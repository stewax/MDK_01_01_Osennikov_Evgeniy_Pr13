using System;
using Interface_Osennikov.Interfaces;
using Interface_Osennikov.Models;
using System.Collections.Generic;

namespace Interface_Osennikov.Classes
{
    public class MessagesContext : Messages, IMessages
    {
        public static List<Messages> AllMessages;

        public MessagesContext() => All(out AllMessages);

        public MessagesContext(string messageText, DateTime createdAt, int userId)
            : base(messageText, createdAt, userId) { }

        public MessagesContext(string messageText, DateTime createdAt, int userId, string imageSource)
            : base(messageText, createdAt, userId, imageSource) { }

        public void All(out List<Messages> messages)
        {
            messages = new List<Messages>();
        }

        public void Delete()
        {
            AllMessages.Remove(this);
        }

        public void Save(bool update = false)
        {
            if (update == false)
            {
                AllMessages.Add(this);
                return;
            }
        }
    }
}
