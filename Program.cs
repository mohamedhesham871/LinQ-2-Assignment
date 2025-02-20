using System.Xml;
using static LinQ_2_Assignment.ListGenerators;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace LinQ_2_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Element Operators
            //1 - Get first Product out of Stock 
            var res = ProductList.First(p => p.UnitsInStock == 0);
            Console.WriteLine(res);


            //2 -Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            var res02 = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine(res02);

            //3
            #region 3.Retrieve the second number greater than 5
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var res03 = Arr.Where(a => a > 5).Skip(1).First();
            Console.WriteLine(res03);

            #endregion

            #endregion
        }
    }
}
