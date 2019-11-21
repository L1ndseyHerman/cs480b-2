using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quotable.api.Models
{
    public class AuthorTable
    {
        /// <summary>
        /// The first name of the author
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the author
        /// </summary>
        public string LastName { get; set; }
    }
}
