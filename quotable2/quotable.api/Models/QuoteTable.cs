using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quotable.api.Models
{
    /// <summary>
    /// Model for a quote
    /// </summary>
    public class QuoteTable
    {
        /// <summary>
        /// The quote itself
        /// </summary>
        public string Quote { get; set; }
    }
}
