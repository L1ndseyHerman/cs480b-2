using quotable.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quotable.api.Models
{
    /// <summary>
    ///     What the QuotesController can do; retrieve quote by id, retreive all, or retreive a single 
    ///     random quote.
    /// </summary>
    public class QuoteData
    {
        public string getQuoteByID { get; set; }
        public IEnumerable<string> showQuotes { get; set; }
        public string getRandomQuote { get; set; }
    }
}
