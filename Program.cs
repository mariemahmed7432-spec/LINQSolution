using System;
using System.Linq;
using LINQ.DataSources;

namespace LINQ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var products = Source.ProductList;

			// ==================== Question 1 ====================
			Console.WriteLine("=== Q1: Seafood Products ===");
			var q1 = products.Where(p => p.Category == "Seafood");
			foreach (var p in q1)
				Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

			// ==================== Question 2 ====================
			Console.WriteLine("\n=== Q2: Product Names ===");
			var q2 = products.Select(p => p.ProductName);
			foreach (var name in q2)
				Console.WriteLine(name);

			// ==================== Question 3 ====================
			Console.WriteLine("\n=== Q3: Sort by Price Ascending ===");
			var q3 = products.OrderBy(p => p.UnitPrice);
			foreach (var p in q3)
				Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

			// ==================== Question 4 ====================
			Console.WriteLine("\n=== Q4: Price Between 10 and 30 ===");
			var q4 = products.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
			foreach (var p in q4)
				Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

			// ==================== Question 5 ====================
			Console.WriteLine("\n=== Q5: In Stock & Condiments ===");
			var q5 = products.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
			foreach (var p in q5)
				Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");

			// ==================== Question 6 ====================
			Console.WriteLine("\n=== Q6: Anonymous Type ===");
			var q6 = products.Select(p => new
			{
				Name = p.ProductName,
				Price = p.UnitPrice,
				StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
			});
			foreach (var item in q6)
				Console.WriteLine($"{item.Name} - {item.Price} - {item.StockStatus}");

			// ==================== Question 7 ====================
			Console.WriteLine("\n=== Q7: Name with Position ===");
			var q7 = products.Select((p, index) => $"{index + 1}. {p.ProductName}");
			foreach (var item in q7)
				Console.WriteLine(item);

			// ==================== Question 8 ====================
			Console.WriteLine("\n=== Q8: Sort by Category then Price Desc ===");
			var q8 = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
			foreach (var p in q8)
				Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");

			// ==================== Question 9 ====================
			Console.WriteLine("\n=== Q9: Beverages Sorted by Stock Desc ===");
			var q9 = products.Where(p => p.Category == "Beverages")
							 .OrderByDescending(p => p.UnitsInStock);
			foreach (var p in q9)
				Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");

			// ==================== Question 10 ====================
			Console.WriteLine("\n=== Q10: Products with Price > 20 (Query Syntax) ===");
			var q10 = from p in products
					  where p.UnitPrice > 20
					  select new { p.ProductName, p.UnitPrice };
			foreach (var item in q10)
				Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");

			// ==================== Question 11 ====================
			Console.WriteLine("\n=== Q11: ProductName with Position ===");
			var q11 = products.Select((p, index) => new { Position = index + 1, p.ProductName });
			foreach (var item in q11)
				Console.WriteLine($"{item.Position} - {item.ProductName}");

			// ==================== Question 12 ====================
			Console.WriteLine("\n=== Q12: Sort words by length then case-insensitive ===");
			string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRry", "ClOveR", "cHeRry" };
			var q12 = Arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
			foreach (var w in q12)
				Console.WriteLine(w);

			// ==================== Question 13 ====================
			Console.WriteLine("\n=== Q13: Digits whose second letter is 'i' reversed ===");
			string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
			var q13 = digits.Where(d => d.Length > 1 && d[1] == 'i').Reverse();
			foreach (var d in q13)
				Console.WriteLine(d);

			Console.WriteLine("\n=== Done! ===");
		}
	}
}