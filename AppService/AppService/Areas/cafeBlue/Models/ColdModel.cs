using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CafeBlue;

namespace AppService.Areas.cafeBlue.Models
{
    public class ColdModel:CafeBlue.Repository
    {
        public ColdModel()
        {
            ProductList = getAll_ColdBeverage();
        }

        public ColdModel(ProductsTable product)
        {
            edit_Product(product);
            ProductList = getAll_ColdBeverage();
        }

        public ColdModel(string product)
        {
            remove_Product("cold", product);
            ProductList = getAll_Meal();
        }

        public void newCold(ProductsTable newproduct)
        {
            add_Product(newproduct);
        }

        public ProductsTable Cold(string name)
        {
            return findProduct("cold", name);
        }

        public static bool nameExist(string name)
        {
            return checkProductNameExist("cold", name);
        }

        public List<ProductsTable> ProductList { get; set; }
    }
}