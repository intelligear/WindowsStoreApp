

namespace EnumDropDownListBindingSample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Data;


    public class EnumToStringListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Type enumType = EnumTypeHelper.GetEnumType(value);
            if (enumType != null)
            {
                return Enum.GetNames(enumType);
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
