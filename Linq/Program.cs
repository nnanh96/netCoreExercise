using System;
using System.Linq;

namespace netCoreExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //ex 1
            var arr1 = new[] { 3, 9, 2, 8, 6, 5 };

            var squareArr = from Number in arr1
                         select new { Number, SqrNo = (Number * Number) };
            foreach(var square in squareArr)
            {
                Console.WriteLine(square);
            }

            //ex 2
            var letters = new[] { "X", "Y" };
            var numbers = new[] { 1, 2 };
            var colours = new[] { "Green", "Orange" };

            var cartesianProduct = from letter in letters
                                   from number in numbers
                                   from colour in colours
                                   select new { letter, number, colour };

            Console.WriteLine();
            foreach (var ProductList in cartesianProduct)
            {
                Console.WriteLine(ProductList);
            }

            //ex 3
            int[] arr2 = new int[] { 5, 9, 1, 5, 5, 9 };
            var res = from x in arr2
                    group x by x into y
                    select y;

            Console.WriteLine();
            foreach (var arrEle in res)
            {
                Console.WriteLine($"Number {arrEle.Key} appears {arrEle.Count()} times");
            }
        }
    }
}
