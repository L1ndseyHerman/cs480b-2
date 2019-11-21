using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    public sealed class QuotesAndAuthorsObject
    {
        public long QuoteId { get; set; }
        public QuoteObject Quote { get; set; }
        public long AuthorId { get; set; }
        public AuthorObject Author { get; set; }
    }
}
