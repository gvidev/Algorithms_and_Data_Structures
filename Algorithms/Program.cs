namespace Algorithms
{


    internal class Program : ExerciseAlgorithms
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");



            GetPrimes(62, 66);
            Console.WriteLine("----------------------");
            GetPrimes(1, 60);
            Console.WriteLine("----------------------");

            List<int> first = new List<int>();
            List<int> second = new List<int>();
            AddingRandomNumbersToList(first, 1, 100,20);
            AddingRandomNumbersToList(second, 1, 100,20);
            List<int> union = Union(first, second);
            Console.WriteLine($"Count: {union.Count}");

            foreach (var item in union)
            {
                Console.Write($"{item} ");
            }


            Console.ReadKey();
        }
        
        
    }
}