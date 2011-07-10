using System;
using SimpleQueue;

namespace ApproverService
{
    public class MessageAgent
    {
        private readonly ISimpleMessageQueue _messageQueue;

        public MessageAgent(ISimpleMessageQueue messageQueue) {
            _messageQueue = messageQueue;
        }

        public Guid Receive() {
            return _messageQueue.Receive();
        }
    }
}