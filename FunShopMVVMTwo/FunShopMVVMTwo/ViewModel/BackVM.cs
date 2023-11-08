using FunShopMVVMTwo.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FunShopMVVMTwo.ViewModel
{
    public class BackVM
    {
        public CustomCommand Back { get; set; }

        public BackVM()
        {
            Back = new CustomCommand(async() =>
            {
                await Shell.Current.GoToAsync("//Authorisation");
            });
        }
    }
}
