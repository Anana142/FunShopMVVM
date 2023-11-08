using FunShopMVVMTwo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FunShopMVVMTwo.ViewModel
{
	public class AuthorisationVM : BaseVM
	{
		public string Login {  get; set; }	
		public string Password { get; set; }	

		public CustomCommand Enter { get; set; }
		public CustomCommand Registraion { get; set; }	

        public AuthorisationVM()
        {
			Enter = new CustomCommand(async () =>
			{
				if (DataBase.Instance.Users.FirstOrDefault(x => x.Login == Login && x.Password == Password) != null)
				{
					DataBase.Instance.Role = DataBase.Instance.Users.FirstOrDefault(x => x.Login == Login && x.Password == Password).UserRole;
					await Shell.Current.GoToAsync("//Product");
				}

				else
					App.Current.MainPage.DisplayAlert("Ошибка!", "Неверный логин или пароль.Повторите попытку.", "Ок");
			});
			Registraion = new CustomCommand(async() =>
			{
                await Shell.Current.GoToAsync("//Registration");
            });
        }
    }
}
