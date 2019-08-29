using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace SLC
{
    public interface IService
    {
        Product CreateProduct(Product newProduct);
        Product RetrieveProductByID(int ID);
        bool UpdateProduct(Product productToUpdate);
        bool DeleteProduct(int ID);
        List<Product> FilterProductsByCategoryID(int ID);
        Category CreateCategory(Category newCategory);
        Category RetrieveCategoryByID(int ID);
        bool UpdateCategory(Category categoryToUpdate);
        bool DeleteCategory(int ID);
    }
}
