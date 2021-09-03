using DevReview.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DevReview.API.Persistence
{
    public class DevReviewsDbContext 
    {

        public DevReviewsDbContext()
        {
            products = new List<Product>();
        }

       public List<Product> products { get; set; }
    }
}
