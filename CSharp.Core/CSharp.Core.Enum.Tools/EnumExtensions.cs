using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharp.Core.Enum1.Tools
{
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举值的描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var name = value.ToString();
            try
            {
                var field = value.GetType().GetField(name);
                var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                // 当描述属性没有时，直接返回名称
                if (attributes.Length == 0)
                {
                    return name;
                }

                var descriptionAttribute = attributes[0] as DescriptionAttribute;
                return descriptionAttribute.Description;
            }
            catch
            {
                return name;
            }
        }

    }
}
