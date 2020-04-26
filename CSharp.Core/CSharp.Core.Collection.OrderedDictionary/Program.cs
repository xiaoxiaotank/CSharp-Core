using System;
using System.Collections.Specialized;

namespace CSharp.Core.Collection.OrderedDictionary1
{
    /// <summary>
    /// 内部实质是：散列表 + 数组
    /// 可根据 Key 和 Index 访问数据
    /// </summary>
    class Program
    {
        /// <summary>
        /// 非泛型
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            OrderedDictionary orderedDictionary = new OrderedDictionary();
        }
    }
}
