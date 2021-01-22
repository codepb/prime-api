# Primes

To run the solution, open the repository and run the following command:

```
cd Primes/Primes & docker build -f Dockerfile -t primes-api .. & cd ../../primes-ui & docker build -t primes-ui . & cd ../ & docker run -p 3000:80 --name PrimesUi primes-ui & docker run -p 46000:80 --name PrimesApi primes-api
```

## Notes

I've implemented the prime generator as a singleton and cache any previously generated primes to minimise work done.

I have implemented an algorithm for generating primes that checks whether there are any prime factors less than or equal to the square root of the number being checked. This cuts out a lot of unnecessary checks. I also only check the odd numbers, as after 2, all primes are odd.

I've not implemented validation of the inputs on the front end because this is just meant to be a simple interface to the API.
