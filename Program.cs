using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using static LinQ_2_Assignment.ListGenerators;
using static System.Net.Mime.MediaTypeNames;
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

            //var MostExpensive = from p in ProductList
            //                    group p by p.Category into cat
            //                    let max = cat.Max(p => p.UnitPrice)
            //                  from x in cat
            //                  where x.UnitPrice == max
            //                    select new
            //                    {
            //                        catName = cat.Key,
            //                        ProductName = x.ProductName,
            //                        ProductPrice=max
            //                    };
            //foreach (var item in MostExpensive)
            //    Console.WriteLine(item);

            #endregion
            #region 14. Get the average price of each category's products.
            //var MostExpensive = from p in ProductList
            //                    group p by p.Category into cat
            //                    let max = cat.Average(p => p.UnitPrice)
            //                    select new
            //                    {
            //                        catName = cat.Key,
            //                        ProductPrice = max
            //                    };
            //foreach (var item in MostExpensive)
            //    Console.WriteLine(item);

            #endregion

            #endregion

            #region LINQ - Ordering Operators
            #region 1:. Sort a list of products by name
            var res = ProductList.OrderBy(p => p.ProductName);

            //-----------Another Solve--------
            res=from x in ProductList
                orderby x.ProductName
                select x;

            //foreach(var item in res)
            //    Console.WriteLine(item);
            #endregion
            #region 2:. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            string [] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var res01 = Arr.OrderBy(x=>x.ToLower());
            #endregion
            #region 3:Sort a list of products by units in stock from highest to lowest.
            var res02 = ProductList.OrderByDescending(x => x.UnitsInStock);

            //---------Another Solve ---------------
            res02= from p in ProductList
                   orderby p.UnitsInStock descending
                   select p;

            //foreach (var x in res02)
            //{
            //    Console.WriteLine(x);
            //}

            #endregion

            #region 4:4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            
            string[] Arr02 = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            var res03 = Arr02.OrderBy(p => p.Length).ThenBy(x=>x.ToLower());

            //foreach(var x in res03)
            //    Console.WriteLine(x);


            #endregion

            #region 5:Sort first by-word length and then by a case-insensitive sort of the words in an array.

            string[] Arr03 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var res04=Arr03.OrderBy(p=>p.Length).ThenBy(x=>x.ToLower());
            //foreach(var n in res04)
            //    Console.WriteLine(n);


            #endregion

            #region 6: Sort a list of products, first by category, and then by unit price, from highest to lowest.

            var res05=ProductList.OrderBy(cat=>cat.Category).ThenByDescending(p=>p.UnitPrice);

            //foreach(var x in res05)
            //    Console.WriteLine(x);

            #endregion

            #region 7:7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            string[] Arr07 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var res07 = Arr07.OrderBy(x => x.Length).ThenByDescending(x => x.ToLower());

            #endregion

            #region 8: Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] Arr08 = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            var res08 = Arr08.Where(x => x[1] == 'i').Reverse().ToList();
            //foreach(var x in res08)
            //    Console.WriteLine(x);
            #endregion
            #endregion

            #region LINQ – Transformation Operators
            #region  1:  Return a sequence of just the names of a list of products.
            var res11 = ProductList.Select(x => x.ProductName).ToList();
            //foreach(var item in res11)
            //    Console.WriteLine(item);
            #endregion
            #region 2:2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
            
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var res12=words.Select(x=> new  { Lower=x.ToLower(), Upper=x.ToUpper() }).ToList();

            //foreach(var word in res12)
            //    Console.WriteLine(word);

            #endregion
            #region 3:Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            var res13=ProductList.Select(x=>new {
                ProductName=x.ProductName , 
                ProductID=x.ProductID,
                Price =x.UnitPrice ,
                UnitsInStock= x.UnitsInStock
            }).ToList();
            #endregion
            #region 4:4. Determine if the value of int in an array matches their position in the array.
            int[] Arr14 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var res14 = Arr14.Select((x, i) => x == i);
            //foreach(var x in res14)
            //    Console.WriteLine(x);


            #endregion
            #region 5: Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var res15 = from x in numbersA
                        from y in numbersB
                        where x.CompareTo(y) == -1
                        select $"{x} is less than {y}";
            //foreach(var i in res15)
            //    Console.WriteLine(i);

            #endregion 
            #region 6: Select all orders where the order total is less than 500.00.
            var res16 = from x in CustomerList
                        from y in x.Orders
                        where y.Total < 500
                        select y;
            //foreach( var x in res16 )
            //    Console.WriteLine(x);


            #endregion
            #region 7. Select all orders where the order was made in 1998 or later.
            var res17 = from x in CustomerList
                        from y in x.Orders
                        where y.OrderDate >= new DateTime(1998, 1, 1)
                        select y;
            //-------Another Solve ------
            res17 = CustomerList.SelectMany(x => x.Orders).Where(y => y.OrderDate >= new DateTime(1998, 1, 1));
            //foreach( var x in res17 )
            //    Console.WriteLine(x);
            #endregion
            #endregion

            #region LINQ - Set Operators
            #region 1. Find the unique Category names from Product List
            var res31 = ProductList.Select(x => x.Category).Distinct();

            //foreach(var i in res31)
            //    Console.WriteLine(i);
            #endregion
            #region 2: Produce a Sequence containing the unique first letter from both product and customer names.
            var res32 = ProductList.Select((x) => x.ProductName[0]).Distinct();
            var res32_ = CustomerList.Select((x) => x.CustomerName[0]).Distinct();
            //foreach ( var x in res32)
            //    Console.WriteLine(x);
            #endregion
            #region 3. Create one sequence that contains the common first letter from both product and customer names.
            var res33 = ProductList.Select(x => x.ProductName[0]).Intersect(CustomerList.Select(x => x.CustomerName[0]));
            //foreach( var x in res33)
            //    Console.WriteLine(x);
            #endregion
            #region 4.Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            var res34 = ProductList.Select(x => x.ProductName[0]).Except(CustomerList.Select(x => x.CustomerName[0]));
           
            //foreach( var x in res34 )
            //    Console.WriteLine(x);
            #endregion
            #region 5:Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
           //VIP
            var res35 = ProductList.Select(x => x.ProductName.Length>3 ? x.ProductName[^3..] : x.ProductName)
                .Union(
                CustomerList.Select(x => x.CustomerName.Length > 3 ? x.CustomerName[^3..] : x.CustomerName));
            //foreach(var x in res35 )
            //    Console.WriteLine(x);
            #endregion
            #endregion

            #region LINQ - Quantifiers
            #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            var resxx = ArrayOfString.Any(x=>x.Contains("ei"));
            //Console.WriteLine(resxx);
            var res41 = ArrayOfString.Where(x => x.Contains("ei"));
            // foreach(var c in res41)
            //      Console.WriteLine(c);
            #endregion
            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

            var resyy = ProductList.GroupBy(x => x.Category).Where(x=>x.Any(x=>x.UnitsInStock==0));
            //foreach( var x in resyy )
            //{
            //    Console.WriteLine(x.Key);
            //    foreach (var t in x)
            //        Console.WriteLine(t);
            //    Console.WriteLine("---");

            //}

            #endregion
            #region 3.Return a grouped a list of products only for categories that have all of their products in stock.
            var resy3 = ProductList.GroupBy(x => x.Category).Where(x => x.All(x => x.UnitsInStock > 0));
            //foreach (var x in resy3)
            //{
            //    Console.WriteLine(x.Key);
            //    foreach (var t in x)
            //        Console.WriteLine(t);
            //    Console.WriteLine("---");
            //}

            #endregion
            #endregion

            #region LINQ – Grouping Operators
            #region Use group by to partition a list of numbers by their remainder when divided by 5
            List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var final01 = numbers.GroupBy(x => x % 5);
            //foreach(var x in final01)
            //{
            //    Console.WriteLine($"Group :"+x.Key);
            //    foreach(var z in x)
            //        Console.WriteLine(z);
            //    Console.WriteLine("--");

            //}


            #endregion
            #region Uses group by to partition a list of words by their first letter.
            var final02 = ArrayOfString.GroupBy(x => x[0]);
            //foreach(var x in final02)
            //{
            //    Console.WriteLine($"Group with char: {x.Key}");
            //    foreach(var c in x)
            //        Console.WriteLine(c);
            //}

            #endregion
            #region 3-Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            string[] Arr09 = { "from", "salt", "earn", " last", "near", "form" };//[vip]
            var final03 = Arr09.GroupBy( w => new string(w.OrderBy(c => c).ToArray()));
            //foreach(var x in final03)
            //{
            //    Console.WriteLine("...");
            //    foreach(var y in x)
            //        Console.WriteLine(y);
            //}
            #endregion
            #endregion
        }
       

    }
}
