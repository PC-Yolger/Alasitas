using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Alasitas.Service
{
    public class NotificationService : INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] String PropertyName = null)
        {
            if (!object.Equals(storage, value))
            {
                storage = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        protected void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String PropertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
