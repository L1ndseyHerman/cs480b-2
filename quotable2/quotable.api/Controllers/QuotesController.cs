                                                     using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotable.api.Models;
using quotable.core;
using quotable.core.data;

namespace quotable.api.Controllers
{
    /// <summary>
    /// API controller for quotes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuotableContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The database context to data access.</param>
        public QuotesController(QuotableContext context)
        {
            _context = context;
        }

        // GET api/values
        /// <summary>
        /// Returns all the quotes.
        /// </summary>
        /// <returns>All the quotes.</returns>
        [HttpGet]
        public IEnumerable<Models.QuoteTable> Get()
        {
            return from quote in _context.QuoteTable
                   select new Models.QuoteTable()
                   {
                       Quote = quote.Quote
                   };
        }

        // GET api/values/5
        /// <summary>
        /// Gets a specific quote.
        /// </summary>
        /// <param name="id">The id of the quote to get.</param>
        /// <returns>The document.</returns>
        [HttpGet("{id}")]
        public ActionResult<Models.QuoteTable> Get(long id)
        {
            var quote = _context.QuoteTable.SingleOrDefault(d => d.Id == id);

            if (quote == null)
            {
                return NotFound();
            }

            return new Models.QuoteTable()
            {
                Quote = quote.Quote
            };
        }



        /*
        /// <summary>
        ///     Not sure what it does, but it needs to be there.
        /// </summary>
        private RandomQuoteProvider Provider { get; }

        /// <summary>
        ///     Not sure what it does, but it needs to be there.
        /// </summary>
        /// <param name="provider"></param>
        public QuotesController(RandomQuoteProvider provider)
        {
            Provider = provider;
        }

        // GET api/values
        /// <summary>
        ///     Whoops, this doesn't get changed!
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        ///     This is what shows up in the "http" when you type "/1" at the end or whatever. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        public ActionResult<QuoteData> Get(int id)
        {
            var data = new QuoteData();
            data.getQuoteByID = Provider.getQuoteByID(id);
            data.showQuotes = Provider.showQuotes();
            data.getRandomQuote = Provider.getRandomQuote();
            //return "value";
            return data;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
