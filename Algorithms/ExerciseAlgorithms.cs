using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ExerciseAlgorithms
    {

        public static void GetPrimes(int start, int end)
        {
            List<int> primes = new List<int>();

            for (int num = start; num <= end; num++)
            {
                bool isPrime = true;
                double sqrtNumber = Math.Sqrt(num);
                for (int div = 2; div <= sqrtNumber; div++)
                {
                    if (num % div == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(num);
                }
            }

            if (primes.Count == 0)
            {
                Console.WriteLine($"There is no primes in the interval [{start},{end}]");
            }
            else
            {
                Console.WriteLine($"Primes count : {primes.Count}");
                ReadList(primes);

            }
        }

        private static void ReadList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public static void AddingRandomNumbersToList(List<int> list, int start, int end, int count)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                list.Add(rnd.Next(start, end + 1));
            }

        }

        public static List<int> Union(List<int> firstList, List<int> secondList)
        {
            List<int> result = new List<int>();

            //copying the firstList 
            result.AddRange(firstList);

            foreach (var item in secondList)
            {
                //when the firstList dont contains
                //item from the second, we add this item to the result
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static List<int> Intersect(List<int> firstList, List<int> secondList)
        {
            List<int> result = new List<int>();

            foreach (var item in secondList)
            {
                if (firstList.Contains(item)) { result.Add(item); }
            }


            return result;
        }


    }

}

