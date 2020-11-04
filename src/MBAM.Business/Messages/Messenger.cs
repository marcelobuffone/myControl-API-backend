using MBAM.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MBAM.Business.Messages
{
    public class Messenger : IMessenger
    {
        private List<Message> _messages;

        public Messenger()
        {
            _messages = new List<Message>();

        }
        public List<Message> GetMessages()
        {
            return _messages;
        }

        public void Handle(Message message)
        {
            _messages.Add(message);
        }

        public bool HasMessage()
        {
            return _messages.Any();
        }
    }
}
