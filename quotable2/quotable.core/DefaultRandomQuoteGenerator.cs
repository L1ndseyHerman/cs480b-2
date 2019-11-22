using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    ///     This class gets an array of quotes from the main method, then loops through and prints them one at a time.
    /// </summary>
    public sealed class DefaultRandomQuoteGenerator : RandomQuoteProvider
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="theQuotes"></param>
        public DefaultRandomQuoteGenerator(IEnumerable<string> theQuotes)
        {
            foreach (var x in theQuotes)
            {
                Console.WriteLine(x);
                Console.WriteLine();
            }
        }

        /// <summary>
        ///     Only does something in "SimpleRandomQuoteProvider"
        /// </summary>
        /// <param name="quoteId"></param>
        /// <returns></returns>
        public string getQuoteByID(long quoteId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///     Only does something in "SimpleRandomQuoteProvider"
        /// </summary>
        /// <returns></returns>
        public string getRandomQuote()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///     Only does something in "SimpleRandomQuoteProvider"
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> showQuotes()
        {
            throw new NotImplementedException();
        }
    }
}
