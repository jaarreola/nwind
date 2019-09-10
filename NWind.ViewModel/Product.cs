using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace NWind.ViewModel
{
    public class Product : ViewModelBase
    {
        public Product()
        {
            InitializeViewModel();
        }

        void InitializeViewModel()
        {
            Products = new List<Entities.Product>();

            SearchProductsCommand = new CommandDelegate
                ((o) => { return true; },
                (o) =>
                {
                    var proxy = new NWindProxyService.Proxy();
                    Products = proxy.FilterProductsByCategoryID(CategoryID);
                });
            SearchProductByIDCommand = new CommandDelegate
                ((o) => { return true; },
                (o) =>
                {
                    if (ProductSelected.ProductId != 0)
                    {
                        var proxy = new NWindProxyService.Proxy();
                        var p = proxy.RetrieveProductByID(ProductSelected.ProductId);

                        ProductName = p.ProductName;
                        ProductID = p.ProductId;
                        UnitsInStock = p.UnitsInStock;
                        UnitPrice = p.UnitPrice;
                    }
                });
        }

        #region Properties
        private int CategoryID_BF;
        public int CategoryID
        {
            get { return CategoryID_BF; }

            set
            {
                CategoryID_BF = value;
                OnPropertyChanged();
            }
        }

        private List<Entities.Product> Products_BF;
        public List<Entities.Product> Products
        {
            get { return Products_BF; }

            set
            {
                Products_BF = value;
                OnPropertyChanged();
            }
        }

        private Entities.Product ProductSelected_BF;
        public Entities.Product ProductSelected
        {
            get { return ProductSelected_BF; }
            set
            {
                ProductSelected_BF = value;
                OnPropertyChanged();
            }
        }

        private string ProductName_BF;
        public string ProductName
        {
            get { return ProductName_BF; }
            set{ ProductName_BF = value; }
        }

        private int ProductID_BF;
        public int ProductID
        {
            get { return ProductID_BF; }
            set { ProductID_BF = value; }
        }

        private decimal UnitsInStock_BF;
        public decimal UnitsInStock {
            get { return UnitsInStock_BF; }
            set { UnitsInStock_BF = value; }
        }

        private decimal UnitPrice_BF;
        public decimal UnitPrice
        {
            get { return UnitPrice_BF; }
            set { UnitPrice_BF = value; }
        }
        #endregion
        public CommandDelegate SearchProductsCommand { get; set; } 
        public CommandDelegate SearchProductByIDCommand { get; set; }
    }
}
