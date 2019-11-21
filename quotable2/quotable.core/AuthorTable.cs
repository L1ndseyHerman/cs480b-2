using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    public sealed class AuthorObject
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<QuotesAndAuthorsObject> QuotesAndAuthorsTable { get; set; }
    }
}
