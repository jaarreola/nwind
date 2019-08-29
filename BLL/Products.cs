using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class Products
    {
        public Product Create(Product newProduct)
        {
            Product Result = null;

            using (var context = RepositoryFactory.CreateRepository())
            {
                Product p = context.Retrieve<Product>(x => x.ProductName == newProduct.ProductName);

                if (p == null)
                {
                   Result = context.Create(newProduct);
                }
                else
                {

                }
            }

            return Result;
        }

        public Product RetrieveByID(int ID)
        {
            Product Result = null;

            using (var context = RepositoryFactory.CreateRepository())
            {
                Result = context.Retrieve<Product>(x => x.ProductId == ID );            
            }

            return Result;
        }

        public bool Update(Product productToUpdate)
        {
            bool Result = false;

            using (var context = RepositoryFactory.CreateRepository())
            {
                Product tmp = context.Retrieve<Product>(x => x.ProductName == productToUpdate.ProductName
                    && x.ProductId != productToUpdate.ProductId);

                if (tmp == null)
                {
                    Result = context.Update(productToUpdate);
                }
                else { }
                
            }

            return Result;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            var productToDelete = RetrieveByID(ID);

            if (productToDelete != null)
            {
                if (productToDelete.UnitsInStock == 0)
                {
                    using (var context = RepositoryFactory.CreateRepository())
                    {
                        Result = context.Delete(productToDelete);
                    }
                }
                else
                {
                    // se puede implementar logica para informar que el producto no se puede eliminar.
                }
            }
            else
            {
                // implementar logica para informar que el producto no existe.
            }           

                return Result;
        }

        public List<Product> FilterByCategoryID(int categoryID)
        {
            List<Product> Result = null;
            using (var context = RepositoryFactory.CreateRepository())
            {
                Result = context.Filter<Product>(x => x.CategoryID == categoryID);
            }

            return Result;

        }

    }
}
