using MBAM.Business.Messages;
using System.Collections.Generic;

namespace MBAM.Business.Interfaces
{
    public interface IMessenger
    {
        bool HasMessage();
        List<Message> GetMessages();
        void Handle(Message message);
    }
}
