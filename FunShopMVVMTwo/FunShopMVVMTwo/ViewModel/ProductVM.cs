using FunShopMVVMTwo.Model;
using FunShopMVVMTwo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FunShopMVVMTwo.ViewModel
{
	public class ProductVM : BaseVM
	{
		private List<Product> productList;
		private Product selectedProduct;

		public List<Product> ProductList { get => productList; set { productList = value; Signal(); } }

		public Product SelectedProduct { get => selectedProduct; set { selectedProduct = value; Signal(); } }

		public CustomCommand AddProduct { get; set; }
		public CustomCommand DeleteProduct { get; set; }
		public CustomCommand EditProduct { get; set; }

        public ProductVM()
        {
			ProductList = DataBase.Instance.Products.ToList();

			AddProduct = new CustomCommand(async() =>
			{
				await Shell.Current.GoToAsync($"Edit?id=0");
			});

			EditProduct = new CustomCommand(async() =>
			{
				if (SelectedProduct != null)
					await Shell.Current.GoToAsync($"Edit?id={SelectedProduct.Id}");
			});

			DeleteProduct = new CustomCommand(() =>
			{
				if (SelectedProduct == null)
					return;

				DataBase.Instance.Products.Remove(SelectedProduct);
				DataBase.Instance.SaveChanges();

				ProductList = DataBase.Instance.Products.ToList();
			});
		}
       
        public void OnAppearing()
		{
            
            ProductList = DataBase.Instance.Products.ToList();
            SelectedProduct = null;
          
        }

    }
}
