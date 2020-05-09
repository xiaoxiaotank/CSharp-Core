using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Core.Enum1.Tools
{
    public class EnumHelper
    {
        /// <summary>
        /// 获取指定枚举类型的所有枚举项（C# 7.3 开始支持）
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TEnum> GetValues<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }

        /// <summary>
        /// 获取指定枚举类型的所有枚举项（C# 7.3 以下使用）
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TEnum> GetValuesOld<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("必须使用枚举类型");

            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
    }
}
