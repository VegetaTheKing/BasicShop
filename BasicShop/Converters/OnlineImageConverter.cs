﻿using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace BasicShop.Converters
{
    public class OnlineImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            string path = value.ToString();
            if (path.StartsWith("\\"))
                path = path.Substring(1);

            return Path.Combine((string)ConfigurationManager.AppSettings["imagesUrl"], path);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
