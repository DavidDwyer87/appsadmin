using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CafeBlue
{
    class DataContext:DbContext
    {
        public DataContext() :
            base("CafeBlue")
        {

        }

        public DbSet<FeedbackTable> FeedBack { get; set; }
        public DbSet<ProductsTable> Products { get; set; }
        public DbSet<ProductReviewTable> ProductReview { get; set; }
    }
}
