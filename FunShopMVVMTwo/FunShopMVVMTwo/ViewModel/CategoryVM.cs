using FunShopMVVMTwo.Model;
using FunShopMVVMTwo.Tools;
using FunShopMVVMTwo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xamarin.Forms;

namespace FunShopMVVMTwo.ViewModel
{
    public class CategoryVM : BaseVM
    {
        private List<Category> categoriesList;

        public Category SelectedCategory { get; set; }
        public List<Category> CategoriesList { get => categoriesList; set { categoriesList = value; Signal(); } }

        public CustomCommand AddCategory { get; set; }
        public CustomCommand DeleteCategory { get; set; }
        public CustomCommand UpdateCategory { get; set; }

        public CategoryVM()
        {
            Routing.RegisterRoute("EditCategory", typeof(EditCategoryPage));

            AddCategory = new CustomCommand(async () =>
            {
                await Shell.Current.GoToAsync($"EditCategory?id=0");
            });

            UpdateCategory = new CustomCommand(async () =>
            {
                if (SelectedCategory != null && SelectedCategory.Id != 0)
                    await Shell.Current.GoToAsync($"EditCategory?id={SelectedCategory.Id}");
            });

            DeleteCategory = new CustomCommand(() =>
            {
                if (SelectedCategory == null)
                    return;

                DataBase.Instance.Categories.Remove(SelectedCategory);
                DataBase.Instance.SaveChanges();

                CategoriesList = DataBase.Instance.Categories.ToList();
            });

        }
        public void OnAppearing()
        {
            CategoriesList = DataBase.Instance.Categories.ToList();
            SelectedCategory = null;
            Signal();
        }
    }
}
