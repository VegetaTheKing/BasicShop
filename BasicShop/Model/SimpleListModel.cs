﻿using System;
using System.ComponentModel;

namespace BasicShop.Model
{
    public class SimpleListModel : INotifyPropertyChanged
    {
        private string _name;

        public uint Id { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;

                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
}
