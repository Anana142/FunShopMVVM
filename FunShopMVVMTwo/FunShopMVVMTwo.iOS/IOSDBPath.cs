using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Foundation;
using FunShopMVVMTwo.Tools;
using UIKit;
using Xamarin.Forms;
using FunShopMVVMTwo.iOS;

[assembly : Dependency(typeof(IOSDBPath))]
namespace FunShopMVVMTwo.iOS
{
    public class IOSDBPath : IDBPath
    {
        public string GetPath(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments),
                fileName);
        }
    }
}
