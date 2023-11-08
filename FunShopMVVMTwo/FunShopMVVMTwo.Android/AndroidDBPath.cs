using Android.App;
using Android.Content;
using Xamarin.Forms;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FunShopMVVMTwo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FunShopMVVMTwo.Droid;

[assembly: Dependency(typeof(AndroidDBPath))]
namespace FunShopMVVMTwo.Droid
{
    internal class AndroidDBPath: IDBPath
    {
        public string GetPath(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.Personal),
                fileName );
        }
    }
}