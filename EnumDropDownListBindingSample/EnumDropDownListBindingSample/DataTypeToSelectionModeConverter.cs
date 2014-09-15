// ----------------------------------------------------------
// <copyright file="DataSourceTypeToSelectionModeConverter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ----------------------------------------------------------

namespace EnumDropDownListBindingSample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Data;

    public class DataTypeToSelectionModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Type enumType = null;
            if (value != null)
            {
                if (value is IEnumerable)
                {
                    return SelectionMode.Multiple;
                }
                else
                {
                    Type valueType = value.GetType();
                    if (valueType.GetTypeInfo().IsEnum)
                    {
                        return SelectionMode.Single;
                    }
                }
            }
            throw new InvalidCastException("The target value must be an enum type value or a collection.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
