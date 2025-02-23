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
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            // var res=Arr.Count();
            //Console.WriteLine(res);//10 Element
            //res = Arr.Sum();
            //Console.WriteLine(res);//Sum of Element

            #endregion

            var ArrayOfString = File.ReadAllLines("dictionary_english.txt").ToArray();
            #region 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            //var summ =ArrayOfString.Sum(a=>a.Length);
            //Console.WriteLine(summ);
            #endregion

            #region 6:Get the length of the shortest word in dictionary_english.txt 
            //var shortest=ArrayOfString.OrderBy(x => x.Length).FirstOrDefault();
            //Console.WriteLine(shortest.Length);
            #endregion
            #region 7:Get the length of the longest word in dictionary_english.txt 
            //var Longest = ArrayOfString.OrderBy(x => x.Length).LastOrDefault();
            //Console.WriteLine(Longest.Length);
            #endregion

            #region 8:Get the average length of the words in dictionary_english.txt
            //var Avg = ArrayOfString.Average(x => x.Length);
            //Console.WriteLine(Avg);
            #endregion
            #region 9: Get the total units in stock for each product category.
            //var res= ProductList.GroupBy(p=>p.Category).Select(p=>new {CatName=p.Key ,inStock =p.Count(p=>p.UnitsInStock>0)});
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}   
            #endregion

            #region 10: Get the cheapest price among each category's products
            //var res = ProductList.GroupBy(p => p.Category).Select(p => new { CatName = p.Key, Cheapest = p.Min(p => p.UnitPrice)});
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 11 :Get the products with the cheapest price in each category (Use Let)
            //var lessproduct = from p in ProductList
            //                  group p by p.Category into x
            //                  let min = x.Min(p => p.UnitPrice)
            //                  select new { cat = x.Key, Price = min };

            //foreach (var item in lessproduct)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region 12. Get the most expensive price among each category's products.
            //var MostExpensive = from p in ProductList
            //                    group p by p.Category into cat
            //                    let max = cat.Max(p => p.UnitPrice)
            //                    select new
            //                    {
            //                        catName = cat.Key,
            //                        ProductPrice = max
            //                    };
            //foreach( var item in MostExpensive )
            //    Console.WriteLine(item);
            #endregion
            #region  13. Get the products with the most expensive price in each category.

            var MostExpensive = from p in ProductList
                                group p by p.Category into cat
                                let max = cat.Max(p => p.UnitPrice)
                              from x in cat
                              where x.UnitPrice == max
                                select new
                                {
                                    catName = cat.Key,
                                    ProductName = x.ProductName,
                                    ProductPrice=max
                                };
            foreach (var item in MostExpensive)
                Console.WriteLine(item);

        #endregion
            /*
                *  11. Get the products with the cheapest price in each category (Use Let)
                12. Get the most expensive price among each category's products.
                13. Get the products with the most expensive price in each category.
                14. Get the average price of each category's products.

            */
                                    #endregion
        }
    }
}
