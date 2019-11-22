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
        /// <summary>
        /// Type in an id, get that single quote.
        /// </summary>
        public string getQuoteByID { get; set; }
        /// <summary>
        /// Show all the quotes
        /// </summary>
        public IEnumerable<string> showQuotes { get; set; }
        /// <summary>
        /// Get a single random quote.
        /// </summary>
        public string getRandomQuote { get; set; }
    }
}
