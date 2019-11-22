using NUnit.Framework;
using quotable.core;

namespace Tests
{
    /// <summary>
    /// Testing the core
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Happens once
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Does lots of stuff
        /// </summary>
        [Test]
        public void Test1()
        {
            var generator = new SimpleRandomQuoteProvider();
            long input = 0;
            string expected = "Quote number: 0 The quote: Fear of a name only increases fear of the thing itself. Author: Hermione Granger ";
            var actual = generator.getQuoteByID(input);
            Assert.AreEqual(expected, actual);

            input = 1;
            expected = "Quote number: 1 The quote: It is our choices, Harry, that show what we truly are, far more than our abilities. Author: Albus Dumbledore ";
            actual = generator.getQuoteByID(input);
            Assert.AreEqual(expected, actual);

            input = 2;
            expected = "Quote number: 2 The quote: I solemnly swear I am up to no good. Author: Harry Potter ";
            actual = generator.getQuoteByID(input);
            Assert.AreEqual(expected, actual);

            input = -1;
            expected = "There is not a quote at this index";
            actual = generator.getQuoteByID(input);
            Assert.AreEqual(expected, actual);

            input = 3;
            expected = "There is not a quote at this index";
            actual = generator.getQuoteByID(input);
            Assert.AreEqual(expected, actual);

            //Assert.Pass();
        }
    }
}