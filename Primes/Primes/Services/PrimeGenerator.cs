using System;
using System.Collections.Generic;
using System.Linq;

namespace Primes.Services
{
    public class PrimeGenerator
    {
        // seed with first two primes, as from here, we only need to check odd numbers
        private List<int> _generatedPrimes = new List<int>() { 2, 3 };
        private int _index = 0;

        public void Reset()
        {
            _index = 0;
        }

        public int NextPrime()
        {
            while (_generatedPrimes.Count < _index + 1)
            {
                GeneratePrime();
            }

            var prime = _generatedPrimes[_index];
            _index++;
            return prime;
        }

        public void GeneratePrime()
        {
            var numberToCheck = _generatedPrimes.Last() + 2;

            while (true)
            {
                var sqrt = Math.Sqrt(numberToCheck);
                foreach (var prime in _generatedPrimes)
                {
                    if (prime > sqrt)
                    {
                        // There must be a prime factor less than
                        // the square of our number, else the number
                        // is prime. Therefore we know this number
                        // is prime.
                        _generatedPrimes.Add(numberToCheck);
                        return;
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
                if (numberToCheck == int.MaxValue)
                {
                    throw new InvalidOperationException("Maximum value for integer reached, no more primes.");
                }
            };
        }
    }
}
