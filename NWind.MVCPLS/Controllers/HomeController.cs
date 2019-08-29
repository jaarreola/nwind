using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NWindProxyService;
using Entities;

namespace NWind.MVCPLS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var proxy = new Proxy();
            var products = proxy.FilterProductsByCategoryID(id);
            return View("ProductList", products);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var proxy = new Proxy();
            var product = proxy.RetrieveProductByID(id);
            return View(product);
        }

        public ActionResult CUD(int id = 0)
        {
            var proxy = new Proxy();
            var product = new Product();

            if (id != 0)
            {
                product = proxy.RetrieveProductByID(id);
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult CUD(Product newProduct, string CreateBtn, string UpdateBtn, string DeleteBtn)
        {
            Product product;
            var proxy = new Proxy();
            ActionResult Result = View();

            if (CreateBtn != null)
            {
                product = proxy.CreateProduct(newProduct);
                if (product != null)
                {
                    Result = RedirectToAction("CUD", new { id = product.ProductId });
                }
            }
            else if (UpdateBtn != null)
            {
                var isUpdate = proxy.UpdateProduct(newProduct);
                if (isUpdate)
                {
                    Result = Content("El producto se ha actualizado!");
                }
            }
            else if (DeleteBtn != null)
            {
                var isDeleted = proxy.DeleteProduct(newProduct.ProductId);
                if (isDeleted)
                {
                    Result = Content("El producto se ha eliminado!");
                }
            }

            return Result;
        }

    }
}