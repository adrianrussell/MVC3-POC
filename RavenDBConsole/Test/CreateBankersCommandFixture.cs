using System;
using System.Collections.Generic;
using Infrastructure;
using Infrastructure.RavenDb;
using Model;
using NUnit.Framework;
using Rhino.Mocks;
using Services;

namespace RavenDBConsole.Test
{
    [TestFixture]
    public class CreateBankersCommandFixture
    {
        private IRepository _repository;
        private IBankerService _bankerService;

        [SetUp]
        public void Setup() {
            _repository = MockRepository.GenerateMock<IRepository>();
            _bankerService = MockRepository.GenerateMock<IBankerService>();
        }

        [TearDown]
        public void Teardown() {
            _repository.VerifyAllExpectations();
            _bankerService.VerifyAllExpectations();
        }


        [Test]
        public void CanCreate() {
            ICreateBankersCommand command = GetCommand();

            Assert.That(command, Is.Not.Null);
        }

        private ICreateBankersCommand GetCommand() {
            return new CreateBankersCommand(_bankerService, _repository);
        }


        [Test]
        public void Execute_IfBankersExist_DoesNotSaveBankers() {
            var command = GetCommand();

            ExpectCallGetAllBankersReturnsOneBanker();

            command.Execute();

            _repository.AssertWasNotCalled(x => x.Store(Arg<Banker>.Is.Anything));
        }

        [Test]
        public void Execute_IfBankersDoNotExist_SaveBankers()
        {
            var command = GetCommand();

            ExpectCallGetAllBankersReturnsZeroBankers();
            ExpectCallRepositoryStoreIsCalledFourTimes();

            command.Execute();

        }

        private void ExpectCallRepositoryStoreIsCalledFourTimes() {
            _repository.Expect(x => x.Store<Banker>(Arg<Banker>.Is.Anything)).Repeat.Times(4);
        }

        private void ExpectCallGetAllBankersReturnsZeroBankers() {
            _bankerService.Expect(x => x.GetBankers()).Return(new List<Banker>());
        }

        private void ExpectCallGetAllBankersReturnsOneBanker()
        {
            _bankerService.Expect(x => x.GetBankers()).Return(new List<Banker>(){new Banker()});
        }

    }
}