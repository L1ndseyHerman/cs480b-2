using NUnit.Framework;
using quotable.api.Controllers;
using quotable.core;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var generator = new SimpleRandomQuoteProvider();
            var controller = new QuotesController(generator);

            var actual = controller.Get(0);
            Assert.That(actual.Value.getQuoteByID, Is.EqualTo("Quote number: 0 The quote: Fear of a name only increases fear of the thing itself. Author: Hermione Granger "));
            actual = controller.Get(1);
            Assert.That(actual.Value.getQuoteByID, Is.EqualTo("Quote number: 1 The quote: It is our choices, Harry, that show what we truly are, far more than our abilities. Author: Albus Dumbledore "));
            actual = controller.Get(2);
            Assert.That(actual.Value.getQuoteByID, Is.EqualTo("Quote number: 2 The quote: I solemnly swear I am up to no good. Author: Harry Potter "));
            actual = controller.Get(-1);
            Assert.That(actual.Value.getQuoteByID, Is.EqualTo("There is not a quote at this index"));
            actual = controller.Get(3);
            Assert.That(actual.Value.getQuoteByID, Is.EqualTo("There is not a quote at this index"));

            Assert.That(actual.Value.showQuotes, Is.EquivalentTo(new string[] { "Quote number: 0 The quote: Fear of a name only increases fear of the thing itself. Author: Hermione Granger ", "Quote number: 1 The quote: It is our choices, Harry, that show what we truly are, far more than our abilities. Author: Albus Dumbledore ", "Quote number: 2 The quote: I solemnly swear I am up to no good. Author: Harry Potter "  }));
            //  Why aren't or's allowed?
            //Assert.That(actual.Value.getRandomQuote, Is.EqualTo("Quote number: 0 The quote: Fear of a name only increases fear of the thing itself. Author: Hermione Granger " || "Quote number: 1 The quote: It is our choices, Harry, that show what we truly are, far more than our abilities. Author: Albus Dumbledore " || "Quote number: 2 The quote: I solemnly swear I am up to no good. Author: Harry Potter "));
            //Assert.That(actual.Value.getRandomQuote, Is.EquivalentTo(new string[] { "Quote number: 0 The quote: Fear of a name only increases fear of the thing itself. Author: Hermione Granger " || "Quote number: 2 The quote: I solemnly swear I am up to no good. Author: Harry Potter " }));
        }
    }
}