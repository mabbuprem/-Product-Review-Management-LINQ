﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Review_Management_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductReviewManager manager = new ProductReviewManager();
            List<ProductReview> productReviewFilledList = new List<ProductReview>();
            Console.WriteLine("Enter 1 to Write all Product Review Values in Console\nEnter 2 to retrieve top 3 Records as per rating\nEnter 3 to retrieve Records with product ID & rating greater than 3\nEnter 4 to retrive record counts when grouped by ProductID\nEnter 5 to retrive product ID & Product Review\nEnter 6 to skip 5 records & retrieve remaining\nEnter 7 to retrieve Product ID & review by Select LINQ");
            int UC = Convert.ToInt32(Console.ReadLine());
            productReviewFilledList = manager.AddingValuesInProductReviewList(productReviewFilledList);
            switch (UC)
            {
                case 1:
                    PrintListToConsole(productReviewFilledList);
                    break;
                case 2:
                    var result2 = (from ProductReview in productReviewFilledList orderby ProductReview.rating descending select ProductReview).Take(3).ToList();
                    PrintListToConsole(result2);
                    break;
                case 3:
                    int[] selectedProductID = { 1, 4, 9 };
                    var result3 = (from ProductReview in productReviewFilledList where ProductReview.rating > 3 && selectedProductID.Contains(ProductReview.productID) select ProductReview).ToList();
                    PrintListToConsole(result3);
                    break;
                case 4:
                    var result4 = from ProductReview in productReviewFilledList group ProductReview by ProductReview.productID into productIDDict select new { GroupingProductID = productIDDict.Key, counterProductID = productIDDict.Count() };
                    foreach (var item in result4)
                    {
                        Console.WriteLine($"ProductID = {item.GroupingProductID}, CountersofProductID = {item.counterProductID}");
                    }
                    break;
                case 5:
                case 7:
                    var result5 = from ProductReview in productReviewFilledList select new { ProductReview.productID, ProductReview.review };
                    foreach (var item in result5)
                    {
                        Console.WriteLine($"ProductID = {item.productID}, Review ={item.review}");
                    }
                    break;
                case 6:
                    var result6 = (from ProductReview in productReviewFilledList select ProductReview).Skip(5).ToList();
                    PrintListToConsole(result6);
                    break;
            }
        }
        public static void PrintListToConsole(List<ProductReview> printedList)
        {
            foreach (ProductReview productReview in printedList)
            {
                Console.WriteLine(productReview.ToString());
            }
        }
    }
}



