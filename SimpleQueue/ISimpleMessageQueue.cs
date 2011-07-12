using System;

namespace Infrastructure
{
    public interface ISimpleMessageQueue
    {
        int MessageCount { get; }
        void Send(Guid guid);
        Guid Receive();
        void Clear();
    }
}