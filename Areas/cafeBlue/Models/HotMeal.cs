using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CafeBlue;

namespace AppService.Areas.cafeBlue.Models
{
    public class HotMeal
    {
        public HotMeal()
        {

        }

        public HotMeal(ProductsTable edit_product)
        {

        }

        public HotMeal(string product)
        {

        }

        public ProductsTable ProductModel { get; set; }
    }
}