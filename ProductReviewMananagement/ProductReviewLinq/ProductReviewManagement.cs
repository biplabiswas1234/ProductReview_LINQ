using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewLinq
{
    public class ProductReviewManagement
    {
        List<ProductReview> ProductReviewsList = new List<ProductReview>();
        DataTable productdt = new DataTable();

        ///UC1 : Create product review class with 25 default values
        public int AddProductList()
        {
            ProductReviewsList.Add(new ProductReview() { ProductID = 1, UserID = 1, Rating = 1, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 1, UserID = 1, Rating = 1, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 3, UserID = 2, Rating = 1, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 4, UserID = 2, Rating = 2, Review = "bad", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 5, UserID = 3, Rating = 2, Review = "bad", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 5, UserID = 3, Rating = 2, Review = "good", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 7, UserID = 4, Rating = 3, Review = "bad", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 7, UserID = 4, Rating = 3, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 9, UserID = 5, Rating = 3, Review = "bad", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 10, UserID = 5, Rating = 4, Review = "good", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 10, UserID = 6, Rating = 4, Review = "nice", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 10, UserID = 6, Rating = 4, Review = "bad", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 10, UserID = 7, Rating = 5, Review = "good", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 1, UserID = 7, Rating = 5, Review = "nice", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 4, UserID = 8, Rating = 5, Review = "good", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 16, UserID = 8, Rating = 1, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 18, UserID = 9, Rating = 1, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 18, UserID = 9, Rating = 1, Review = "very bad", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 19, UserID = 10, Rating = 2, Review = "bad", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 20, UserID = 10, Rating = 3, Review = "good", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 21, UserID = 11, Rating = 2, Review = "average", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 9, UserID = 11, Rating = 5, Review = "bad", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 25, UserID = 12, Rating = 3, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 25, UserID = 12, Rating = 3, Review = "average", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 25, UserID = 12, Rating = 4, Review = "average", IsLike = true });
            return ProductReviewsList.Count;
        }
        public void DisplayProductReviewList()
        {
            foreach (var product in ProductReviewsList)
            {
                Console.WriteLine("\nProduct ID :" + product.ProductID);
                Console.WriteLine("User ID :" + product.UserID);
                Console.WriteLine("Rating :" + product.Rating);
                Console.WriteLine("Review :" + product.Review);
                Console.WriteLine("Liked :" + product.IsLike);
            }
        }
        //UC2 : Top 3 Records
        public int RetrieveTop3ByRating()
        {
            AddProductList();
            var res = (from product in ProductReviewsList orderby product.Rating descending select product).Take(3).ToList();
            foreach (var list in res)
            {
                Console.WriteLine("\nProduct ID :" + list.ProductID);
                Console.WriteLine("User ID :" + list.UserID);
                Console.WriteLine("Rating :" + list.Rating);
                Console.WriteLine("Review :" + list.Review);
                Console.WriteLine("Liked :" + list.IsLike); ;
            }
            return res.Count;
        }
        //UC3
        public string RetrieveAllByRatingAndProductID()
        {
            AddProductList();
            string productsList = "";
            var productList = (from product in ProductReviewsList where product.Rating > 3 && (product.ProductID == 1 || product.ProductID == 4 || product.ProductID == 9) select product);
            foreach (var product in productList)
            {
                productsList += product.UserID + " ";
                Console.WriteLine("\nProduct ID :" + product.ProductID);
                Console.WriteLine("User ID :" + product.UserID);
                Console.WriteLine("Rating :" + product.Rating);
                Console.WriteLine("Review :" + product.Review);
                Console.WriteLine("Liked :" + product.IsLike);
            }
            return productsList;
        }
        //UC4 : Review Present
        public string RetrieveReviewCountForProductId()
        {
            string productsList = "";
            AddProductList();
            var productList = ProductReviewsList.GroupBy(x => x.ProductID).Select(a => new { ProductID = a.Key, count = a.Count() });
            foreach (var element in productList)
            {
                Console.WriteLine("ProductID " + element.ProductID + " " + "Count " + " " + element.count);
                productsList += element.count + " ";
            }
            return productsList;
        }
        //UC5
        public string RetrieveProductIdAndReview()
        {
            string result = "";
            AddProductList();
            var productList = ProductReviewsList.Select(product => new { ProductID = product.ProductID, Review = product.Review }).ToList();
            foreach (var element in productList)
            {
                Console.WriteLine("ProductId: " + element.ProductID + "\tReview: " + element.Review);
                result += element.ProductID + " ";
            }
            return result;
        }
        //UC6 : Skip first 5 parameter from the list
        public string RetrieveProductReviewSkippingTop5()
        {
            string productsList = "";
            AddProductList();

            var recordedData = (from list in ProductReviewsList orderby list.Rating ascending select list).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:- " + list.ProductID + " " + "UserId:- " + list.UserID
                    + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "IsLike :- " + list.IsLike);
            }
            Console.WriteLine("Now number of datas: " + recordedData.Count());
            return productsList;
        }
        //UC7
        public string RetrieveUserIdAndReview()
        {
            string result = "";
            AddProductList();
            var productList = ProductReviewsList.Select(product => new { UserId = product.UserID, Review = product.Review }).ToList();
            foreach (var element in productList)
            {
                Console.WriteLine("UserId: " + element.UserId + "\tReview: " + element.Review);
                result += element.UserId + " ";
            }
            return result;
        }
        // UC 8 :Creates the data table of product review.
        public int CreateDataTable()
        {
            AddProductList();
            productdt = new DataTable();
            productdt.Columns.Add("ProductId", typeof(Int32));
            productdt.Columns.Add("UserId", typeof(Int32));
            productdt.Columns.Add("Rating", typeof(Int32));
            productdt.Columns.Add("Review", typeof(string));
            productdt.Columns.Add("IsLike", typeof(bool));

            foreach (var data in ProductReviewsList)
            {
                productdt.Rows.Add(data.ProductID, data.UserID, data.Rating, data.Review, data.IsLike);
            }
            return productdt.Rows.Count;
        }
        //UC9
        public string RetrievedetailsWithLikes()
        {
            List<ProductReview> ProductReviewsList = new List<ProductReview>();
            CreateDataTable();
            string productsList = "";
            var res = from product in productdt.AsEnumerable() where product.Field<bool>("IsLike") == true select product;
            foreach (var product in res)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", product["ProductId"], product["UserId"], product["Rating"], product["Review"], product["IsLike"]);
                productsList += product["UserId"] + " ";
            }
            return productsList;
        }
        //UC10 : Average rating
        public string RetrieveAverageRating()
        {
            string result = "";
            CreateDataTable();
            var res = from product in productdt.AsEnumerable() group product by product.Field<int>("ProductId") into temp select new { productid = temp.Key, Average = Math.Round(temp.Average(x => x.Field<int>("Rating")), 1) };
            foreach (var product in res)
            {
                Console.WriteLine("Product id: {0} Average Rating: {1}", product.productid, product.Average);
                result += product.Average + " ";
            }
            return result;
        }
    }
}