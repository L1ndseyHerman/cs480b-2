using System;
using System.Collections.Generic;

namespace quotable.core
{
    /// <summary>
    ///     Modified to run on a website's url instead of the Console. Has methods for getting
    ///     a quote by id, getting all of the quotes, and getting a random quote.
    /// </summary>
    //  The ":" is like an "implements" in Java
    public sealed class SimpleRandomQuoteProvider : RandomQuoteProvider
    {
        //  Variables up top like Java
       // private string[] theQuotes = new string[3];
        private quote[] quoteObjects = new quote[3];
        //  These strings are created by what the quote class getters return. 
        private string[] newQuoteStrings = new string[3];
        //  Need something to keep track of how many times the foreach loop runs:
        private int loopsSoFar = 0;

        //private string[] quoteIDs = new string[3];
        //private string[] quotes = new string[3];
        //private string[] quoteAuthors = new string[3];

        //  This string is created by what the quote class getters return.
        private string oneQuoteString;

        /// <summary>
        /// Constructor like Java: 
        /// </summary>
        public SimpleRandomQuoteProvider()
        {
            //theQuotes[0] = "Fear of a name only increases fear of the thing itself. — Hermione Granger";
            //theQuotes[1] = "It is our choices, Harry, that show what we truly are, far more than our abilities. — Albus Dumbledore";
            //theQuotes[2] = "I solemnly swear I am up to no good. - Harry Potter";
            quoteObjects[0] = new quote(0, "Fear of a name only increases fear of the thing itself.", "Hermione Granger");
            quoteObjects[1] = new quote(1, "It is our choices, Harry, that show what we truly are, far more than our abilities.", "Albus Dumbledore");
            quoteObjects[2] = new quote(2, "I solemnly swear I am up to no good.", "Harry Potter");
        }

        /// <summary>
        /// Shows all of the quotes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> showQuotes()
        {
            //public IEnumerable<string> showQuotes(long numQuotes)
            /*foreach( var x in theQuotes )
            {
                if (loopsSoFar < numQuotes)
                {
                    Console.WriteLine(x);
                    Console.WriteLine();
                    loopsSoFar++;
                }
            }
            return theQuotes;*/
            foreach (quote x in quoteObjects)
            {
                if (loopsSoFar < 3)
                {
                    newQuoteStrings[loopsSoFar] = quoteObjects[loopsSoFar].getQuoteId();
                    newQuoteStrings[loopsSoFar] = newQuoteStrings[loopsSoFar] + quoteObjects[loopsSoFar].getTheQuote();
                    newQuoteStrings[loopsSoFar] = newQuoteStrings[loopsSoFar] + quoteObjects[loopsSoFar].getAuthor();
                    loopsSoFar++;
                }
            }
            return newQuoteStrings;
        }
        /// <summary>
        ///     Returns a quote string with the index that is passed in. If the index is out of range, 
        ///     it returns a string announcing an error instead.
        /// </summary>
        /// <param name="quoteId"></param>
        /// <returns></returns>
        public string getQuoteByID(long quoteId)
        {
            //return theQuotes[quoteId];
            if (quoteId >= 0 && quoteId <= 2)
            {
                oneQuoteString = quoteObjects[quoteId].getQuoteId();
                oneQuoteString = oneQuoteString + quoteObjects[quoteId].getTheQuote();
                oneQuoteString = oneQuoteString + quoteObjects[quoteId].getAuthor();
                return oneQuoteString;
            }
            else
            {
                return "There is not a quote at this index";
            }
        }

        /*public quote getQuoteById(long quoteId)
        {
            return quoteObjects[quoteId];
        }*/

        /// <summary>
        ///     Returns the quote string at the index of a randomly generated number.
        /// </summary>
        /// <returns></returns>
        public string getRandomQuote()
        {
            // Got this random number code from https://www.tutorialspoint.com/generating-random-numbers-in-chash
            Random r = new Random();
            //int genRand = r.Next(10, 50);
            //  Hopefully this is the same as Java and means 0-2.999999999999....
            int quoteId = r.Next(0, 3);
            if (quoteId >= 0 && quoteId <= 2)
            {
                oneQuoteString = quoteObjects[quoteId].getQuoteId();
                oneQuoteString = oneQuoteString + quoteObjects[quoteId].getTheQuote();
                oneQuoteString = oneQuoteString + quoteObjects[quoteId].getAuthor();
                return oneQuoteString;
            }
            else
            {
                //  Should never happen
                return "There is not a quote at index " + quoteId;
            }
        }

    }

}
