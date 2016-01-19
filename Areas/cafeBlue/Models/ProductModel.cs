using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CafeBlue;

namespace AppService.Areas.cafeBlue.Models
{
    public class ProductModel:CafeBlue.Repository
    {
        public ProductModel()
        {

        }

        /// <summary>
        /// edit product 
        /// </summary>
        /// <param name="editproduct"></param>
        public void editProduct(ProductsTable editproduct)
        {
            edit_Product(editproduct);
        }
        
        /// <summary>
        /// remove product 
        /// </summary>
        /// <param name="product"> product name</param>
        /// <param name="cati">product catigory</param>
        public void removeProduct(string product,string cati)
        {
            remove_Product(cati, product);
        }

        /// <summary>
        /// add new products
        /// </summary>
        /// <param name="newproduct">new product data</param>
        public void newProduct(ProductsTable newproduct)
        {
            add_Product(newproduct);
        }
        
        /// <summary>
        /// find the products
        /// </summary>
        /// <param name="name">name of the product </param>
        /// <param name="cati">product catigory</param>
        /// <returns>return product table type</returns>
        public ProductsTable find(string name,string cati)
        {
            return findProduct(cati, name);
        }

        /// <summary>
        /// check if product name exist
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="cati"> Product Catigory</param>
        /// <returns></returns>
        public static bool nameExist(string name,string cati)
        {
            return checkProductNameExist(cati, name);
        }

        public List<ProductsTable> getProduct(string product)
        {
            List<ProductsTable> list = null;

            switch(product)
            {
                case "cold":
                    {
                        list = getAll_ColdBeverage();
                        break;
                    }
                case "meal":
                    {
                        list = getAll_Meal();
                        break;
                    }
                case "hot":
                    {
                        list = getAll_HotBeverage();
                        break;
                    }
            }
            return list;
        }
    }
}