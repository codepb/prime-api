using Microsoft.AspNetCore.Mvc;
using Primes.Models;
using Primes.Services;
using System.Collections.Generic;

namespace Primes.Controllers
{
    [Route("Primes")]
    public class PrimesController : Controller
    {
        [HttpGet("LessThanOrEqualTo/{number:int}")]
        public ActionResult<IEnumerable<int>> LessThanOrEqualTo(int number, Pagination pagination)
        {
            if(!pagination.IsValid)
            {
                return BadRequest("Page and PerPage must be positive integers");
            }

            var primeGenerator = new PrimeGenerator();
            var primes = new List<int>();

            var maxIndex = pagination.Page * pagination.PerPage;
            var minIndex = maxIndex - pagination.PerPage;

            for (var i = 0; i < maxIndex; i++)
            {
                var nextPrime = primeGenerator.NextPrime();
                if (nextPrime > number)
                {
                    break;
                }
                if (i >= minIndex)
                {
                    primes.Add(nextPrime);
                }
            }

            return primes;
        }
    }
}
