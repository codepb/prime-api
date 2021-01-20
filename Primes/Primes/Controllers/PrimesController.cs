using Microsoft.AspNetCore.Mvc;
using Primes.Services;
using System.Collections.Generic;

namespace Primes.Controllers
{
    [Route("Primes")]
    public class PrimesController : Controller
    {
        [HttpGet("LessThanOrEqualTo/{number:int}")]
        public ActionResult<IEnumerable<int>> LessThanOrEqualTo(int number)
        {
            var primeGenerator = new PrimeGenerator();
            var primes = new List<int>();
            var nextPrime = primeGenerator.NextPrime();

            while (nextPrime <= number)
            {
                primes.Add(nextPrime);
                nextPrime = primeGenerator.NextPrime();
            }

            return primes;
        }
    }
}
