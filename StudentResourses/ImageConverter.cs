using System;
using System.Data;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Text;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace PskovUniversityCase.StudentResourses
{
	/// <summary>
	/// Description of conv.
	/// </summary>

	public class Converter : IValueConverter
	{
	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	    {
	    	return ASCIIEncoding.ASCII.GetString((byte[])value);
	    }
	     
	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	    {
	        return DependencyProperty.UnsetValue;
	    }  
	}
	}
