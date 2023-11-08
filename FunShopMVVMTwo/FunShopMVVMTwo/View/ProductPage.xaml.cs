﻿using FunShopMVVMTwo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunShopMVVMTwo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductPage : ContentPage
	{
		public ProductPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            ((ProductVM)BindingContext).OnAppearing();
		}
    }
}