using System;
using NUnit.Framework;

namespace Infrastructure.Test
{
    [TestFixture]
    public class QueueFixture
    {
        private Guid GetGuid() {
            return Guid.NewGuid();
        }

        private static SimpleMessageQueue GetQueue() {
            return new SimpleMessageQueue();
        }

        private SimpleMessageQueue SendMessageOnQueueInstance() {
            var queue = GetQueue();

            var guid = GetGuid();

            queue.Send(guid);
            return queue;
        }

        [TearDown]
        public void TearDown() {
            var queue = GetQueue();

            queue.Clear();
        }

        [Test]
        public void CanCreate() {
            var queue = GetQueue();

            Assert.That(queue, Is.Not.Null);
        }


        [Test]
        public void Receive_MessageReceived_MessageIsEqualToMesageSent() {
            var queue = GetQueue();

            var guid = GetGuid();

            queue.Send(guid);

            var receivedMessage = queue.Receive();

            Assert.That(receivedMessage, Is.EqualTo(guid));
        }


        [Test]
        public void Receive_MessageRecevied_MessageCountDecremented() {
            SimpleMessageQueue queue = SendMessageOnQueueInstance();


            queue.Receive();

            Assert.That(queue.MessageCount, Is.EqualTo(0));
        }

        [Test]
        public void Send_CanSend_SimpleMessage() {
            SimpleMessageQueue queue = SendMessageOnQueueInstance();


            Assert.That(queue.MessageCount, Is.EqualTo(1));
        }

        [Test]
        public void Send_SeperateInstances_MessagesQueuedIs2() {
            SimpleMessageQueue queue1 = SendMessageOnQueueInstance();
            SimpleMessageQueue queue2 = SendMessageOnQueueInstance();

            Assert.That(queue1.MessageCount, Is.EqualTo(2));
            Assert.That(queue2.MessageCount, Is.EqualTo(2));
        }

        [Test]
        public void Clear_CanEmptyQueueWithOneMessage_MessagesQueuedIsZero() {
            SimpleMessageQueue queue1 = SendMessageOnQueueInstance();

            Assert.That(queue1.MessageCount, Is.EqualTo(1));

            queue1.Clear();

            Assert.That(queue1.MessageCount, Is.EqualTo(0));
       }
    }
}