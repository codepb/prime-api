using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Primes.Services
{
    public class PrimeGenerator
    {
        private List<int> _previousPrimes = new List<int>();
        public int NextPrime()
        {
            if (!_previousPrimes.Any())
            {
                // we know first prime is 2.
                _previousPrimes.Add(2);
                return 2;
            }

            if (_previousPrimes.Count == 1)
            {
                // special case as increments by 1, every
                // prime after this is odd, so we can increment
                // the number to check by 2.
                _previousPrimes.Add(3);
                return 3;
            }

            var numberToCheck = _previousPrimes.Last() + 2;

            while(true)
            {
                var sqrt = Math.Sqrt(numberToCheck);
                foreach(var prime in _previousPrimes)
                {
                    if (prime > sqrt)
                    {
                        // There must be a prime factor less than
                        // the square of our number, else the number
                        // is prime. Therefore we know this number
                        // is prime.
                        _previousPrimes.Add(numberToCheck);
                        return numberToCheck;
                    }
                    if (numberToCheck % prime == 0)
                    {
                        // Prime factor has been found, therefore
                        // this number is not prime. Incrememnt the
                        // number we are checking and break,
                        // continuing to next loop.
                        numberToCheck++;
                        break;
                    }
                }
                if(numberToCheck == int.MaxValue)
                {
                    throw new InvalidOperationException("Maximum value for integer reached, no more primes.");
                }
            };
        }
    }
}
