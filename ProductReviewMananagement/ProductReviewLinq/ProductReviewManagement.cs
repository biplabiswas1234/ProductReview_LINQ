﻿using System;
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
    }
}