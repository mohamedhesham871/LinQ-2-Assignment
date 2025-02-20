using System.Text.RegularExpressions;
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
            ////1 - Get first Product out of Stock 
            //var res = ProductList.First(p => p.UnitsInStock == 0);
            //Console.WriteLine(res);


            ////2 -Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            //var res02 = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            //Console.WriteLine(res02);

            ////3
            #region 3.Retrieve the second number greater than 5
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res03 = Arr.Where(a => a > 5).Skip(1).First();
            //Console.WriteLine(res03);

            #endregion

            #endregion

            #region LINQ - Aggregate Operators
            #region 01 Uses Count to get the number of odd numbers in the array
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res = Arr.Count(p => p % 2 == 1);
            //Console.WriteLine(res);
            #endregion
            #region 02: Return a list of customers and how many orders each has.
            // var order = CustomerList.Select(p => new { customer = p, countofOrder = p.Orders.Count() });
            //foreach (var i in order)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion
            #region 3 Return a list of categories and how many products each has
            //var cat= from n in ProductList
            //         group n by n.Category
            //         into g
            //         select new {name=g.Key ,count =g.Count() };
            ////-------------Another Solve--------
            //cat = ProductList.GroupBy(p => p.Category).Select((p) => new { name = p.Key, count = p.Count() });

            //foreach(var i in cat)
            //{
            //    Console.WriteLine(i);
            //    Console.WriteLine("-----");
            //}

            #endregion
            #region 4:4. Get the total of the numbers in an array.
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
             var res=Arr.Count();
            Console.WriteLine(res);//10 Element
            res = Arr.Sum();
            Console.WriteLine(res);//Sum of Element

            #endregion
            /*
           
            */
            #endregion
        }
    }
}
