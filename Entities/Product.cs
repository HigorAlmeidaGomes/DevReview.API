using System;
using System.Collections.Generic;

namespace DevReview.API.Entities
{
    public class Product
    {
        public Product(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
            RegisteredAt = DateTime.Now;
            Reviews = new List<ProductReview>();
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public DateTime RegisteredAt { get; private set; }

        public List<ProductReview> Reviews { get; private set; }

        public void AddReview(ProductReview reviews) 
        {
            Reviews.Add(reviews);
        }

        public void Update(decimal price, string descripiton) 
        {
            Description = descripiton;
            Price = price;
        }
    }
}
