using FunShopMVVMTwo.Model;
using FunShopMVVMTwo.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FunShopMVVMTwo.ViewModel
{
    public class RegistrationVM: BaseVM
    {
        private string login;
        private string password;

        public string Login { get => login; set { login = value; Signal(); } }
        public string Password { get => password; set { password = value; Signal(); } }

        public CustomCommand Save { get; set; }

        public RegistrationVM()
        {
            Save = new CustomCommand(async() =>
            {
                if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                {
                    App.Current.MainPage.DisplayAlert("Ошибка", "Заполните все поля!", "Ок");
                    return;
                }

                DataBase.Instance.Users.Add(new User() { Login = Login, Password = Password, UserRole = "User" });
                DataBase.Instance.SaveChanges();


                App.Current.MainPage.DisplayAlert("Регистрация", "Вы зарегистрированы!", "Ок");

                Login = null;
                Password = null;

                await Shell.Current.GoToAsync("//Authorisation");
            });
        }
    }
}
