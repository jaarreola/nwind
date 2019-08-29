using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Entities;
using SLC;

namespace Service.Controllers
{
    public class NWindController : ApiController, IService
    {
        [HttpPost]
        public Category CreateCategory(Category newCategory)
        {
            var bl = new BLL.Categories();
            var NewCategory = bl.Create(newCategory);
            return NewCategory;
        }

        [HttpPost]
        public Product CreateProduct(Product newProduct)
        {
            var bl = new BLL.Products();
            var NewProduct = bl.Create(newProduct);
            return NewProduct;
        }

        [HttpGet]
        public bool DeleteCategory(int ID)
        {
            var bl = new BLL.Categories();
            var Result = bl.Delete(ID);
            return Result;
        }

        [HttpGet]
        public bool DeleteProduct(int ID)
        {
            var bl = new BLL.Products();
            var Result = bl.Delete(ID);
            return Result;
        }

        [HttpGet]
        public List<Product> FilterProductsByCategoryID(int ID)
        {
            var bl = new BLL.Products();
            var Result = bl.FilterByCategoryID(ID);
            return Result;
        }

        [HttpGet]
        public Category RetrieveCategoryByID(int ID)
        {
            var bl = new BLL.Categories();
            var Result = bl.RetrieveByID(ID);
            return Result;
        }

        [HttpGet]
        public Product RetrieveProductByID(int ID)
        {
            var bl = new BLL.Products();
            var Result = bl.RetrieveByID(ID);
            return Result;
        }

        [HttpPost]
        public bool UpdateCategory(Category categoryToUpdate)
        {
            var bl = new BLL.Categories();
            var Result = bl.Update(categoryToUpdate);
            return Result;
        }

        [HttpPost]
        public bool UpdateProduct(Product productToUpdate)
        {
            var bl = new BLL.Products();
            var Result = bl.Update(productToUpdate);
            return Result;
        }
    }
}
