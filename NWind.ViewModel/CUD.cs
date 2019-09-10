using System;
using System.Collections.Generic;
using System.Text;

namespace NWind.ViewModel
{
    public class CUD : ViewModelBase
    {
        public CUD()
        {
            CreateProductCommand = new CommandDelegate
            ((o) => { return true; },
            (o) =>
            {
                var NewProduct = new Entities.Product
                {
                    ProductName = ProductName_BF,
                    CategoryID = CategoryID_BF,
                    UnitsInStock = UnitsInStock_BF,
                    UnitPrice = UnitPrice_BF
                };

                var proxy = new NWindProxyService.Proxy();
                NewProduct = proxy.CreateProduct(NewProduct);
                ProductID = NewProduct.ProductId;
            });

            UpdateProductCommand = new CommandDelegate
                ((o) => { return true; },
                (o) =>
                {
                    var currentProduct = new Entities.Product
                    {
                        ProductId = ProductID_BF,
                        ProductName = ProductName_BF,
                        CategoryID = CategoryID_BF,
                        UnitsInStock = UnitsInStock_BF,
                        UnitPrice = UnitPrice_BF
                    };

                    var proxy = new NWindProxyService.Proxy();
                    var Modified = proxy.UpdateProduct(currentProduct);
                });

            DeleteProductCommand = new CommandDelegate
                ((o) => { return true; },
                (o) =>
                {
                    var proxy = new NWindProxyService.Proxy();
                    var isDeleted = proxy.DeleteProduct(ProductID);

                    if (isDeleted)
                    {
                        ProductID = 0;
                        ProductName = "";
                        CategoryID = 0;
                        UnitsInStock = 0;
                        UnitPrice = 0;
                    }
                });
        }

        private int ProductID_BF;
        public int ProductID
        {
            get { return ProductID_BF; }
            set {
                if (ProductID_BF != value)
                {
                    ProductID_BF = value;
                    OnPropertyChanged();
                }
            }
        }

        private string ProductName_BF;
        public string ProductName
        {
            get { return ProductName_BF; }

            set {
                if (ProductName_BF != value)
                {
                    ProductName_BF = value;
                    OnPropertyChanged();
                }
            }
        }

        private int CategoryID_BF;
        public int CategoryID
        {
            get { return CategoryID_BF; }

            set {
                if (CategoryID_BF != value)
                {
                    CategoryID_BF = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal UnitsInStock_BF;
        public decimal UnitsInStock
        {
            get { return UnitsInStock_BF; }

            set {
                if (UnitsInStock_BF != value)
                {
                    UnitsInStock_BF = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal UnitPrice_BF;
        public decimal UnitPrice
        {
            get { return UnitPrice_BF; }

            set {
                if (UnitPrice_BF != value)
                {
                    UnitPrice_BF = value;
                    OnPropertyChanged();
                }
            }
        }

        public CommandDelegate CreateProductCommand { get; set; }
        public CommandDelegate UpdateProductCommand { get; set; }
        public CommandDelegate DeleteProductCommand { get; set; }
    }
}
