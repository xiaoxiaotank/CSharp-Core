using System;
using System.ComponentModel;

namespace CSharp.Core.Enum1.Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in EnumHelper.GetValues<Gender>())
            {
                Console.WriteLine($"{item}:{item.GetDescription()}");
            }

            foreach (var item in EnumHelper.GetValuesOld<Gender>())
            {
                Console.WriteLine($"{item}:{item.GetDescription()}");
            }

            var gender1 = EnumHelper.GetValue<Gender>("Male");
            var gender2 = EnumHelper.GetValue<Gender>("NotExist");
        }
    }

    enum Gender
    {
        [Description("未知")]
        Unkown = 0,
        [Description("男")]
        Male = 1,
        [Description("女")]
        Female = 2
    }
}
