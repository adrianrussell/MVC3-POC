using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class SimpleMessageQueue : ISimpleMessageQueue
    {
        private static readonly Queue<Guid> Queue = new Queue<Guid>();

        public int MessageCount {
            get { return Queue.Count; }
        }

        public void Send(Guid guid) {
            Queue.Enqueue(guid);
        }

        public Guid Receive() {
            return Queue.Dequeue();
        }

        public void Clear() {
            Queue.Clear();
        }
    }
}