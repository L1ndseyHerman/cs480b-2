using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// Represents the many-to-many relation between quotes and authors
    /// </summary>
    public sealed class QuotesAndAuthorsObject
    {
        /// <summary>
        /// The ID of the quote related to the author.
        /// </summary>
        public long QuoteId { get; set; }
        /// <summary>
        /// The quote related to the author.
        /// </summary>
        public QuoteObject Quote { get; set; }
        /// <summary>
        /// The ID of the author related to the quote.
        /// </summary>
        public long AuthorId { get; set; }
        /// <summary>
        /// The author related to the quote.
        /// </summary>
        public AuthorObject Author { get; set; }
    }
}
