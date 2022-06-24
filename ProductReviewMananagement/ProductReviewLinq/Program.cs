using System;
using System.Collections.Generic;

namespace ProductReviewLinq
{
    internal class Program
    {
        private static readonly List<ProductReview> productReviewList;

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Product Review Management\n");
            ProductReviewManagement productReview = new ProductReviewManagement();
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                 new ProductReview() { ProductID = 1, UserID = 1, Rating = 1, Review = "good", IsLike = true },
                 new ProductReview() { ProductID = 2, UserID = 2, Rating = 1, Review = "good", IsLike = true },
                 new ProductReview() { ProductID = 3, UserID = 3, Rating = 1, Review = "good", IsLike = true },
                 new ProductReview() { ProductID = 4, UserID = 4, Rating = 2, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 5, UserID = 5, Rating = 2, Review = "nice", IsLike = false },
                 new ProductReview() { ProductID = 6, UserID = 6, Rating = 2, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 7, UserID = 7, Rating = 2, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 8, UserID = 8, Rating = 2, Review = "good", IsLike = true },
                 new ProductReview() { ProductID = 9, UserID = 9, Rating = 3, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 10, UserID = 10, Rating = 3, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 11, UserID = 11, Rating = 1, Review = "good", IsLike = true },
                 new ProductReview() { ProductID = 12, UserID = 12, Rating = 1, Review = "good", IsLike = true },
                 new ProductReview() { ProductID = 13, UserID = 13, Rating = 1, Review = "good", IsLike = true },
                 new ProductReview() { ProductID = 14, UserID = 14, Rating = 2, Review = "very bad", IsLike = false },
                 new ProductReview() { ProductID = 15, UserID = 15, Rating = 2, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 16, UserID = 16, Rating = 2, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 17, UserID = 17, Rating = 2, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 18, UserID = 18, Rating = 2, Review = "average", IsLike = true },
                 new ProductReview() { ProductID = 19, UserID = 19, Rating = 3, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 20, UserID = 20, Rating = 3, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 21, UserID = 21, Rating = 2, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 22, UserID = 22, Rating = 2, Review = "bad", IsLike = false },
                 new ProductReview() { ProductID = 23, UserID = 23, Rating = 2, Review = "good", IsLike = true },
                 new ProductReview() { ProductID = 24, UserID = 24, Rating = 3, Review = "average", IsLike = true },
                 new ProductReview() { ProductID = 25, UserID = 25, Rating = 2, Review = "average", IsLike = true },
            };

            int option = 0;
            do
            {
                Console.WriteLine("\n1: For Add Product Review");
                Console.WriteLine("2: For Display the Product Review");
                Console.WriteLine("3: For Retrieve the Top three Review ");
                Console.WriteLine("4: For Retrive who's rating is greater than three");
                Console.WriteLine("5: For Retrive count of Review Present");
                Console.WriteLine("6: For Retrive ProductId And Review");
                Console.WriteLine("7: For Skip Top Five Records");
                Console.WriteLine("8: For Retrive UserId And Review");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        productReview.AddProductList();
                        Console.WriteLine("\nData added ");
                        break;
                    case 2:
                        productReview.DisplayProductReviewList();
                        break;
                    case 3:
                        productReview.RetrieveTop3ByRating();
                        break;
                    case 4:
                        productReview.RetrieveAllByRatingAndProductID();
                        break;
                    case 5:
                        productReview.RetrieveReviewCountForProductId();
                        break;
                    case 6:
                        productReview.RetrieveProductIdAndReview();
                        break;
                    case 7:
                        productReview.RetrieveProductReviewSkippingTop5();
                        break;
                    case 8:
                        productReview.RetrieveUserIdAndReview();
                        break;
                    default:
                        
                        Console.WriteLine("Enter correct number");
                        break;
                }
            }
            while (option != 0);
        }
    }
}
