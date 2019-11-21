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
        public long Id { get; set; }
        public string Quote { get; set; }

        [NotMapped]
        public IEnumerable<AuthorObject> Authors => from x in QuotesAndAuthorsTable select x.Author;

        public ICollection<QuotesAndAuthorsObject> QuotesAndAuthorsTable { get; set; } = new List<QuotesAndAuthorsObject>();
    }
}
