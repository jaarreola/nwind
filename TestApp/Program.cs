using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddCategoryAndProduct();
            //AddProduct();
            //RetrieveAndUpdate();
            //List();
            SearchAndDelete();
            Console.WriteLine("Presione <Enter> para finalizar.");
            Console.ReadLine();
        }

        static void AddCategoryAndProduct()
        {
            var c = new Category();

            c.CategoryName = "Cereales";
            c.Description = "Productos de maíz";

            var cereal = new Product() { ProductName = "Cereal", UnitPrice = 15, UnitsInStock = 0 };

            c.Products.Add(cereal);

            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(c);
            }

            Console.WriteLine($"Categoria: {c.CategoryID}, ProductoId: {cereal.ProductId}");
        }

        static void AddProduct()
        {
            var avena = new Product() { CategoryID = 1, UnitsInStock = 100, ProductName = "Avena", UnitPrice = 10 };

            using (var context = RepositoryFactory.CreateRepository())
            {
                context.Create(avena);
            }

            Console.WriteLine($"ProductoID: {avena.ProductId}");
        }

        static void RetrieveAndUpdate()
        {
            using (var context = RepositoryFactory.CreateRepository())
            {
                var p = context.Retrieve<Product>(x => x.ProductId == 2);

                if (p != null)
                {
                    Console.WriteLine(p.ProductName);
                    p.ProductName = p.ProductName + "*******";
                    context.Update(p);
                    Console.WriteLine("El nombre del producto fue modificado.");
                }
                else {
                    Console.WriteLine($"El producto no fue encontrado.");
                }
            }
        }

        static void List()
        {
            using (var context = RepositoryFactory.CreateRepository())
            {
                var products = context.Filter<Product>(x => x.CategoryID == 1);

                foreach (var item in products)
                {
                    Console.WriteLine($"Categoria: {item.Category.CategoryName}, Producto: {item.ProductName}");
                }
            }
        }

        static void SearchAndDelete()
        {
            using (var context = RepositoryFactory.CreateRepository())
            {
                var product = context.Retrieve<Product>(x => x.ProductId == 2);

                if (product != null)
                {
                    Console.WriteLine(product.ProductName);
                    context.Delete(product);
                    Console.WriteLine("El producto fue eliminado.");
                }
                else
                {
                    Console.WriteLine("El producto no fue encontrado.");
                }
            }
        }
    }
}
