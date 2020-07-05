using System;
using System.Linq;
using System.Reflection;

namespace MarsRoverProject.Classes
{
    public static class EnumExtensions
    {
        public static string ToText(this Enum enumeration)
        {
            var memberInfo = enumeration.GetType().GetMember(enumeration.ToString());
            if (memberInfo.Length <= 0) return enumeration.ToString();

            var attributes = memberInfo[0].GetCustomAttributes(typeof(StringValue), false);
            return attributes.Length > 0 ? ((StringValue)attributes[0]).Text : enumeration.ToString();
        }

        public static T GetEnumFromStringValue<T>(this string stringValue) where T : Enum
        {
            var enumType = typeof(T);
            foreach (Enum value in Enum.GetValues(enumType))
            {
                FieldInfo fieldInfo = enumType.GetField(value.ToString());
                StringValue[] attributes = (StringValue[])fieldInfo.GetCustomAttributes(
                    typeof(StringValue), false);
                StringValue attr = attributes[0];
                if (attr.Text == stringValue)
                {
                    return (T)value;
                }
            }

            return default;
        }

        public static T GetEnumFromCharValue<T>(this char charValue) where T : Enum
        {
            return GetEnumFromStringValue<T>(charValue.ToString());
        }
    }
}
