using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FunShopMVVMTwo.Tools
{
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Signal([CallerMemberName] string prop = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));   
    }
}
