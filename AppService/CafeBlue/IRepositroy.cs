using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeBlue
{
    public interface IRepositroy
    {
        List<ProductsTable> getAll_Meal();
        List<ProductsTable> getAll_HotBeverage();
        List<ProductsTable> getAll_ColdBeverage();
        void edit_Product(ProductsTable _edit_product);
        void add_Product(string catigory, string product, string Image, string description, string cost);
        void remove_Product(string catigory, string product);
    }
}
