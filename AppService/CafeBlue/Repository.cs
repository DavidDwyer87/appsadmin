using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeBlue
{
    public abstract class Repository
    {

        public virtual List<ProductsTable> getAll_Meal()
        {
            List<ProductsTable> data = new List<ProductsTable>();
            try
            {
                data.AddRange(new DataContext().Products.Where(m=>m.ProductCatigory=="meal"));

                int i = 1;
                foreach(ProductsTable d in data)
                {
                    d.Id = i;
                    i++;
                }
            }
            catch(Exception ex)
            {
            }
            return data;
        }

        public virtual List<ProductsTable> getAll_HotBeverage()
        {
            List<ProductsTable> data = new List<ProductsTable>();
            try
            {
                data.AddRange(new DataContext().Products.Where(m => m.ProductCatigory == "hotbeverage"));
            }
            catch(Exception ex)
            {

            }
            return data;
        }

        public virtual List<ProductsTable> getAll_ColdBeverage()
        {
            List<ProductsTable> data = new List<ProductsTable>();
            try
            {
                data.AddRange(new DataContext().Products.Where(m => m.ProductCatigory == "coldbeverage"));
            }
            catch (Exception ex) { }
            return data;
        }

        public virtual void edit_Product(ProductsTable _edit_product)
        {
            try
            {
                DataContext ctx = new DataContext();
                var data = ctx.Products.FirstOrDefault(m => m.ProductName == _edit_product.ProductName);
                
                data.ProductName = _edit_product.ProductName;
                data.smallprice = _edit_product.smallprice;
                data.medprice = _edit_product.medprice;
                data.largeprice = _edit_product.largeprice;
                data.Description = _edit_product.Description;
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        public virtual void add_Product(ProductsTable newProduct)
        {
            try
            {
               DataContext ctx = new DataContext();
               ctx.Products.Add(newProduct);
               ctx.SaveChanges();
            }
            catch (Exception ex) { }
        }

        public virtual void remove_Product(string catigory, string product)
        {
            try
            {
                DataContext ctx = new DataContext();
                var exist = ctx.Products.FirstOrDefault(m => m.ProductCatigory == catigory && m.ProductName == product);
                ctx.Products.Remove(exist);
                ctx.SaveChanges();
            }
            catch(Exception)
            {

            }
        }

        public virtual ProductsTable findProduct(string catigory, string product)
        {
            DataContext ctx = new DataContext();


            return ctx.Products.FirstOrDefault(m => m.ProductName == product && m.ProductCatigory == catigory);
        }

        public static bool checkProductNameExist(string proCatigory, string name)
        {
            bool state = false;
            try
            {                
                DataContext ctx = new DataContext();
                var exist = ctx.Products.FirstOrDefault(m=>m.ProductName == name && m.ProductCatigory == proCatigory);

                if (exist != null)
                    state = true;
            }
            catch(Exception ex)
            {

            }

            return state;
        }

    }
}
