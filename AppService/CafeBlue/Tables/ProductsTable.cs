using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CafeBlue
{
    [Table("Products")]
    public class ProductsTable
    {
        [Key]
        public int Id { get; set; }
        public string ProductCatigory { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Rewards { get; set; }
        public int Reward_Free { get; set; }
        public string ProductImage { get; set; }
        public string medprice{ get; set; }
        public string largeprice { get; set; }
        public string smallprice { get; set; }
    }
}
