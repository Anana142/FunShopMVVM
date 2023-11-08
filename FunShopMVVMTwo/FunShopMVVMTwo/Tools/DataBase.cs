using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace FunShopMVVMTwo.Tools
{
    public class DataBase
    {
        private const string FileName = "MVVMDataBase.db";
        private static DboContext instance;
        public static DboContext Instance
        {
            get
            {
                if(instance == null)
                {
                    string path = DependencyService.Get<IDBPath>().GetPath(FileName);   

                    instance = new DboContext(path);    
                    instance.Database.EnsureCreated();  
                }
                return instance;
            }
        }
    }
}
