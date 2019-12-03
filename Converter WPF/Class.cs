// *********************************************************************
// Created on : $time$
// Created by : CodingSeb
// Notes      : -- No notes for now --
// *********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace $rootnamespace$
{
    /// <summary>
    /// -- Describe here to what is this class used for. (What is it's purpose) --
    /// </summary>
    public class $safeitemname$ : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Do the conversion here
        /// </summary>
        /// <param name="value">the input value</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>the converted value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert back the value (For TwoWays Binding)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is provided to use this converter inline in Xaml
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns>this</returns>
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
