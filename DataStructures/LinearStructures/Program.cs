namespace LinearStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Custom ArrayList!");

            Console.WriteLine();
            CustomArrayList<int> numbers = new CustomArrayList<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(6);
            //numbers.Clear();
            numbers.Insert(2, 7);
            Console.WriteLine("Insert 7 on index 2");
            numbers.Print();

            Console.WriteLine();
            Console.WriteLine($"The index of 7 is {numbers.IndexOf(7)}");
            Console.WriteLine($"If the list contains the number 7 : {numbers.Contains(7)}");
            Console.WriteLine($"If the third index element is equals to 3:  {numbers[3].Equals(3)}");
            Console.WriteLine($"Count: {numbers.Count}");

            Console.WriteLine();
            Console.WriteLine($"Removed item is : {numbers.RemoveAt(1)}");
            Console.WriteLine($"Count: {numbers.Count}");
            numbers.Print();

            Console.WriteLine();
            Console.WriteLine($"Removed item is on index: {numbers.Remove(2)}");
            Console.WriteLine($"Count: {numbers.Count}");
            numbers.Print();


            Console.WriteLine("Linked List realization!");
            LinkedList<string> shoppingList = new LinkedList<string>();
            shoppingList.Add("Bread");
            shoppingList.Remove("Bread");
            shoppingList.Add("Butter");
            shoppingList.Add("Merodiq");
            shoppingList.Add("Juice");
            shoppingList[2] = $"A lot of {shoppingList[2]}";
            shoppingList.Add("Fruits");
            shoppingList.RemoveAt(2);
            shoppingList.RemoveAt(0);
            shoppingList.Add(null);
            shoppingList.Add("Milk");
            shoppingList.Remove(null);

            shoppingList.Print();

            //using String format
            Console.WriteLine("Position of Milk = {0}", shoppingList.IndexOf("Milk"));
            Console.WriteLine("Position of Bread = {0}", shoppingList.IndexOf("Bread"));
            Console.WriteLine("Do we have to buy bread? - {0}", shoppingList.Contains("Bread"));



        }
    }
}