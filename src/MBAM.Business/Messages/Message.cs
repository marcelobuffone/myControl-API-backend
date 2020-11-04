
namespace MBAM.Business.Messages
{
    public class Message
    {
        public Message(string message)
        {
            Value = message;
        }

        public string Value { get; }
    }
}
