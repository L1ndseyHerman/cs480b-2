using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    ///     A class of quote objects that can return the Id, Quote, or Author seperately.
    /// </summary>
    public sealed class quote
    {
        private int quoteId;
        private string theQuote, author;
        /// <summary>
        /// Constructor, each quote has three parts
        /// </summary>
        /// <param name="quoteId"></param>
        /// <param name="theQuote"></param>
        /// <param name="author"></param>
        public quote(int quoteId, string theQuote, string author)
        {
            this.quoteId = quoteId;
            this.theQuote = theQuote;
            this.author = author;
        }

        /// <summary>
        ///     Returns just the Id of that quote.
        /// </summary>
        /// <returns></returns>
        public string getQuoteId()
        {
            return "Quote number: " + quoteId + " ";
        }
        /// <summary>
        ///     Returns just the quote itself.
        /// </summary>
        /// <returns></returns>
        public string getTheQuote()
        {
            return "The quote: " + theQuote + " ";
        }
        /// <summary>
        ///     Returns just the author of the quote.
        /// </summary>
        /// <returns></returns>
        public string getAuthor()
        {
            return "Author: " + author + " ";
        }
    }
}
