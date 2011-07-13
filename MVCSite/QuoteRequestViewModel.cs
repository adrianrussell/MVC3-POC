using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace MVCSite
{
    public class QuoteRequestViewModel
    {
        public List<Banker> Bankers { get; set; }
        public List<Product> Products { get; set; }
        public string BankerId { get; set; }
        public Dictionary<string, string> BankersList { get; set; }

    }
}