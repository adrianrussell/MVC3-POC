using System.Collections.Generic;
using Infrastructure;
using Infrastructure.RavenDb;
using Model;
using Services;

namespace RavenDBConsole
{
    public interface IRepositoryCommand
    {
        IRepository Repository { get; set; }
    }

    public interface ICreateBankersCommand
    {
        void Execute();
    }

    public class CreateBankersCommand : ICreateBankersCommand, IRepositoryCommand
    {
        private readonly IBankerService _bankerService;

        public CreateBankersCommand(IBankerService bankerService, IRepository repository) {
            Repository = repository;
            _bankerService = bankerService;
        }

        public void Execute() {
            var bankers = _bankerService.GetBankers();

            if (NoBankersExistInDatabase(bankers)) {
                SaveBanker("2000", "Bill", "Morridge");
                SaveBanker("2001", "Kent", "Beck");
                SaveBanker("2002", "Erich", "Gamma");
                SaveBanker("2003", "Grady", "Booch");
            }
            

        }

        private void SaveBanker(string bankerUserId, string firstName, string lastName) {
            var banker1 = new Banker {BankerUserId = bankerUserId, Name = new Name {FirstName = firstName, LastName = lastName}};
            Repository.Store(banker1);
        }

        private static bool NoBankersExistInDatabase(List<Banker> bankers) {
            return bankers.Count == 0;
        }

        public IRepository Repository { get; set; }
    }
}