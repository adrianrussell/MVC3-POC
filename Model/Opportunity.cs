using System.Collections.Generic;

namespace Model
{
    public class Opportunity : Entity
    {
        public string BankerId { get; set; }
        public List<string> QuoteIds { get; set; }
    }
}