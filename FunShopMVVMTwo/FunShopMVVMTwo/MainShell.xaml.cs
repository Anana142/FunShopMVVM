using FunShopMVVMTwo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunShopMVVMTwo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainShell : Shell
    {
        public MainShell()
        {
            InitializeComponent();
			Routing.RegisterRoute("Edit", typeof(EditProductPage));
		}

        private async void Back(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Authorisation");
        }
    }
}