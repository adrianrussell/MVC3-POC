using System;
using Infrastructure;
using NUnit.Framework;
using Rhino.Mocks;

namespace ApproverService.Test
{
    [TestFixture]
    public class MessageAgentFixture
    {
        private ISimpleMessageQueue _messageQueue;

        [SetUp]
        public void SetUp() {
            _messageQueue = MockRepository.GenerateMock<ISimpleMessageQueue>();
        }

        [Test]
        public void CanCreate() {
            var agent = GetReceiver();

            Assert.That(agent, Is.Not.Null);
        }

        [Test]
        public void Receive_MessageQueueEmpty_ReturnsEmptyMessage() {
            var agent = GetReceiver();
            ExpectCallOnMessageQueueReturnsEmptyMessage();

            var message = agent.Receive();

            Assert.That(message, Is.EqualTo(Guid.Empty));
        }

        [Test]
        public void Recevie_MessageQueueWithMessageOnQueue_ReturnsMessage() {
            var agent = GetReceiver();
            var messageToReceive = Guid.NewGuid();
            ExpectCallOnMessageQueueReturnsMessage(messageToReceive);

            var message = agent.Receive();

            Assert.That(message, Is.EqualTo(messageToReceive));
        }

        private void ExpectCallOnMessageQueueReturnsEmptyMessage() {
            _messageQueue.Expect(x => x.Receive()).Return(Guid.Empty);
        }

        private void ExpectCallOnMessageQueueReturnsMessage(Guid mesageToReturn) {
            _messageQueue.Expect(x => x.Receive()).Return(mesageToReturn);
        }

        private MessageAgent GetReceiver() {
            return new MessageAgent(_messageQueue);
        }
    }
}