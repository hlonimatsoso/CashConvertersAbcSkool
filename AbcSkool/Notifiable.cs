using AbcSkool.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool
{
    public class Notifiable : INotifiable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void PropertyHasChanged(string propertyName)
        {
            if (!string.IsNullOrWhiteSpace(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
