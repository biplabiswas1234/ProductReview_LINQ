using System;

namespace ProductReviewMananagementLinq
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Product Review Management");
            ProductReviewManagement productReview = new ProductReviewManagement();
            productReview.AddProductReviewManagement();
        }
    }
}
