﻿namespace Soloplan.WhatsON.GUI.Common.ConnectorTreeView
{
  using System;
  using System.Globalization;
  using System.Windows.Data;
  using Humanizer;

  public class TimeToAproximateTimeConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null)
      {
        return ((DateTime?)null).Humanize(false);
      }

      if (value is DateTime date)
      {
        return date.Humanize(false);
      }

      return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException("Can't convert from approximate time to exact time.");
    }
  }
}