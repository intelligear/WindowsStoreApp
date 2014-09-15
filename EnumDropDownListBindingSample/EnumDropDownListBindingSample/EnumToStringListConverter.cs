

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
                //TODO: move to resw
                throw new InvalidCastException("The target value must be an enum type value or a collection comprises of enum values.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
