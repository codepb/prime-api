using Microsoft.AspNetCore.Mvc;
using Primes.Models;
using Primes.Services;
using System.Collections.Generic;

namespace Primes.Controllers
{
    [Route("Primes")]
    public class PrimesController : Controller
    {
        private readonly PrimeGenerator _primeGenerator;

        public PrimesController(PrimeGenerator primeGenerator)
        {
            _primeGenerator = primeGenerator;
        }

        [HttpGet("LessThanOrEqualTo/{number:int}")]
        public ActionResult<PagedResponse<int>> LessThanOrEqualTo(int number, Pagination pagination)
        {
            if(!pagination.IsValid)
            {
                return BadRequest("Page and PerPage must be positive integers");
            }

            _primeGenerator.Reset();

            var primes = new List<int>();

            var maxIndex = pagination.Page * pagination.PerPage;
            var minIndex = maxIndex - pagination.PerPage;

            for (var i = 0; i < maxIndex; i++)
            {
                var nextPrime = _primeGenerator.NextPrime();
                if (nextPrime > number)
                {
                    break;
                }
                if (i >= minIndex)
                {
                    primes.Add(nextPrime);
                }
            }

            return new PagedResponse<int>
            {
                Page = pagination.Page,
                PerPage = pagination.PerPage,
                HasMore = _primeGenerator.NextPrime() <= number,
                Items = primes
            };
        }
    }
}
