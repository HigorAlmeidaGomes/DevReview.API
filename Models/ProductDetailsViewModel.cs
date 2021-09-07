using System;
using System.Collections.Generic;

namespace DevReview.API.Models
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(int id, string title, string description, decimal price, DateTime registeredAt, List<ProductReviewViewmModel> reviews)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            RegisteredAt = registeredAt;
            Reviews = reviews;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public DateTime RegisteredAt { get; private set; }
        
        public List<ProductReviewViewmModel> Reviews { get; private set; }
    }

    public class ProductReviewViewmModel
    {
        public ProductReviewViewmModel(int id, int rating, string author, string comments, DateTime registeredAt)
        {
            Id = id;
            Rating = rating;
            Author = author;
            Comments = comments;
            RegisteredAt = registeredAt;
        }

        public int Id { get; private set; }

        public int Rating { get; private set; }

        public string Author { get; private set; }

        public string Comments { get; private set; }

        public DateTime RegisteredAt { get; private set; }
    }
}

