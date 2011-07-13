using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Raven.Client;

namespace Services
{
    public interface IBankerService
    {
        List<Banker> GetBankers();
    }

    public class BankerService : IBankerService
    {
        public BankerService(IDocumentSession documentSession) {
            DocumentSession = documentSession;
        }

        public IDocumentSession DocumentSession { get; set; }

        public List<Banker> GetBankers() {
            return DocumentSession.Query<Banker>().ToList();
        }

    }
}
