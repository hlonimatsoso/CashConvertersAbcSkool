using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbcSkool.Interfaces
{
    public interface INotifiable : INotifyPropertyChanged
    {
        void PropertyHasChanged(string propertyName);
    }
}
