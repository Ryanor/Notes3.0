﻿using System;
using Windows.UI.Xaml.Data;

namespace Notes.Converter
{
    public class IntegerToDoublerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (double) (int) value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (int) (double) value;
        }
    }
}
