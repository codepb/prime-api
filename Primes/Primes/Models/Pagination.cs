namespace Primes.Models
{
    public class Pagination
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 50;

        public bool IsValid => Page > 0 && PerPage > 0;
    }
}
