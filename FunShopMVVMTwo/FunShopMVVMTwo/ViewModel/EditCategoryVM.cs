using FunShopMVVMTwo.Model;
using FunShopMVVMTwo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FunShopMVVMTwo.ViewModel
{
    [QueryProperty(nameof(Id_), "id")]
    public class EditCategoryVM : BaseVM
    {
        private int id_;
        private Category categoryItem;

        public int Id_ { get => id_; set { id_ = value; GetCategory(); } }
        public Category CategoryItem { get => categoryItem; set { categoryItem = value; Signal();  } }

        public CustomCommand Save { get; set; } 
        public CustomCommand Back { get; set; } 

        public EditCategoryVM()
        {
            Save = new CustomCommand (()=>
            {
                if (string.IsNullOrEmpty(CategoryItem.Title))
                {
                    App.Current.MainPage.DisplayAlert("Сообщение", "Заполните все поля!", "Ок");
                    return;
                }

                if (CategoryItem.Id == 0)
                    DataBase.Instance.Categories.Add(CategoryItem);

                else
                    DataBase.Instance.Categories.Update(CategoryItem);

                DataBase.Instance.SaveChanges();

            });
            Back = new CustomCommand(async() =>
            {
                await Shell.Current.GoToAsync("//Category");
            });
        }

        void GetCategory()
        {
            if (Id_ == 0)
                CategoryItem = new Category();
            else
                CategoryItem = DataBase.Instance.Categories.FirstOrDefault(s => s.Id == Id_);
        }

        
    }
}
