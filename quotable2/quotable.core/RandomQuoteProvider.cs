using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    ///     The interface for both classes. 
    /// </summary>
    public interface RandomQuoteProvider
    {
        /// <summary>
        /// IEnumerable means there will be a collection (array) with a for-each loop, shows all of the quotes
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> showQuotes();
        //IEnumerable<quote> showTheQuotes(long numQuotes);
        /// <summary>
        /// Gets a single quote by its ID
        /// </summary>
        /// <param name="quoteId"></param>
        /// <returns></returns>
        string getQuoteByID(long quoteId);
        /// <summary>
        /// Gets a single random quote
        /// </summary>
        /// <returns></returns>
        string getRandomQuote();

    }
}
