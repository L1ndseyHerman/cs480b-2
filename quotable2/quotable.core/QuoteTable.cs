using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// The class for a quote.
    /// </summary>
    public sealed class QuoteObject
    {
        /// <summary>
        /// The unique identifier for the quote.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The quote itself
        /// </summary>
        public string Quote { get; set; }

        /// <summary>
        /// The collection of authors for the quote
        /// </summary>
        [NotMapped]
        public IEnumerable<AuthorObject> Authors => from x in QuotesAndAuthorsTable select x.Author;

        /// <summary>
        /// The relation of quote to author
        /// </summary>
        public ICollection<QuotesAndAuthorsObject> QuotesAndAuthorsTable { get; set; } = new List<QuotesAndAuthorsObject>();
    }
}
