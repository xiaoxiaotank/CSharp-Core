using System;
using System.Collections;
using System.Collections.Specialized;

namespace CSharp.Core.Collection.ListDictionary1
{
    /// <summary>
    /// 内部实质是：链表
    /// 存在意义：处理非常小的列表（< 10），基本就是废物
    /// </summary>
    class Program
    {
        /// <summary>
        /// 非泛型
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ListDictionary listDictionary = new ListDictionary();
        }
    }
}
