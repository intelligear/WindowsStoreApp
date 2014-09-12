

namespace EnumDropDownListBindingSample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;


    public static class EnumTypeHelper
    {
        public static bool IsEnumCollection(this TypeInfo collectionType)
        {
            bool checkResult = false;
            if (collectionType.ImplementedInterfaces.Contains(typeof(IEnumerable)))
            {
                if (collectionType.IsGenericType)
                {
                    Type valueType = collectionType.GenericTypeArguments[0];
                    checkResult = valueType.GetTypeInfo().IsEnum;
                }
            }
            return checkResult;
        }

        public static Type GetEnumType(object value)
        {
            Type enumType = null;
            if (value != null)
            {
                if (value is IEnumerable)
                {
                    var collectionType = value.GetType().GetTypeInfo();
                    if (collectionType.IsGenericType)
                    {
                        Type valueType = collectionType.GenericTypeArguments[0];
                        if (valueType.GetTypeInfo().IsEnum)
                        {
                            enumType = valueType;
                        }
                    }
                }
                else
                {
                    Type valueType = value.GetType();
                    if (valueType.GetTypeInfo().IsEnum)
                    {
                        enumType = valueType;
                    }
                }
            }
            return enumType;
        }
    }
}
