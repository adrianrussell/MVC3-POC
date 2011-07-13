using System.Collections.Generic;
using Model;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Linq;
using Rhino.Mocks;

namespace Services.Test
{
    [TestFixture]
    public class BankerServiceFixture
    {
        private IDocumentSession _documentSession;
        private IRavenQueryable<Banker> _ravenQueryableMock;

        [SetUp]
        public void Setup() {
            _ravenQueryableMock = MockRepository.GenerateMock<IRavenQueryable<Banker>>();
            _documentSession = MockRepository.GenerateMock<IDocumentSession>();
        }

        [Test]
        public void CanCreate() {
            BankerService service = GetService();

            Assert.That(service, Is.Not.Null);
        }

        [Test]
        public void GetAllBankers_BankersExist_ReturnsBankers() {
            var service = GetService();

            ExpectCallOnDocumentSessionQueryReturnsTwoBankers();

            var result = service.GetBankers();

            Assert.That(2, Is.EqualTo(result.Count));
            _documentSession.VerifyAllExpectations();
        }

        private void ExpectCallOnDocumentSessionQueryReturnsTwoBankers() {
            _documentSession.Expect(x => x.Query<Banker>()).Return(_ravenQueryableMock);
            _ravenQueryableMock.Expect(x => x.GetEnumerator()).Return(new List<Banker> {new Banker(), new Banker()}.GetEnumerator());
        }

        private BankerService GetService() {
            return new BankerService(_documentSession);
        }
    }
}