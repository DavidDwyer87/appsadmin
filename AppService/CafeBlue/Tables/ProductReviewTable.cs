using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CafeBlue
{
    [Table("ProductReview")]
    public class ProductReviewTable
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string user { get; set; }
        public int productRating { get; set; }
        public string location { get; set; }
    }
}
