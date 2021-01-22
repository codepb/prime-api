using System.Collections.Generic;

namespace Primes.Models
{
    public class PagedResponse<T>
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public bool HasMore { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
